using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSiteDal;

namespace MovieSite.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieSiteContext _context;

        public MovieController(MovieSiteContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allmovies= await _context.Movies.ToListAsync();
            return View(allmovies);
        }

        public async Task<int> Like([FromBody] LikeDislikePostModel model)
        {
            var movie = await _context.Movies.FindAsync(model.FilmId);

            if (model.IsLike)
            {
                movie.LikeCount++;
            }
            else
            {
                movie.DislikeCount--;
            }
            await _context.SaveChangesAsync();

            return model.IsLike ? movie.LikeCount : movie.DislikeCount; 
        }
    }
}
