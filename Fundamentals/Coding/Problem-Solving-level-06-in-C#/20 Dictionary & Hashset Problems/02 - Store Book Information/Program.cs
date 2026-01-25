/*
Store Book Information
Problem: Store information about books (Title, Author) using their ISBN as the key.

Note: Use Dictionary and Tuple.

Output:

ISBN: 978-3-16-148410-0, Title: The Great Gatsby, Author: F. Scott Fitzgerald

ISBN: 978-1-61-729494-5, Title: C# in Depth, Author: Jon Skeet
*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, (string Title, string Author)> bookInfo = new Dictionary<string, (string Title, string Author)>
        {
            { "978-3-16-148410-0", ("The Great Gatsby", "F. Scott Fitzgerald") },
            { "978-1-61-729494-5", ("C# in Depth", "Jon Skeet") }
        };
        
        foreach (var isbn in bookInfo.Keys)
        {
            var book = bookInfo[isbn];
            Console.WriteLine($"ISBN: {isbn}, Title: {book.Title}, Author: {book.Author}");
        }
    }
}

