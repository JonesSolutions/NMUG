using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace NMUG.Controllers
{
    public class MeetupController : Controller
    {

        //this is a property of the meetup controller, not a variable so no readonly
        private Models.MeetupAPIAuthToken _meetupauthtoken { get; }

        // injected meetupauthtoken into controller, now all methods in controller can access values in model
        public MeetupController(IOptions<Models.MeetupAPIAuthToken> meetupauthtoken)
        {
            _meetupauthtoken = meetupauthtoken.Value;
        }


        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var queryString = Uri.EscapeUriString(String.Format("events?key={0}&group_urlname={1}&sign=true", _meetupauthtoken.MeetupAPIKey, _meetupauthtoken.MeetupGroup));
            client.BaseAddress = new System.UriBuilder(_meetupauthtoken.MeetupBaseURL + queryString).Uri;
            client.DefaultRequestHeaders.Accept.Clear();


            var response = await client.GetAsync(client.BaseAddress);

            var responseString = await response.Content.ReadAsStringAsync();

            var searchResults = JsonConvert.DeserializeObject<Models.MeetupAPIResponse>(responseString);

            return View(searchResults);
        }



        // MODIFY this beyotch to create events on Meetup

        //public async Task<IActionResult> Create()
        //{

        // GET: MeetupAPIAuthToken/Create
        public IActionResult Create()
        {
            return View();
        }





    }
}