using RentCarStore.Contracts.Domain.Enums;
using RentCarStore.Contracts.Domain.Helpers;
using RentCarStore.Core.Entites;

namespace RentCarStore.Contracts.Domain
{
    public class Contract : Entity
    {
        public const int MAX_CONTRACT_CODE_LENGTH = 8;
        public string Code { get; set; }
        public Guid CarId { get; set; }
        public DateTime WithdrawAt { get; set; }
        public DateTime ReturnAt { get; set; }
        public Guid CustomerId { get; set; }
        public ContractStatus Status { get; private set; }
        public Contract(Guid carId, Guid customerId, DateTime withdrawAt, DateTime returnAt)
        {
            Code = CodeGenerator.RandomString(MAX_CONTRACT_CODE_LENGTH);
            CarId = carId;
            CustomerId = customerId;
            WithdrawAt = withdrawAt;
            ReturnAt = returnAt;
            Status = ContractStatus.PaymentPending;
        }

        public void Approve()
            => Status = ContractStatus.Approved;

        public void Deny()
            => Status = ContractStatus.Denied;

        public void Finish()
            => Status = ContractStatus.Finished;
    }
}