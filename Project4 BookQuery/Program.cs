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
        Console.WriteLine(bookjson);
        
        List<Book> bookList = JsonConvert.DeserializeObject<List<Book>>(bookjson);


        //Search here
        var searchResults = from book in bookList where book.subtitle.Contains("and") select book;
        
        //Print title of books in search
        foreach (Book book in searchResults){
            Console.WriteLine(book.title);
        }
        

    }
}