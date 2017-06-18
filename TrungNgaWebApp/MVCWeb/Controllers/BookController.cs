using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.IServices;
using MVCWeb.Core.Security;
using MVCWeb.Libraries;
using MVCWeb.Models;

namespace MVCWeb.Controllers
{
    [WhitespaceFilter]
    [CustomAuthorize(Roles = "Admin")]
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
        public ActionResult Index()
        {
            ViewBag.CurrentUser = User.DisplayName + " (" + User.Username + ")";
            var model = new BookIndexViewModel();
            var latestDateHavingTrasport = _transportService.GetLatestDateHavingTransport();
            var day = latestDateHavingTrasport.Day;
            var month = latestDateHavingTrasport.Month;
            var year = latestDateHavingTrasport.Year;

            model.LatestDateHavingTransport = latestDateHavingTrasport.ToString("dd/MM/yyyy");
            model.TransportDirectionItems = _transportService.GetTransportDirectionsForSelectList();
            model.TransportDirectionId = int.Parse(model.TransportDirectionItems.First().Value);
            model.TransportItems = _transportService.GetTransportsForSelectList(day, month, year);
            if (model.TransportItems.Any())
            {
                var seatWithBookInfos = _bookService.GetSeatWithBookInfos(int.Parse(model.TransportItems.First().Value));
                model.LeftSeatWithBookInfos = seatWithBookInfos.Where(o => o.IsOnLeftSide).ToList();
                model.RightSeatWithBookInfos = seatWithBookInfos.Where(o => !o.IsOnLeftSide).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult LoadBookingContainer(int transportId)
        {
            var model = new BookIndexViewModel();
            var seatWithBookInfos = _bookService.GetSeatWithBookInfos(transportId);
            model.LeftSeatWithBookInfos = seatWithBookInfos.Where(o => o.IsOnLeftSide).ToList();
            model.RightSeatWithBookInfos = seatWithBookInfos.Where(o => !o.IsOnLeftSide).ToList();
            System.Threading.Thread.Sleep(1500);
            return View("_BookingContainer", model);
        }

        public ActionResult EditBookInfo(int bookId)
        {
            return View();
        }


    }
}