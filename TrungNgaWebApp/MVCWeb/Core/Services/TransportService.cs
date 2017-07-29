using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.IRepositories;
using MVCWeb.Core.IServices;

namespace MVCWeb.Core.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITicketRepository _bookRepository;
        private readonly ITransportRepository _transportRepository;
        private readonly ITransportDirectionRepository _transportDirectionRepository;
        public TransportService(
            ITicketRepository ticketRepository,
            ITransportRepository transportRepository,
            ITransportDirectionRepository transportDirectionRepository
            )
        {
            _bookRepository = ticketRepository;
            _transportRepository = transportRepository;
            _transportDirectionRepository = transportDirectionRepository;
        }
        public DateTime GetLatestDateHavingTransport()
        {
            var latestTransport = _transportRepository.TableNoTracking.OrderByDescending(o => o.Id).FirstOrDefault();
            return latestTransport?.RunDate ?? DateTime.Now;
        }

        public ICollection<SelectListItem> GetTransportDirectionsForSelectList()
        {
            return _transportDirectionRepository.TableNoTracking.Select(o=>new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();
        }

        public ICollection<SelectListItem> GetTransportsForSelectList(int day, int month, int year)
        {
            var transports = _transportRepository.TableNoTracking
                .Where(o=>o.Day == day && o.Month == month && o.Year == year).ToList();
            var list = new List<SelectListItem>();
            transports.ForEach(t =>
            {
                var availSeatNo = _bookRepository.TableNoTracking.Count(o => o.TransportId == t.Id && !o.IsCancelled);
                list.Add(new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Hour.ToString("00") + ":" + t.Minute.ToString("00") + " - Ghế trống " + (48-availSeatNo) + "/48"
                });
            });
            return list;
        }
    }
}