using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using Mission7.Models.ViewModels;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController (IBookRepository temp)
        {
            repo = temp;
        }

        //private BookstoreContext context { get; set; }

        //public HomeController (BookstoreContext temp)
        //{
        //    context = temp;
        //}

        public IActionResult Index(string projectType, int pageNum = 1)
        {
            int pageSize = 10;


            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == projectType || projectType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (projectType == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == projectType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };

            return View(x);
        }

    }
}
