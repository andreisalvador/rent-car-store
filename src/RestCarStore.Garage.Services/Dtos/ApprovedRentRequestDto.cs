namespace RestCarStore.Garage.Services.Dtos
{
    public struct ApprovedRentRequestDto
    {
        public DateOnly RentStart { get; set; }
        public DateOnly RentEnd { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public string RentCode { get; set; }
    }
}
