using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Web.App.Database;
using Web.App.Database.DbSet;

namespace Web.App.Application.Repositories
{
    public class ReservationRepository : EntityWithIdRepository<Reservation>, IReservationRepository
    {
        protected readonly IDbContext _dbContext;

        public ReservationRepository(IDbContext dbContext)
        : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
