using RentCartStore.Core;
using RestCarStore.Garage.Domain.Enums;

namespace RestCarStore.Garage.Domain
{
    public class Car : Entity
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Acessories Acessories { get; set; }
        public CarRentalStatus RentalStatus { get; set; }

        public Car()
        {
            RentalStatus = new CarRentalStatus() { CarId = Id };
        }
    }
}