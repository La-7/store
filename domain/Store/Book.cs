﻿using System;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }

        public Book(string title)
        {
            Title = title;
        }
    }
}
