using Bolib.com.webui.Data;
using Bolib.com.webui.Models;
using Bolib.com.webui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolib.com.webui.Controllers
{
    public class BookController:Controller
    {
        public IActionResult index()
        {
            var book = new Book { BookName = "Book 1", Description = "nam nam", Price = 5.74, IsApproved = true };
            //ViewBag.Category = "All Category";
            return View(book);
        }
        public IActionResult delete()
        {
            return View();
        }
        public IActionResult list(int? id, string q)
        {
            //    Console.WriteLine(RouteData.Values["Controller"]);
            //    Console.WriteLine(RouteData.Values["Action"]);
            //    Console.WriteLine(RouteData.Values["id"]);

            var books = BookRepository.Books;
            if (id!=null)
            {
                books = books.Where(b => b.CategoryId == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                books = books.Where(i => i.BookName.ToLower().Contains(q.ToLower())).ToList();
            }
            var bookViewModel = new BookViewModel()
            {
                Books = books
            }; 
            return View(bookViewModel);
        }
        public IActionResult details(int id)
        {
            return View(BookRepository.GetBookById(id));
        }
    }
}
