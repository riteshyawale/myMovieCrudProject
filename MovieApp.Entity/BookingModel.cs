using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieApp.Entity
{
    public class BookingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int bookingid { get; set; }
        [Required(ErrorMessage ="Seats are required")]
        public int seats { get; set; }
        [ForeignKey("movieShowTimeModel")]
        public int showTimeModelId { get; set; }
        public MovieShowTimeModel movieShowTimeModel { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double price { get; set; }
             
    }
}
