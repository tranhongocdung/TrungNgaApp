using System.Collections.Generic;
using System.Linq;
using MVCWeb.AppDataLayer.Entities;
using MVCWeb.AppDataLayer.IRepositories;

namespace MVCWeb.AppDataLayer.Repositories
{
    public class TransportDirectionRepository : GenericRepository<TransportDirection>, ITransportDirectionRepository
    {
        public TransportDirectionRepository(IDbAppContext context) : base(context)
        {
            
        }

        public List<TransportDirection> GetAll()
        {
            return TableNoTracking.ToList();
        } 

    }
}