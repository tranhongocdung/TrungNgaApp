using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCWeb.AppDataLayer.Entities;
using MVCWeb.AppDataLayer.IRepositories;
using MVCWeb.AppDataLayer.IServices;
using MVCWeb.AppDataLayer.Repositories;
using MVCWeb.AppDataLayer.Services;
using MVCWeb.Libraries;
using MVCWeb.Models;

namespace MVCWeb.Controllers
{
    public class BookController : BaseController
    {
        private readonly ITransportDirectionRepository _transportDirectionRepository;
        private readonly IBookService _bookService;
        public BookController(ITransportDirectionRepository transportDirectionRepository) 
        {
            var context = new DbAppContext();
            _transportDirectionRepository = transportDirectionRepository;
            _bookService = new BookService();
        }
        [WhitespaceFilter]
        //[CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new BookIndexViewModel();
            var transportDirectionList = _transportDirectionRepository.GetAll();
            model.TransportDirectionItems = transportDirectionList.Select(o => new SelectListItem
            {
                Value = o.Id.ToString(),
                Text = o.Name
            }).ToList();

            model.TransportItems = new List<SelectListItem>();
            model.TransportDirectionId = transportDirectionList.First().Id;
            return View(model);
        }
    }
}