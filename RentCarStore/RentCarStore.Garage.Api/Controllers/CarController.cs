using Microsoft.AspNetCore.Mvc;
using RentCarStore.Core.Messaging.Interfaces;
using RentCarStore.Garage.Application.Dtos;
using RentCarStore.Garage.Application.Services.Interfaces;
using RentCarStore.Garage.Domain.Services.Interfaces;

namespace RentCarStore.Garage.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarServices _domainServices;
        private readonly ICarApplicationServices _applicationServices;
        private readonly ISqsConsumer _sqs;

        public CarController(ILogger<CarController> logger, ICarServices domainServices, ICarApplicationServices applicationServices, ISqsConsumer sqs)
        {
            _logger = logger;
            _domainServices = domainServices;
            _applicationServices = applicationServices;
            _sqs = sqs;
        }

        [HttpGet(Name = "GetCarById")]
        [Route("{carId}")]
        public async Task<IActionResult> GetCarById(Guid carId)
        {
            var car = await _domainServices.GetCarById(carId);

            if (car == null)
                return NotFound("Car not found.");

            return Ok(car);
        }

        [HttpPost(Name = "CreateNewCar")]
        public async Task<IActionResult> CreateNewCar(CarDto carDto)
        {
            var car = await _applicationServices.AddCar(carDto);

            return Ok(car);
        }

        [HttpGet]
        [Route("message")]
        public async Task<IActionResult> ConsumeMessage(string queueName)
        {
            var result = await _sqs.GetMessagesAsync(queueName);

            foreach (var message in result)
                await _sqs.DeleteMessageAsync(queueName, message.ReceiptHandle);

            return Ok(result.Select(m => new { m.MessageId, m.Body }));
        }
    }
}