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
    public class HomeController:Controller
    {
        //localhost:4343/home
        public IActionResult index()
        {
            var bookViewModel = new BookViewModel()
            {
                Books = BookRepository.Books
            };
            return View(bookViewModel);
        }
        public IActionResult about()
        {
            return View();
        }
    }
}
