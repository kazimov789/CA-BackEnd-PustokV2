using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P328Pustok.DAL;
using P328Pustok.Models;
using P328Pustok.ViewModels;
using System.Diagnostics;

namespace P328Pustok.Controllers
{
    public class HomeController : Controller
    {
        private readonly PustokContext _context;

        public HomeController(PustokContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel
            {
                FeaturedBoooks = _context.Books.Include(x=>x.Author).Include(x=>x.BookImages).Where(x => x.IsFeatured).Take(10).ToList(),
                NewBoooks = _context.Books.Include("Author").Include(x => x.BookImages).Where(x => x.IsNew).Take(10).ToList(),
                DiscountedBoooks = _context.Books.Include(x=>x.Author).Include(x => x.BookImages).Where(x => x.DiscountPercent>0).Take(10).ToList(),
                Sliders = _context.Sliders.ToList()
                //bookımage = _context.bookımages.ınclude(x => x.ımages.ımgurl).tolist()
                //BookImage = _context.Images.ToList()
            };

            return View(vm);
        }
    }
}