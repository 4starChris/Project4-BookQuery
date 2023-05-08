/* Task
 * Write a console application that reads in a CSV file containing information about books and allows the user to search for books based on various criteria. Here are the basic requirements for this task:
 * 
 * Read in the CSV file using the File.ReadAllLines() method to create an array of strings, where each string represents a line in the file.
 * Use LINQ to parse the CSV data into a list of book objects. Each book object should have the following properties: title, author, publication year, and ISBN.
 * Allow the user to search for books by title, author, publication year, or ISBN. Display the search results to the user in the console.
 * Add the ability for the user to sort the search results by any of the book properties.
 * 
 * I am using the data provided by nanotaboada for this exercise: https://gist.github.com/nanotaboada/6396437
 */
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Project4_BookQuery;
class Program
{
    public static void Main(string[] args)
    {
        
        string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"BookJson.csv");
        string bookjson = File.ReadAllText(path);
        bool endapp = false;

        
        Func<Book, bool> searchby;
        string searchterm;
        Func<Book, string> sortby; //Old sorting method. It is meant to output a TKey, not a string. But the code doesn't recognise TKey, and I can't figure out what that is.------------------------------------

        while (!endapp)
        {
            //Console.WriteLine(bookjson);

            List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(bookjson);

            Console.WriteLine("Enter search term:");
            searchterm = Console.ReadLine();

            Console.WriteLine("Would you like to search by A:title, B: author, C: ISBN?");
            string response = Console.ReadLine().ToLower();

            //-------------------------------------------------------------------------
            //Filter out books that don't contain the search term
            //-------------------------------------------------------------------------
            if (response == "a")
            {
                searchby = s => s.title.Contains(searchterm);
            }
            else if (response == "b")
            {
                searchby = s => s.author.Contains(searchterm);
            }
            else if (response == "c")
            {
                searchby = s => s.isbn.Contains(searchterm);
            }
            else
            {
                Console.WriteLine("Please select a valid option!");
                continue;
            }



            Console.WriteLine("Sort by A: title, B: author, C: ISBN?");
            response = Console.ReadLine().ToLower();

            /* Old sorting attempt

            //-------------------------------------------------------------------------
            //I am trying to sort the LINQ query at the end based on the user response. 
            //-------------------------------------------------------------------------
            if (response == "a")
            {
                sortby = s => s.title;
            }
            else if (response == "b")
            {
                sortby = s => s.author;
            }
            else if (response == "c")
            {
                sortby = s => s.isbn;
            }
            else
            {
                Console.WriteLine("Please select a valid option!");
                continue;
            }

            */

            //Search here
            var searchResults = from book in bookList
                                //orderby sortby descending //Old sorting attempt
                                where searchby(book) 
                                select book;

            //-------------------------------------------------------------------------
            //Sort search result
            //-------------------------------------------------------------------------
            if (response == "a")
            {
                searchResults = searchResults.OrderBy(c => c.title);
            }
            else if (response == "b")
            {
                searchResults = searchResults.OrderBy(c => c.author);
            }
            else if (response == "c")
            {
                searchResults = searchResults.OrderBy(c => c.isbn);
            }
            else
            {
                Console.WriteLine("Please select a valid option!");
                continue;
            }

            //Print title of books in search
            foreach (Book book in searchResults)
            {
                Console.WriteLine(book.title);
            } 
            endapp = true;
        }
        
        

    }
}