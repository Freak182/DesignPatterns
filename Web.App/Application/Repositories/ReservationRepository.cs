using Microsoft.EntityFrameworkCore;
using Web.App.Database;
using Web.App.Database.DbSet;

namespace Web.App.Application.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        protected readonly IDbContext _dbContext;

        public ReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Reservation GetById(int id, bool useTracking = false)
        {
            var query = DbSetWithIncludes();

            if (!useTracking)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefault(entity => entity.Id == id);
        }

        /// <summary>
        /// When we want to retrive with only the minimum attached entities in th graph
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<Reservation> DbSetWithIncludes()
        {
            return _dbContext.Set<Reservation>().AsQueryable();
        }
    }
}
