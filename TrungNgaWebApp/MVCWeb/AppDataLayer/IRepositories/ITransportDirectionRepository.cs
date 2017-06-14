using System.Collections.Generic;
using MVCWeb.AppDataLayer.Entities;

namespace MVCWeb.AppDataLayer.IRepositories
{
    public interface ITransportDirectionRepository : IGenericRepository<TransportDirection>
    {
        List<TransportDirection> GetAll();
    }
}