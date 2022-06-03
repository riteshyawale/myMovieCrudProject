using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingservice;
        public BookingController(BookingService bookingService)
        {
            _bookingservice = bookingService;
        }
        [HttpGet("ShowBooking")]
        public IActionResult ShowBooking()
        {
            return Ok(_bookingservice.ShowBooking());
        }

        [HttpPost("InsertBooking")]
        public IActionResult InsertBooking(BookingModel model)
        {
            return Ok(_bookingservice.InsertBooking(model));
        }

        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int id)
        {
            return Ok(_bookingservice.DeleteBooking(id));
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(BookingModel model)
        {
            return Ok(_bookingservice.UpdateBooking(model));
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            return Ok(_bookingservice.GetBooking(id));
        }

    }
}
