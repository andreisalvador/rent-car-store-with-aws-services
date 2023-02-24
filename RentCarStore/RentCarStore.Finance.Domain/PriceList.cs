using RentCarStore.Core.Entites;
using RentCarStore.Finance.Domain.Enums;

namespace RentCarStore.Finance.Domain
{
    public class PriceList : Entity
    {
        public string Name { get; private set; }
        public CarCategory Category { get; private set; }
        public DateTime Validity { get; private set; }
        public decimal ValuePerHour { get; private set; }
        public bool IsActive { get; private set; }

        public PriceList()
        {

        }
        public PriceList(CarCategory category, DateTime validity, decimal valuePerHour, string name)
        {
            Category = category;
            Validity = validity;
            ValuePerHour = valuePerHour;
            Name = name;
            Inactivate();
        }

        public decimal GetValueFromPeriod(DateTime start, DateTime end)
        {
            var difference = end.Subtract(start);

            return (decimal)difference.TotalHours * ValuePerHour;
        }

        public void Activate()
            => IsActive = true;

        public void Inactivate()
            => IsActive = false;
    }
}
