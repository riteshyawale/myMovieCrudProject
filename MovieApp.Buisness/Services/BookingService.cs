using MovieApp.Data.Repositories;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Business.Services
{
    public class BookingService
    {
        IBooking _booking;
        public BookingService(IBooking booking)
        {
            _booking = booking;
        }

        public string DeleteBooking(int bookingid)
        {
            return _booking.DeleteBooking(bookingid);
        }

        public string InsertBooking(BookingModel model)
        {
            return _booking.InsertBooking(model);
        }

        public List<BookingModel> ShowBooking()
        {
            return _booking.ShowBooking();
        }

        public string UpdateBooking(BookingModel model)
        {
            return _booking.UpdateBooking(model);
        }
         public BookingModel GetBooking(int bid)
        {
            return _booking.GetBooking(bid);
        }
    }
}
