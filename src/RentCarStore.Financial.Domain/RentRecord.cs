using RentCarStore.Financial.Domain.Enums;
using RentCartStore.Core;

namespace RentCarStore.Financial.Domain
{
    public class RentRecord : Entity
    {
        public RentStatus Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid CarId { get; set; }
        public Guid CustomerId { get; set; }

        public RentRecord()
        {
            Status = RentStatus.In_Progress;
        }

        public void ApproveRent()
            => Status = RentStatus.Approved;

        public void DenyRent()
            => Status = RentStatus.Denied;

        public void FinishRent()
        => Status = RentStatus.Finished;

    }
}