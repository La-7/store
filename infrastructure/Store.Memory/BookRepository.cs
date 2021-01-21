using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12345-32141", "D. Knuth", "Art Of Programming",
                "This volume begins with basic programming concepts and techniques, then focuses more particularly on information structures - the representation of information inside computer, the structural relationships between data elements and how to deal with them efficiently.", 7.19m),
            new Book(2, "ISBN 12345-32142", "M. Fowler", "Refactoring",
                "As the application of object technology--particulary the Java...", 12.45m),
            new Book(3, "ISBN 12345-32143", "B. Kernighan, D. Ritchie", "C Programming Language",
                "Know as the bible of C, this classic bestseller introduces...", 14.98m)
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

        public Book GetById(int id)
        {
            return books.Single(b => b.Id == id);
        }
    }
}
