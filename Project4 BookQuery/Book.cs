using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_BookQuery
{
    public class Book
    {
        public string isbn;
        public string title;
        public string subtitle;
        public string author;
        public DateTime date;
        public string publisher;
        public int pages;
        public string description;
        public string website;

        public Book(string isbn, string title, string subtitle, string author, DateTime date, string publisher, int pages, string description, string website)
        {
            this.isbn = isbn;
            this.title = title;
            this.subtitle = subtitle;
            this.author = author;
            this.date = date;
            this.publisher = publisher;
            this.pages = pages;
            this.description = description;
            this.website = website;
        }

    }
}
