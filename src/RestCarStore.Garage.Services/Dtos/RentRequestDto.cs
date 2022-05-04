namespace RestCarStore.Garage.Services.Dtos
{
    public struct RentRequestDto
    {
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
