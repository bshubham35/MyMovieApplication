using MyMovieApp.Data.DataConnection;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public  class MovieBooking : IBooking
    {
        MovieDbContext _movieDbContext;

        public  MovieBooking(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public string AddBooking(BookingModel booking)
        {
            _movieDbContext.MovieBooking.Add(booking);
            _movieDbContext.SaveChanges();
            return "Booking Added Successfully..!!";
        }

        public List<BookingModel> bookingList()
        {
            return _movieDbContext.MovieBooking.ToList();
        }
    }
}
