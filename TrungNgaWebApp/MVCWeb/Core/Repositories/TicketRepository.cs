using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly IDbAppContext _context;

        public TicketRepository(IDbAppContext context) : base(context)
        {
            _context = context as DbAppContext;
        }
    }
}