using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestCarStore.Garage.Domain;
using RestCarStore.Garage.Domain.Enums;

namespace RentCarStore.Garage.Data.DataMappers
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.RentalStatus)
                .WithOne(c => c.Car)
                .HasForeignKey<CarRentalStatus>(c => c.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasData(CreateCar("Corolla", "Toyota", Color.White, Category.Hatchback, Acessories.AirConditioner | Acessories.AutomaticTransmission));
            //builder.HasData(CreateCar("Gol", "Volkswagen", Color.Blue, Category.Hatchback, Acessories.AirConditioner | Acessories.ElectricSteering));
            //builder.HasData(CreateCar("Blazer", "Chevrolet", Color.Red, Category.Suv, Acessories.AirConditioner | Acessories.AutomaticTransmission | Acessories.ElectricSteering));
        }

        private static Car CreateCar(string name, string brand, Color color, Category category, Acessories acessories)
        {
            Car car = new Car();
            car.Name = name;
            car.Brand = brand;
            car.Color = color;
            car.Category = category;
            car.Acessories = acessories;
            car.RentalStatus = new() { CarId = car.Id };
            return car;
        }
    }
}
