﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVCWeb.Core.DtoForEntities;
using MVCWeb.Core.Entities;
using MVCWeb.Core.IRepositories;
using MVCWeb.Core.IServices;
using MVCWeb.Libraries;
using MVCWeb.Models;

namespace MVCWeb.Core.Services
{
    public class BookService : IBookService
    {
        private readonly ITransportRepository _transportRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IPassengerRepository _passengerRepository;
        public BookService(
            ITransportRepository transportRepository,
            ITicketRepository ticketRepository,
            ISeatRepository seatRepository,
            IPassengerRepository passengerRepository
            )
        {
            _transportRepository = transportRepository;
            _ticketRepository = ticketRepository;
            _seatRepository = seatRepository;
            _passengerRepository = passengerRepository;
        }

        public void UpdateBookInfo(BookEditViewModel model, int userId)
        {
            var seatIds = model.SeatIds.StringToIntList();
            var passengerId = model.PassengerId;
            if (passengerId <= 0)
            {
                passengerId = _passengerRepository.AddPassenger(model.PassengerName, model.PassengerPhoneNo);
            }
            seatIds.ForEach(seatId =>
            {
                var ticket = GetTicket(seatId, model.TransportId);
                if (ticket != null)
                {
                    ticket.PassengerId = passengerId;
                    ticket.IsPickUpAndGo = model.IsPickUpAndGo == 1;
                    ticket.PaymentStatusId = model.PaymentStatus;
                    ticket.Note = model.Note;
                    _ticketRepository.Update(ticket);
                }
                else
                {
                    ticket = new Ticket
                    {
                        PassengerId = passengerId,
                        IsPickUpAndGo = model.IsPickUpAndGo == 1,
                        PaymentStatusId = model.PaymentStatus,
                        Note = model.Note,
                        CreatedDate = DateTime.Now,
                        CreatedById = userId
                };
                    _ticketRepository.Insert(ticket);
                }
            });
        }

        public Ticket GetTicket(int seatId, int transportId)
        {
            return
                _ticketRepository.Table
                .Include(o => o.Passenger)
                .Include(o => o.PickUpLocation)
                .Include(o => o.CreatedBy)
                .FirstOrDefault(o => o.TransportId == transportId && o.SeatId == seatId);
        }

        public List<Seat> GetSeats(IEnumerable<int> seatIds)
        {
            return _seatRepository.TableNoTracking.Where(o => seatIds.Contains(o.Id)).ToList();
        } 

        public ICollection<SeatWithBookInfoDto> GetSeatWithBookInfos(int transportId)
        {
            var transport =
                _transportRepository.TableNoTracking
                    .Include(o => o.Coach)
                    .Include(o => o.Coach.CoachType)
                    .Include(o => o.Coach.CoachType.Seats)
                    .Include(o => o.Tickets.Select(b => b.Passenger))
                    .Include(o => o.Tickets.Select(b => b.PickUpLocation))
                    .Include(o => o.Tickets.Select(b => b.CreatedBy))
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
            var tickets = transport.Tickets;
            seatWithBookInfoDtos.ForEach(o =>
            {
                var ticket = tickets.FirstOrDefault(b => b.SeatId == o.SeatId);
                if (ticket != null)
                {
                    o.TicketId = ticket.Id;
                    o.IsBooked = true;
                    o.BookedByDisplayName = ticket.CreatedBy.DisplayName;
                    o.Note = ticket.Note;
                    if (ticket.Passenger != null)
                    {
                        o.PassengerId = ticket.PassengerId;
                        o.HasBookInfo = true;
                        o.PassengerName = ticket.Passenger.PassengerName;
                        o.PassengerPhoneNo = ticket.Passenger.PassengerPhoneNo;
                        o.NbOfSeats = tickets.Count(t => t.PassengerId == ticket.PassengerId);
                        o.Note = ticket.Note;
                        o.IsSticked = ticket.IsSticked;
                        o.PaymentStatusId = ticket.PaymentStatusId;
                    }
                    if (ticket.PickUpLocation != null)
                    {
                        o.HasBookInfo = true;
                        o.PickUpLocation = ticket.PickUpLocation.Address;
                        o.HouseNumber = ticket.HouseNumber;
                        o.IsPickUpAndGo = ticket.IsPickUpAndGo;
                    }
                }
            });
            return seatWithBookInfoDtos.ToList();
        }

        public int BookSeats(List<Ticket> tickets, int userId)
        {
            if (!tickets.Any()) return 0;
            var transportId = tickets.First().TransportId;
            var currentTickets = _ticketRepository.TableNoTracking.Where(o => o.TransportId == transportId && !o.IsCancelled);
            var newTickets = new List<Ticket>();
            tickets.ForEach(ticket =>
            {
                if (!currentTickets.Any(o => o.SeatId == ticket.SeatId))
                {
                    ticket.CreatedDate = DateTime.Now;
                    ticket.CreatedById = userId;
                    newTickets.Add(ticket);
                }
            });
            _ticketRepository.Insert(newTickets);
            return 1;
        }
    }
}