using RentCartStore.Core;

namespace RestCarStore.Garage.Domain
{
    public class CarRentalStatus : Entity
    {
        public bool IsRented => RentedBy is not null;
        public Guid? RentedBy { get; set; }
        public DateTime? PickedUpIn { get; set; }
        public DateOnly? ReturnsIn { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
