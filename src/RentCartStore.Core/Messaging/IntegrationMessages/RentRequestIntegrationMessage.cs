namespace RentCartStore.Core.Messaging.IntegrationMessages
{
    public struct RentRequestIntegrationMessage 
    {
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public DateOnly StartRentDate { get; set; }
        public DateOnly EndRentDate { get; set; }
    }
}
