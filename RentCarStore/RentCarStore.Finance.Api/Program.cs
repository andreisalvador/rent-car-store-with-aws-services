using RentCarStore.Finance.Api.BackgroundServices;
using RentCarStore.Finance.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Create services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddHostedService<GarageConsumerService>();
//builder.Services.AddHostedService<ContractConsumerService>();

Bootstraper.Resolve(builder.Services, builder.Configuration, typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
