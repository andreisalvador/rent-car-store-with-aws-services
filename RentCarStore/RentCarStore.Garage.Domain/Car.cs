using RentCarStore.Core.Entites;
using RentCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Domain
{
    public class Car : Entity
    {
        public string Label { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public CarType Type { get; private set; }
        public Accessories Accessories { get; private set; }
        public DateOnly BuildDate { get; }
        public uint CurrentMileage { get; private set; }

        public Car(string label, string color, string name, CarType type, DateOnly buildDate, uint currentMileage)
        {
            Label = label;
            Color = color;
            Name = name;
            Type = type;
            BuildDate = buildDate;
            CurrentMileage = currentMileage;
        }
    }
}