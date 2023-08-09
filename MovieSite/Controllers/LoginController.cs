using Microsoft.AspNetCore.Mvc;
using MovieSiteDal;

namespace MovieSite.Controllers
{
    public class LoginController : Controller
    {
        private readonly MovieSiteContext _context;

        public LoginController(MovieSiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromForm] LoginPostModel model)
        {
            var user = _context.Users.SingleOrDefault(x=> x.Email==model.Email && x.Password==model.Password);
            if (user != null)
            {
                return RedirectToAction("Index","Movie");
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalıdır.";
            }
            return View();
        }
    }
}
