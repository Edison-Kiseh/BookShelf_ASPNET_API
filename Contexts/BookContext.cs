using aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Contexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}