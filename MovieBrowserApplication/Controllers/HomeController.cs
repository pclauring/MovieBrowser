using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBrowserApplication.Models;
using System.Text.RegularExpressions;

namespace MovieBrowserApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            List<Movies> ListOfMovies = ORM.Movies.ToList();

            ViewBag.ListOfMovies = ListOfMovies;

            ViewBag.Categories = ORM.Movies.Select(x => x.Category).Distinct().ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListMoviesByCategory(string Category)
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            List<Movies> ListOfMovies = ORM.Movies.Where(x => x.Category == Category).ToList();

            ViewBag.ListOfMovies = ListOfMovies;
            ViewBag.Categories = ORM.Movies.Select(x => x.Category).Distinct().ToList();

            return View("Index");
        }

        public ActionResult SearchForMovieName(string MovieName)
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

                List<Movies> ListOfMovies = new List<Movies>();

            foreach (Movies m in ORM.Movies.ToList())
            {
                if (m.Name != null && Regex.IsMatch(m.Name, MovieName, RegexOptions.IgnoreCase))
                {
                    ListOfMovies.Add(m);
                }
            }

            ViewBag.ListOfMovies = ListOfMovies;

            ViewBag.Categories = ORM.Movies.Select(x => x.Category).Distinct().ToList(); 

            return View("Index");
        }

        public ActionResult RateMovie(string Name)
        {

            return View();
        }

    }
}