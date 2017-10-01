using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        private readonly IDbAppContext _context;

        public SeatRepository(IDbAppContext context) : base(context)
        {
            _context = context as DbAppContext;
        }
    }
}