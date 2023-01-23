using Bolib.com.webui.Data;
using Bolib.com.webui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bolib.com.webui.Controllers
{
    public class AdminController:Controller
    {
        [HttpGet]
        public IActionResult a_create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "CategoryName");
            return View(new Book());
        }
        [HttpPost]
        public async Task<IActionResult> a_create(Book b, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randName = string.Format($"{DateTime.Now.Ticks}{extention}");
                    b.ImageUrl = randName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "www\\img", randName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return RedirectToAction("list", "book");
            }
            return View(b);
        }
        [HttpGet]
        public IActionResult a_update(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.Categories, "CategoryId", "CategoryName");
            return View(BookRepository.GetBookById(id));
        }
        [HttpPost]
        public IActionResult a_update(Book b)
        {
            BookRepository.UpdateBook(b);
            return RedirectToAction("list", "book");
        }
        [HttpPost]
        public IActionResult delete(int BookId)
        {
            BookRepository.DeleteBook(BookId);
            return RedirectToAction("list", "book");
        }
    }
}
