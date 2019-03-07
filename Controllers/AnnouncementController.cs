using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Controllers
{
    public class AnnouncementController : Controller
    {
        public IHubContext<MessageHub> _hubContext;

        public AnnouncementController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        // GET: Announcement
        [HttpGet("/announcement")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/announcement")]
        
        public async Task<IActionResult> Post([FromForm] string message)
        {
            try
            {
                // TODO: Add insert logic here
                await _hubContext.Clients.All.SendAsync("RecieveMessage", message);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Announcement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Announcement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}