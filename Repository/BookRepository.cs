using E_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.Repository
{
    public class BookRepository : Repository
    {
        private AppContext db;
        public BookRepository(AppContext context) { db = context; }

        /// <summary>
        /// выбор объекта из БД по его идентификатору
        /// </summary>
        /// <returns></returns>
        public List<Book> SelectBook(int id)
        {
            return db.Books.Where(book => book.Id == id).ToList();
        }

        /// <summary>
        /// выбор всех объектов
        /// </summary>
        /// <returns></returns>
        public List<Book> SelectAllBooks()
        {
            return db.Books.ToList();
        }

        /// <summary>
        /// добавление объекта в БД
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="ReleaseYear"></param>
        public void Add(string title, int releaseYear)
        {
            var book1 = new Book { Title = title, ReleaseYear = releaseYear };
            db.Books.Add(book1);
            db.SaveChanges();
        }

        /// <summary>
        /// удаление объекта из БД
        /// </summary>
        /// <param name="book"></param>
        public void Delete(Book book)
        {
            db.Books.Remove(book);
            db.SaveChanges();
        }

        /// <summary>
        /// обновление года выпуска книги (по Id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newYear"></param>
        public void UpdateYear(int id, int newYear)
        {
            SelectBook(id).First().ReleaseYear = newYear;
        }
    }
}
