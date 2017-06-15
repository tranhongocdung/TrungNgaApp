using System.Collections.Generic;
using System.Linq;
using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;

namespace MVCWeb.Core.Repositories
{
    public class TransportDirectionRepository : GenericRepository<TransportDirection>, ITransportDirectionRepository
    {
        public TransportDirectionRepository(IDbAppContext context) : base(context)
        {
            
        }
    }
}