using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMUG.Data;
using NMUG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using NMUG.Helpers;
using NMUG.Services;
using Tweetinvi;
using Microsoft.Extensions.Options;

namespace NMUG.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        private TwitterAuthAPI _params;

        public MeetingsController(ApplicationDbContext context,  IHostingEnvironment environment, IOptions<TwitterAuthAPI> butter)
        {
            _context = context;
            _environment = environment;
            _params = butter.Value;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meeting.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //Removed Id from Bind - MB 7/22
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingDate,MeetingDescription,MeetingLocation,MeetingPresenter,MeetingStartTime,MeetingEndTime")] Meeting meeting, ICollection<IFormFile> files, TwitterAuthAPI _params)
        {

            if (ModelState.IsValid)
            {

                if (files != null)
                {
                    await Helpers.Upload.UploadFile(files, _environment);
                    meeting.FileName = Helpers.Upload.UploadFile(files);

                }

                _context.Add(meeting);

                TweetSender tweetMeeting = new TweetSender(_params);
                var tweet = meeting.MeetingDescription
                        + " at " + meeting.MeetingLocation
                        + " on " + meeting.MeetingDate.ToString("D")
                        + " at " + meeting.MeetingStartTime;

                tweetMeeting.PostTwitter(tweet);



                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingDate,MeetingDescription,MeetingLocation,MeetingPresenter,MeetingStartTime,MeetingEndTime")] Meeting meeting, ICollection<IFormFile> files)
        {

            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               try
                {
                    if (files != null)

                        { 
                         await Helpers.Upload.UploadFile(files, _environment);
                         meeting.FileName = Helpers.Upload.UploadFile(files);
                        }

                    _context.Update(meeting);

                    TweetSender tweetMeeting = new TweetSender(_params);
                    var updateTweet = "UPDATE:" 
                        + meeting.MeetingDescription 
                        + " at " + meeting.MeetingLocation 
                        + " on " + meeting.MeetingDate.ToString("D")
                        + " at " + meeting.MeetingStartTime;

                    tweetMeeting.PostTwitter(updateTweet);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.Id == id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.Id == id);
        }
    }
}
