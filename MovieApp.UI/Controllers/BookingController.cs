using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyMovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class BookingController : Controller
    {
        IConfiguration _configuration;

        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int MyProperty { get; set; }

        [HttpGet]
        public async Task<IActionResult> AddBooking()
        {
            List<ThetreModel> thetreModel = null;
            List<MovieModel> movieModel = null;
            List<ShowMovieTime> list = null;
            
            

            // Get All Thetre List
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Thetre/selectThetre";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        thetreModel = JsonConvert.DeserializeObject<List<ThetreModel>>(data);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in thetreModel)
                        {
                            SelectListItem selectListThetreItem = new SelectListItem();
                            selectListThetreItem.Text = item.ThetreName;
                            selectListThetreItem.Value = item.ThetreId.ToString();
                            selectListItemsTheatre.Add(selectListThetreItem);
                            ViewBag.thetreList = selectListItemsTheatre;
                        }
                    }
                }
            }

            //Get All Movie List
            using (HttpClient client = new HttpClient())
            {
                string endpint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endpint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(data);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieModel)
                        {
                            SelectListItem selectListMovieItem = new SelectListItem();
                            selectListMovieItem.Text = item.MovieTitle;
                            selectListMovieItem.Value = item.MovieId.ToString();
                            selectListItemsMovies.Add(selectListMovieItem);
                            ViewBag.movieList = selectListItemsMovies;
                        }

                    }
                }
            }

            //Get All MovieShow List
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "MovieTime/ShowAllMovieTime";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<ShowMovieTime>>(data);
                    }
                }
            }

           // List<ShowMovieTime> modifiedMovieTimeList = from item in list where(x=>x.MovieId==  && x.ThetreId== );

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingModel booking)
        {
            StringContent body = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
            string URL = _configuration["WebApiURL"] + "Booking/addbooking";
            using(HttpClient client = new HttpClient())
            {
                using(var response=await client.PostAsync(URL,body))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowAllBookings", "Booking");
                    }
                    else
                    {
                        ViewBag.status = "error";
                        ViewBag.message = "Sorry.. Unable To Book Movie";
                    }
                }
            }
            return RedirectToAction("ShowAllBookings", "Booking");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllBookings()
        {

            string URL = _configuration["WebApiURL"] + "booking/allbookings";
            using(HttpClient httpClient = new HttpClient())
            {
                using(var response= await httpClient.GetAsync(URL))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        var data=await response.Content.ReadAsStringAsync();
                        List<BookingModel> bookings = JsonConvert.DeserializeObject<List<BookingModel>>(data);
                        return View(bookings);
                    }
                }
            }
            return View();
        }
    }
}
