using System;
using System.Linq;
using MVCWeb.AppDataLayer.Entities;
using MVCWeb.AppDataLayer.IRepositories;
using MVCWeb.AppDataLayer.IServices;
using MVCWeb.AppDataLayer.Repositories;

namespace MVCWeb.AppDataLayer.Services
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