using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;
using MVCWeb.Core.IServices;
using MVCWeb.Core.Repositories;
using MVCWeb.Core.Services;
using MVCWeb.Libraries;
using MVCWeb.Models;

namespace MVCWeb.Controllers
{
    public class BookController : BaseController
    {
        private readonly ITransportService _transportService;
        private readonly IBookService _bookService;
        public BookController(
            ITransportService transportService,
            IBookService bookService
            ) 
        {
            _transportService = transportService;
            _bookService = bookService;
        }
        [WhitespaceFilter]
        //[CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new BookIndexViewModel();
            var latestDateHavingTrasport = _transportService.GetLatestDateHavingTransport();
            var day = latestDateHavingTrasport.Day;
            var month = latestDateHavingTrasport.Month;
            var year = latestDateHavingTrasport.Year;

            //var transportList = _transportService.GetTransports()
            model.LatestDateHavingTransport = latestDateHavingTrasport.ToString("dd/MM/yyyy");
            model.TransportDirectionItems = _transportService.GetTransportDirectionsForSelectList();
            model.TransportDirectionId = int.Parse(model.TransportDirectionItems.First().Value);
            model.TransportItems = _transportService.GetTransportsForSelectList(day, month, year);
            return View(model);
        }
    }
}