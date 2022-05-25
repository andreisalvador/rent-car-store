namespace RestCarStore.Garage.Services.Dtos
{
    public struct ReturnCarDto
    {
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
