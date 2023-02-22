using RentCarStore.Core.Entites;
using RentCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Domain
{
    public class Car : Entity
    {
        public string Label { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public CarCategory Category { get; private set; }
        public Accessories Accessories { get; private set; }
        public DateOnly BuildDate { get; }
        public uint CurrentMileage { get; private set; }
        public string Description { get; set; }
        public string LicensePlate { get; private set; }
        public string ChassisNumber { get; private set; }
        public bool IsActive { get; private set; }

        public Car()
        {

        }

        public Car(string label, string color, string name, CarCategory type, DateOnly buildDate, uint currentMileage, string description, string licensePlate, string chassisNumber)
        {
            Label = label;
            Color = color;
            Name = name;
            Category = type;
            BuildDate = buildDate;
            CurrentMileage = currentMileage;
            Description = description;
            LicensePlate = licensePlate;
            ChassisNumber = chassisNumber;
            Activate();
        }

        public void Activate()
            => IsActive = true;

        public void Inactivate()
            => IsActive = false;

        public void AddAccessories(Accessories accessories)
            => Accessories |= accessories;

        public void RemoveAccessories(Accessories accessories)
           => Accessories &= ~accessories;
    }
}