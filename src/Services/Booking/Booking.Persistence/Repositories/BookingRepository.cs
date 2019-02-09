﻿using System.Threading.Tasks;
using Booking.Application.Booking;
using Booking.Domain.Entities;

namespace Booking.Persistence.Repositories
{
    public class BookingRepository : IBookingRespository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<BookingOrder> AddAsync(BookingOrder bookingOrder)
        {
            _context.Set<BookingOrder>().Add(bookingOrder);
            await _context.SaveChangesAsync();

            return bookingOrder;
        }

        public async Task<BookingOrder> UpdateAsync(BookingOrder bookingOrder)
        {
            bookingOrder =  await _context.Bookings.FindAsync(bookingOrder.BookingOrderId);
            if (bookingOrder == null)
            {
                return bookingOrder;
            }
            _context.Entry(bookingOrder).CurrentValues.SetValues(bookingOrder);

            return bookingOrder;
        }

        public async Task<BookingOrder> FindByIdAsync(string bookingOrderId)
        {
            var bookingOrder = await _context.Bookings.FindAsync(bookingOrderId);

            if (bookingOrder != null)
            {
                await _context.Entry(bookingOrder)
                   .Collection(i => i.BookingDetails).LoadAsync();
            }

            return bookingOrder;
        }

       
    }
}