using System;
using System.Linq;

namespace Mission7.Models
{
    public class EFBookRepository : IBookRepository
    {

      
        private BookstoreContext context { get; set; }

        public EFBookRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Books> Books => context.Books;
    }
}
