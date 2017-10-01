using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class PickUpLocationRepository : GenericRepository<PickUpLocation>, IPickUpLocationRepository
    {
        private readonly IDbAppContext _context;

        public PickUpLocationRepository(IDbAppContext context) : base(context)
        {
            _context = context as DbAppContext;
        }
    }
}