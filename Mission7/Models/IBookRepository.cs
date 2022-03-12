using System;
using System.Linq;

namespace Mission7.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);

    }
}
