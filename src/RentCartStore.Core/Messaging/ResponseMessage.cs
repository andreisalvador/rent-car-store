using FluentValidation.Results;

namespace RentCartStore.Core.Messaging
{
    public class ResponseMessage : Message
    {
        public ValidationResult ValidationResult { get; private set; }

        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
