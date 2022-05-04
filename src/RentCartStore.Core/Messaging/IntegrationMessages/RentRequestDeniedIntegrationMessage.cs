namespace RentCartStore.Core.Messaging.IntegrationMessages
{
    public struct RentRequestDeniedIntegrationMessage
    {
        public string DenyReason { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
    }
}
