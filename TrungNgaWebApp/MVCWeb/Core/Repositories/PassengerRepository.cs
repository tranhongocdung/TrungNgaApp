using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class PassengerRepository : GenericRepository<Passenger>, IPassengerRepository
    {
        private readonly IDbAppContext _context;

        public PassengerRepository(IDbAppContext context) : base(context)
        {
            _context = context as DbAppContext;
        }
    }
}