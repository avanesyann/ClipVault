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
        public IActionResult Index(List<string> tags, string search)
        {
            var videos = _context.Videos.AsQueryable();

            // 🔍 Filter by search
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                videos = videos.Where(v =>
                    v.Title.ToLower().Contains(search) ||
                    v.Description.ToLower().Contains(search));
            }

            // 🏷️ Filter by tags (ALL selected tags must match)
            if (tags != null && tags.Any())
            {
                videos = videos.Where(v => tags.All(tag => v.Tags.Contains(tag)));
            }

            var result = videos.ToList();

            ViewBag.Tags = _context.Videos
                .SelectMany(v => v.Tags)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            ViewBag.SelectedTags = tags ?? new List<string>();
            ViewBag.Search = search;

            return View(result);
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
