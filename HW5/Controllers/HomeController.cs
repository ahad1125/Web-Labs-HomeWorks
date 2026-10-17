using HW5.Models;
using HW5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {

        private static List<Author> authors = new List<Author>
    {
        new Author { Id = 1, Name = "Robert Martin", Country = "USA" },
        new Author { Id = 2, Name = "J.K. Rowling", Country = "UK" }
    };

        private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "Clean Code", Price = 1200, AuthorId = 1 },
        new Book { Id = 2, Title = "Clean Architecture", Price = 1500, AuthorId = 1 },
        new Book { Id = 3, Title = "Harry Potter", Price = 1800, AuthorId = 2 }
    };
        public IActionResult Index()
        {
            var bookCards = books.Select(b => new BookCardViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Price = b.Price,
                AuthorName = authors.FirstOrDefault(a => a.Id == b.AuthorId)?.Name
            }).ToList();

            var model = new HomeViewModel
            {
                Books = bookCards,
                Authors = authors
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBook(string title, decimal price, int authorId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return RedirectToAction("Index");
            }

            int newId = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;

            books.Add(new Book
            {
                Id = newId,
                Title = title,
                Price = price,
                AuthorId = authorId
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction("Index");
            }

            int newId = authors.Count == 0 ? 1 : authors.Max(a => a.Id) + 1;

            authors.Add(new Author
            {
                Id = newId,
                Name = name,
                Country = country
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
