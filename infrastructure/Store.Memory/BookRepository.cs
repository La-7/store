using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12345-32141", "D. Knuth", "Art Of Programming"),
            new Book(2, "ISBN 12345-32142", "M. Fowler", "Refactoring"),
            new Book(3, "ISBN 12345-32143", "B. Kernighan, D. Ritchie", "C Programming Language")
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(b => b.Isbn == isbn)
                        .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(b => b.Title.Contains(query)
                                 || b.Author.Contains(query))
                        .ToArray();
        }
    }
}
