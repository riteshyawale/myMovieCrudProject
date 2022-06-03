using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DataConnection;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class Booking : IBooking
    {
        MovieDBContext _movieDBContext;
        public Booking(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string DeleteBooking(int bid)
        {
             BookingModel booking = _movieDBContext.bookingModel.Find(bid);
            _movieDBContext.bookingModel.Remove(booking);
            _movieDBContext.SaveChanges();
             return "Booking Deleted!!!";
        }

        public BookingModel GetBooking(int bid)
        {
            return _movieDBContext.bookingModel.Find(bid);
        }

        public string InsertBooking(BookingModel model)
        {
            _movieDBContext.bookingModel.Add(model);
            _movieDBContext.SaveChanges();
            return "Inserted!!!";
        }

        public List<BookingModel> ShowBooking()
        {
            return _movieDBContext.bookingModel.ToList();
        }

        public string UpdateBooking(BookingModel model)
        {
            _movieDBContext.Entry(model).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Booking Updated";
        }
    }
    /* public class MovieShowTime : IMovieShowTime
     {
         MovieDBContext _movieDBContext;
         public MovieShowTime(MovieDBContext movieDBContext)
         {
             _movieDBContext = movieDBContext;
         }

         public string DeletemovieShowTime(int ShowId)
         {
             string msg = "";
             MovieShowTimeModel movieShowTimeModel = _movieDBContext.movieShowTimeModel.Find(ShowId);
             _movieDBContext.movieShowTimeModel.Remove(movieShowTimeModel);
             _movieDBContext.SaveChanges();
             msg = "MovieShowTime Deleted!!!";
             return msg;
         }

         public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
         {
             _movieDBContext.movieShowTimeModel.Add(movieShowTimeModel);
             _movieDBContext.SaveChanges();
             return "Inserted";
         }

         public List<MovieShowTimeModel> ShowMovieTime()
         {
             return _movieDBContext.movieShowTimeModel.ToList();
         }

         public MovieShowTimeModel GetSpecificMovieShowTimeById(int ShowId)
         {
             return _movieDBContext.movieShowTimeModel.Find(ShowId);

         }

         public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
         {
             string msg = "";
             _movieDBContext.Entry(movieShowTimeModel).State = EntityState.Modified;
             _movieDBContext.SaveChanges();
             msg = "MovieShowTime Updated";
             return msg;
         }
     }*/
}
