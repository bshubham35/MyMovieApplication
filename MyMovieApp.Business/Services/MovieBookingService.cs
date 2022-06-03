using MyMovieApp.Data.Repository;
using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Business.Services
{
    public class MovieBookingService
    {
        IBooking _movieBooking;

        public MovieBookingService(IBooking movieBooking)
        {
            _movieBooking = movieBooking;
        }

        public string AddMovieBooking(BookingModel booking)
        {
            return _movieBooking.AddBooking(booking);
        }

        public List<BookingModel> ShowAllBookings()
        {
            return _movieBooking.bookingList();
        }
    }
}
