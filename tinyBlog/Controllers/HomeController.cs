
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		private readonly UserManager<IdentityUser> _userManager;
		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([Bind("Content,Tags,Title,Visible")] Post post)
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
            
            /*Might use this to implement tag recommendations based on all the tags in the db*/
            ViewBag.AllTag = _context.Tags.Select(x=>x).ToList();
            return View(post);
        }
        public IActionResult BlogEntriesPartial()
        {
			List<Post> postList = _context.Posts.Include(x => x.Tags).Select(x => x).ToList();
			foreach (Post p in postList)
			{
				p.Author = _userManager.FindByIdAsync(p.Author).Result.Email;
			}
            postList = postList.OrderByDescending(p=>p.PublishDate).ToList();
            return PartialView("_BlogEntries", postList);
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