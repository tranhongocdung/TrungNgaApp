using System.Linq;
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

        public int AddPassenger(string passengerName, string passengerPhoneNo)
        {
            var passenger = TableNoTracking.FirstOrDefault(o => o.PassengerPhoneNo.Contains(passengerPhoneNo));
            if (passenger != null) return passenger.Id;
            passenger = new Passenger
            {
                PassengerName = passengerName,
                PassengerPhoneNo = passengerPhoneNo
            };
            Insert(passenger);
            return passenger.Id;
        }
    }
}