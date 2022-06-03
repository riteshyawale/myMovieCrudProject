using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class BookingController : Controller
    {
        IConfiguration _configuration;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowBookings()
        {
            using(HttpClient client=new HttpClient())
            {
                string endp = _configuration["WebApiURL"] + "Booking/ShowBooking";
                using(var response =await client.GetAsync(endp))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookings = JsonConvert.DeserializeObject<List<BookingModel>>(result);
                        return View(bookings);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> InsertBookings()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/SelectMovieShowTime";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimeModel = JsonConvert.DeserializeObject<List<MovieShowTimeModel>>(result);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieShowTimeModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.ShowTime; 
                            
                            selectListItem.Value = item.ShowId.ToString();
                            selectListItemsMovies.Add(selectListItem);
                            ViewBag.movieTimeData = selectListItemsMovies;
                        }
                    }
                }
            }

            return View();
        }
        [HttpPost]

        public async Task<IActionResult> InsertBookings(BookingModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Booking/InsertBooking";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted!";
                        return RedirectToAction("ShowBookings", "Booking");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }

            return View();
        }

        /*string InsertBooking(BookingModel model);
        List<BookingModel> ShowBooking();

        string UpdateBooking(BookingModel model);

        string DeleteBooking(int bookingid);*/
        /*   BookingModel GetBooking(int bid);*/
        
        public async Task<IActionResult> UpdateBookings(int bookingid)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Booking/GetBooking?id="+ bookingid;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookings = JsonConvert.DeserializeObject<BookingModel>(result);

                        return View(bookings);
                        
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBookings(BookingModel model)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "Booking/UpdateBooking";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Booking-Updated-Successfuly!!";
                        return RedirectToAction("ShowBookings", "Booking");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteBookings(int bookingid)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Booking/GetBooking?id=" + bookingid;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var bookings = JsonConvert.DeserializeObject<BookingModel>(result);

                        return View(bookings);

                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> DeleteBookings(BookingModel model)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiURL"] + "Booking/DeleteBooking?id=" + model.bookingid;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Delete-Updated-Successfuly!!";
                        return RedirectToAction("ShowBookings", "Booking");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                        
                    }
                }
            }
            return View();
        }
    }
}
