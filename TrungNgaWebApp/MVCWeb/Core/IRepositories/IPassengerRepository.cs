using MVCWeb.Core.Entities;

namespace MVCWeb.Core.IRepositories
{
    public interface IPassengerRepository : IGenericRepository<Passenger>
    {
        int AddPassenger(string passengerName, string passengerPhoneNo);
    }
}