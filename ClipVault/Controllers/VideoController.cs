using ClipVault.Data;
using ClipVault.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClipVault.Controllers
{
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var videos = _context.Videos.ToList();
            return View(videos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Video video)
        {
            if (ModelState.IsValid)
            {
                video.DateAdded = DateTime.Now;
                _context.Videos.Add(video);
                _context.SaveChanges();
                return RedirectToAction("Index", "Video");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            Video? video = _context.Videos.Find(id);

            if (video == null)
                return NotFound();

            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(Video obj)
        {
            if (ModelState.IsValid)
            {
                _context.Videos.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Video");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Video? video = _context.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            Video obj = _context.Videos.Find(id);
            if (obj == null)
                return NotFound();

            _context.Videos.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
