using aspnet.Models;

namespace aspnet.Repositories
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book b);
        void UpdateBook(Book b);
        void DeleteBook(Book b);
        void SaveChanges();
    }
}