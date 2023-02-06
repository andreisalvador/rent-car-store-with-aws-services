using RentCarStore.Core.Entites;

namespace RentCarStore.Customers.Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public int MyProperty { get; set; }
    }
}