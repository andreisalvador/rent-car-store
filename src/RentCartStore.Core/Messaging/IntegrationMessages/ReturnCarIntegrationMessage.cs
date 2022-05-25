namespace RentCartStore.Core.Messaging.IntegrationMessages
{
    public struct ReturnCarIntegrationMessage
    {
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}
