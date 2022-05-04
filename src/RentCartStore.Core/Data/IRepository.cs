namespace RentCartStore.Core.Data
{
    public interface IRepository
    {
        Task<bool> CommitAsync();
    }
}
