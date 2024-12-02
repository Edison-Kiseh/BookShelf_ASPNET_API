using aspnet.Contexts;
using aspnet.Models;

namespace aspnet.Repositories
{
    public class MySQLRepo : IBookRepo
    {

        private readonly BookContext _bookContext;

        public MySQLRepo(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookContext.Books;
        }

        public Book GetBookById(int id)
        {
            return _bookContext.Books.FirstOrDefault<Book>(b => b.Id == id);
        }

        public void AddBook(Book b) {
            _bookContext.Books.Add(b);
        }

        public void SaveChanges()
        {
            _bookContext.SaveChanges();
        }

        public void UpdateBook(Book b)
        {
            
        }

        public void DeleteBook(Book b)
        {
            _bookContext.Books.Remove(b);
        }
    }
}