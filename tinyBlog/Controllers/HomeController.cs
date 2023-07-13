using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using tinyBlog.Data;
using tinyBlog.Models;

namespace tinyBlog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> CreatePost(Post post)
        {
            post.Author = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            post.PublishDate = DateTime.Now;
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            Post post = new Post();
            ViewBag.AllPosts = _context.Posts.Select(x=>x).ToList();
            return View(post);
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}