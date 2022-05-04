namespace RentCartStore.Core.Messaging
{
    public abstract class Message
    {
        public string Type { get; set; }

        public Message()
        {
            Type = GetType().Name;
        }
    }
}
