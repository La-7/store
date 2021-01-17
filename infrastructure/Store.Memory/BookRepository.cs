﻿using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art Of Programming"),
            new Book(2, "Refactoring"),
            new Book(3, "C Programming Language")
        };

        public Book[] GetAllByTitle(string partOfTitle)
        {
            return books.Where(b => b.Title.Contains(partOfTitle))
                        .ToArray();
        }
    }
}
