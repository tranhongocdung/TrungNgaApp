using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCWeb.Core.DtoForEntities;
using MVCWeb.Core.IRepositories;
using MVCWeb.Core.IServices;

namespace MVCWeb.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ITransportRepository _transportRepository;
        private readonly ITransportDirectionRepository _transportDirectionRepository;
        public BookService(
            IBookRepository bookRepository,
            ITransportRepository transportRepository,
            ITransportDirectionRepository transportDirectionRepository
            )
        {
            _bookRepository = bookRepository;
            _transportRepository = transportRepository;
            _transportDirectionRepository = transportDirectionRepository;
        }


        public ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId)
        {
            var transport =
                _transportRepository.TableNoTracking
                    .Include(o => o.Coach)
                    .Include(o => o.Coach.CoachType)
                    .Include(o => o.Coach.CoachType.Seats)
                    .Include(o => o.Books.Select(b => b.BookInfo))
                    .Include(o => o.Books.Select(b => b.CreatedBy))
                    .FirstOrDefault(o => o.Id == transportId);
            if (transport == null) return new List<SeatWithBookInfoDto>();
            var seatWithBookInfoDtos = transport.Coach.CoachType.Seats.Select(o => new SeatWithBookInfoDto
            {
                SeatId = o.Id,
                SeatLabel = o.Name,
                IsOnLeftSide = o.IsOnLeftSide,
                IsBooked = false,
                HasBookInfo = false
        }).ToList();
            var books = transport.Books;
            seatWithBookInfoDtos.ForEach(o =>
            {
                var book = books.FirstOrDefault(b => b.SeatId == o.SeatId);
                if (book != null)
                {
                    o.BookId = book.Id;
                    o.IsBooked = true;
                    o.BookedByDisplayName = book.CreatedBy.DisplayName;
                    if (book.BookInfo != null)
                    {
                        o.BookInfoId = book.BookInfoId;
                        o.HasBookInfo = true;
                        o.PassengerName = book.BookInfo.PassengerName;
                        o.PassengerPhoneNo = book.BookInfo.PassengerPhoneNo;
                        o.PickUpLocation = book.BookInfo.PickUpLocation;
                        o.PassengerName = book.BookInfo.PassengerName;
                        o.NbOfSeats = book.BookInfo.NbOfSeats;
                        o.Note = book.BookInfo.Note;
                        o.IsSticked = book.BookInfo.IsSticked;
                        o.PaymentStatusId = book.BookInfo.PaymentStatusId;
                    }
                }
            });
            return seatWithBookInfoDtos.ToList();
        }
    }
}