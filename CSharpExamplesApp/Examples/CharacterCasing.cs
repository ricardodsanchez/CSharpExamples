using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpApp.Examples
{
    public class CharacterCasing
    {
        public CharacterCasing()
        {
            var books = new List<Book>()
            {
               new Book { Name = "Programa en donde sea", Author = "Ricardo" },
               new Book { Name = "Empieza a programar", Author = "ricardo" },
               new Book { Name = "Xyz", Author = "Joe" },
               new Book { Name = "Despues de la programacion", Author = "RICARDO" },
               new Book { Name = "Blah", Author = "Foo" }
            };

            // This groups the book list by name, it returns 5 items
            // Since it's case-sensitive, it treats all 'Author' names as unique values
            var notAUniqueListOfBooks = books.GroupBy(b => b.Author);

            // This groups the book list by name, it returns three items
            // It returns a list with unique values since it uses the StringComparer parameter to specify the string comparison rules 
            var aUniqueListOfBooks = books.GroupBy(b => b.Author, StringComparer.OrdinalIgnoreCase);

            // It creates a Dictionary with the 'Author' as the Key, and the 'Name' as the Value, it returns five items
            // Since it's case-sensitive, it treats all 'Author' names as unique values
            var notAUniqueBookDictionary = books.ToDictionary(b => b.Author, b => b.Name);

            // It fails to create a Dictionary with the 'Author' as the Key, and the 'Name' as the Value
            // Since it uses the StringComparer parameter to specify the string comparison rules,
            // Uncomment the line below to see the code throw an error when it finds duplicate key values by ignoring the casing
            // var aUniqueBookDictionary = books.ToDictionary(b => b.Author, b => b, StringComparer.OrdinalIgnoreCase);

            // It creates a Lookup with the 'Author' as the Key, and a List<Book> as the value, it returns three items
            var aUniqueLookup = books.ToLookup(b => b.Author, b => b, StringComparer.OrdinalIgnoreCase);

            // Write the item count of each object above to see the difference
            Console.WriteLine($"notAUniqueListOfBooks has {notAUniqueListOfBooks.Count()} items.");
            Console.WriteLine($"aUniqueListOfBooks has {aUniqueListOfBooks.Count()} items.");
            Console.WriteLine($"notAUniqueBookDictionary has {notAUniqueBookDictionary.Count()} items.");
            Console.WriteLine($"aUniqueLookup has {aUniqueLookup.Count()} items.");
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
