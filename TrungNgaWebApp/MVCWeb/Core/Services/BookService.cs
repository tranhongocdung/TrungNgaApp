using System;
using System.Linq;
using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;
using MVCWeb.Core.IServices;
using MVCWeb.Core.Repositories;

namespace MVCWeb.Core.Services
{
    public class BookService : IBookService
    {

        private readonly ITransportRepository _transportRepository;
        public BookService()
        {
            var context = new DbAppContext();
            _transportRepository = new TransportRepository(context);
        }

        public DateTime GetLatestDateHavingTransport()
        {
            var latestTransport = _transportRepository.TableNoTracking.OrderByDescending(o => o.Id).FirstOrDefault();
            return latestTransport == null ? DateTime.Now : latestTransport.RunDate;
        }
    }
}