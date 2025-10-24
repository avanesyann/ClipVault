using ClipVault.Data;
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
    }
}
