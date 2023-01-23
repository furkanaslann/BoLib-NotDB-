using Bolib.com.webui.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bolib.com.webui.Data
{
    public static class BookRepository
    {
        private static List<Book> _books = null;

        static BookRepository()
        {
            _books = new List<Book>
            {
                new Book {BookId=1586, BookName="Historical Place", Description="Blabla-1", Price=2.99, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog1.jpg", CategoryId=1001},
                new Book {BookId=2416, BookName="Historical Museum", Description="Blabla-2", Price=5.78, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog-1.jpg", CategoryId=1001},
                new Book {BookId=9681, BookName="Horror House", Description="Blabla-3", Price=5.78, IsApproved=false, ImageUrl="/Template/theme/images/blog/blog2.jpg", CategoryId=1001},
                new Book {BookId=1686, BookName="Historical Mosque", Description="Blabla-4", Price=3.78, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog3.jpg", CategoryId=1001},
                new Book {BookId=5209, BookName="Holiday Place", Description="Blabla-5", Price=2.29, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog1.jpg", CategoryId=1002},
                new Book {BookId=7913, BookName="Holiday Museum", Description="Blabla-6", Price=4.71, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog-1.jpg", CategoryId=1002},
                new Book {BookId=6358, BookName="Holiday Home", Description="Blabla-7", Price=2.38, IsApproved=false, ImageUrl="/Template/theme/images/blog/blog2.jpg", CategoryId=1002},
                new Book {BookId=1996, BookName="Holiday Mosque", Description="Blabla-8", Price=9.48, IsApproved=true, ImageUrl="/Template/theme/images/blog/blog3.jpg", CategoryId=1002}
            };
        }
        public static List<Book> Books
        {
            get
            {
                return _books;
            }
        }
        public static void AddBook(Book book, IFormFile file)
        {
            _books.Add(book);
        }
        public static Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.BookId == id);
        }

        public static void UpdateBook(Book book)
        {
            foreach (var p in _books)
            {
                if (p.BookId == book.BookId)
                {
                    p.BookName = book.BookName;
                    p.Price = book.Price;
                    p.Description = book.Description;
                    p.ImageUrl = book.ImageUrl;
                    p.IsApproved = book.IsApproved;
                    p.CategoryId = book.CategoryId;

                }
            }
        }
        public static void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book!=null)
            {
                _books.Remove(book);
            }
        }
    }
}
