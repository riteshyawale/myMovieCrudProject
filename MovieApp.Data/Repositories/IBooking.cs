using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public interface IBooking
    {
        string InsertBooking(BookingModel model);
        List<BookingModel> ShowBooking();

        string UpdateBooking(BookingModel model);

        string DeleteBooking(int bookingid);

        BookingModel GetBooking(int bid);
    }
}
