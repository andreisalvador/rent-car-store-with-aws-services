using RentCarStore.Core.Entites;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain
{
    public class Car : Entity
    {
        public CarCategory Category { get; set; }
        public bool IsActive { get; set; }
    }
}
