using MyMovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovieApp.Data.Repository
{
    public interface IBooking
    {
        string AddBooking(BookingModel booking);

        List<BookingModel> bookingList();
    }
}
