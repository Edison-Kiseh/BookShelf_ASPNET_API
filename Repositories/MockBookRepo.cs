using aspnet.Models;

namespace aspnet.Repositories
{
    public class MockBookRepository : IBookRepo
    {
        List<Book> books = new List<Book>();
        public MockBookRepository(){
            books.Add(new Book(){       
                    Id = 1,             
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "The Great Gatsby",
                    Description = "A novel about the mysterious millionaire Jay Gatsby and his obsession with Daisy Buchanan, set in the Jazz Age.",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Classic",
                    ISBN = "978-0743273565",
                    PublicationDate = new DateTime(1925, 4, 10)});

            books.Add(new Book(){
                    Id = 2, 
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "To Kill a Mockingbird",
                    Description = "A powerful tale of racial injustice and moral growth in the American South.",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    ISBN = "978-0061120084",
                    PublicationDate = new DateTime(1960, 7, 11)
            });

            books.Add(new Book(){
                    Id = 3, 
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "1984",
                    Description = "A dystopian novel about totalitarianism, surveillance, and the suppression of individuality.",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    ISBN = "978-0451524935",
                    PublicationDate = new DateTime(1949, 6, 8)
            });

            books.Add(new Book(){
                    Id = 4, 
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "Pride and Prejudice",
                    Description = "A classic romantic tale about Elizabeth Bennet and Mr. Darcy navigating love and societal expectations.",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    ISBN = "978-1503290563",
                    PublicationDate = new DateTime(1813, 1, 28)
            });
        }

        public void AddBook(Book b) {
            books.Add(b);
        }

        public void DeleteBook(Book b)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks() {
            return books;
        }

        public Book GetBookById(int id) {
            Book _book = books.FirstOrDefault<Book>(t => t.Id == id);
            return _book;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
