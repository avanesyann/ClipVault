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
        public IActionResult Index(string tag, string search)
        {
            IEnumerable<Video> videos;

            // Filter by tag (your existing code)
            if (!string.IsNullOrEmpty(tag))
            {
                tag = tag.ToLower();
                videos = _context.Videos
                    .Where(v => v.Tags.Any(t => t.ToLower() == tag));
            }
            else
            {
                videos = _context.Videos;
            }

            // Additional filter: Search by title or description
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                videos = videos.Where(v =>
                    v.Title.ToLower().Contains(search) ||
                    v.Description.ToLower().Contains(search));
            }

            videos = videos.ToList();

            ViewBag.Tags = _context.Videos
                .SelectMany(v => v.Tags)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            ViewBag.SelectedTag = tag;
            ViewBag.Search = search;

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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Video? video = _context.Videos.Find(id);

            if (video == null)
                return NotFound();

            ViewBag.TagsString = string.Join(", ", video.Tags ?? new List<string>());
            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(Video obj, string TagsString)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(TagsString))
                    obj.Tags = TagsString.Split(',').Select(t => t.Trim()).ToList();

                _context.Videos.Update(obj);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Video");
        }

        public IActionResult Delete(int? id)
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
            Video? obj = _context.Videos.Find(id);
            if (obj == null)
                return NotFound();

            _context.Videos.Remove(obj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var video = _context.Videos.FirstOrDefault(v => v.Id == id);
            if (video == null)
                return NotFound();

            return View(video);
        }
    }
}
