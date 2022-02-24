using System;
using System.Linq;

namespace Mission7.Models
{
    public interface IBookRepository
    {
        IQueryable<Books> Books { get; }
    }
}
