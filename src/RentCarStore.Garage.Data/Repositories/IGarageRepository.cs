using Microsoft.EntityFrameworkCore;
using RentCartStore.Core.Data;
using RestCarStore.Garage.Domain;

namespace RentCarStore.Garage.Data.Repositories
{
    public interface IGarageRepository : IRepository
    {
        Task CreateCar(Car car);
        Task<Car> GetCarById(Guid carId);
        void Update<T>(T entity) where T : class;
            
    }

    public class GarageRepository : IGarageRepository
    {
        private readonly GarageContext _context;

        public GarageRepository(GarageContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
            => await _context.SaveChangesAsync() > 0;

        public async Task CreateCar(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public async Task<Car> GetCarById(Guid carId)
            => await _context.Cars.SingleOrDefaultAsync(c => c.Id == carId);

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
        }
    }
}
