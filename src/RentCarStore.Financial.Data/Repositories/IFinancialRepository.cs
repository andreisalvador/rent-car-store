using Microsoft.EntityFrameworkCore;
using RentCarStore.Financial.Domain;
using RentCartStore.Core.Data;

namespace RentCarStore.Financial.Data.Repositories
{
    public interface IFinancialRepository : IRepository
    {
        Task Create(RentRecord rentRecord);
        Task<RentRecord> Get(Guid id);
        Task<List<RentRecord>> GetByCustomerId(Guid customerId);
        Task<List<RentRecord>> GetAllUnanalyzedRents();
    }

    public class FinancialRepository : IFinancialRepository
    {
        private readonly FinancialContext _context;

        public FinancialRepository(FinancialContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
            => await _context.SaveChangesAsync() > 0;

        public async Task Create(RentRecord rentRecord)
            => await _context.RentRecords.AddAsync(rentRecord);

        public async Task<RentRecord> Get(Guid id)
            => await _context.RentRecords.SingleOrDefaultAsync(r => r.Id == id);

        public async Task<List<RentRecord>> GetAllUnanalyzedRents()
            => await _context.RentRecords.Where(r => r.Status == Domain.Enums.RentStatus.InAnalyse).ToListAsync();

        public async Task<List<RentRecord>> GetByCustomerId(Guid customerId)
            => await _context.RentRecords.Where(r => r.CustomerId == customerId).ToListAsync();
    }
}
