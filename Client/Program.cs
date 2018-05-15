using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryClient libraryClient = new LibraryClient();

            Book book = libraryClient.BookInfo(1);

            Console.WriteLine("BookId: " + book.Id + ", Title: " + book.Title);

            int userId = 1;
            for (int i = 0; i < 2; i++)
            {
                if (libraryClient.BorrowBook(1, userId))
                {
                    Console.WriteLine("Book has been borrowed.");
                }
                else
                {
                    Console.WriteLine("Book is not available!");
                }
            }
              
            Console.WriteLine("Borrowed items:");
            foreach(BorrowedItem item in libraryClient.ListOfBorrowedItems())
            {
                Console.WriteLine("Borrowed by: " + item.UserId + ", Book Id:" + item.Book.Id + ", Title: " + item.Book.Title + ", borrow date: " + item.BorrowDate + ", retun date: " + item.ReturnDate);
            }

            Console.WriteLine("Borrowed books by userID = " + userId);

            foreach(Book b in libraryClient.GetBorrowedBooks(userId))
            {
                Console.WriteLine("Title: " + b.Title + ", Id: " + b.Id);
            }

            Console.ReadKey();
        }
    }
}
