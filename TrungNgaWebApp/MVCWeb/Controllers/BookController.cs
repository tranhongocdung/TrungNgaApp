using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MVCWeb.Core.Entities;
using MVCWeb.Core.Enums;
using MVCWeb.Core.IServices;
using MVCWeb.Core.Security;
using MVCWeb.Libraries;
using MVCWeb.Models;
using Newtonsoft.Json;

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
            return View("_BookingContainer", model);
        }

        [HttpPost]
        public ActionResult EditBookInfo(int clickedSeatId, string seatListJson, int transportId)
        {
            var seatList = JsonConvert.DeserializeObject<List<Ticket>>(seatListJson);
            var seatIds = seatList.Select(o => o.SeatId);
            var seatLabels = _bookService.GetSeats(seatIds).Select(o => o.Name);
            var transport = _transportService.GetById(transportId);
            var ticket = _bookService.GetTicket(clickedSeatId, transportId) ?? new Ticket();
            var paymentStatusOptions = new List<SelectListItem>
            {
                new SelectListItem {Value = ((int)PaymentStatusEnum.NotPaidYet).ToString(), Text = "Tài xế thu"},
                new SelectListItem {Value = ((int)PaymentStatusEnum.PaidAlready).ToString(), Text = "Tại văn phòng"},
                new SelectListItem {Value = ((int)PaymentStatusEnum.Free).ToString(), Text = "Không thu tiền"}
            };
            var pickUpAndGoOptions = new List<SelectListItem>
            {
                new SelectListItem {Value = ((int)PickUpAndGoEnum.TransitToStation).ToString(), Text = "Trung chuyển về trạm"},
                new SelectListItem {Value = ((int)PickUpAndGoEnum.PickUpAndGo).ToString(), Text = "Đón trên đường đi"}
            };
            var model = new BookEditViewModel
            {
                TransportId = transportId,
                SeatIds = string.Join(",", seatIds),
                SeatLabels = seatLabels.ToList(),
                PassengerId = ticket.PassengerId ?? 0,
                PassengerName = ticket.Passenger != null ? ticket.Passenger.PassengerName : "",
                PassengerPhoneNo = ticket.Passenger != null ? ticket.Passenger.PassengerPhoneNo : "",
                RunDate = transport.RunDate.ToString("dd/MM/yyyy"),
                RunTime = $"{transport.Hour:D2}" + ":" + $"{transport.Minute:D2}",
                PickUpLocationId = ticket.PickUpLocationId,
                PickUpLocation = ticket.PickUpLocation != null ? ticket.PickUpLocation.Address : "",
                IsPickUpAndGo = ticket.IsPickUpAndGo ? 1: 0,
                Note = ticket.Note,
                PaymentStatusOptions = paymentStatusOptions,
                PickUpAndGoOptions = pickUpAndGoOptions
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult DoEditBookInfo(BookEditViewModel model)
        {
            _bookService.UpdateBookInfo(model, User.UserId);
            return Content("");
        }

        [HttpPost]
        public ActionResult BookSeats(string seatListJson)
        {
            var seatList = JsonConvert.DeserializeObject<List<Ticket>>(seatListJson);
            _bookService.BookSeats(seatList, User.UserId);
            return Content("1");
        }
    }
}