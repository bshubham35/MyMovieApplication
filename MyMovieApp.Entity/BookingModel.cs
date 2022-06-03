using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyMovieApp.Entity
{
    public class BookingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }
        public UserModel User { get; set; }


        [ForeignKey("movieModel")]
        public int MovieId { get; set; }
        public MovieModel movieModel { get; set; }

        //***************************
        [ForeignKey("thetreModel")]
        public int ThetreId { get; set; }
        public ThetreModel thetreModel { get; set; }

        //***************************       
        public string MovieShowTime { get; set; }

        public string MovieDate { get; set; }

        public int ticketCount { get; set; }
    }
}
