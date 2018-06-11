using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LibraryService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Library : ILibrary
    {
        private List<Book> books = new List<Book>( new Book[] { new Book(1, "Pan Tadeusz"), new Book(2, "Potop"), new Book(3, "Ferdydurke"), new Book(4, "Krzyżacy"), new Book(5, "Chłopi") } );
        private List<BorrowedItem> borrowedItems = new List<BorrowedItem>();

        [OperationBehavior]
        public Book BookInfo(int bookId)
        {
            foreach(Book book in books)
            {
                if ( book.Id == bookId )
                {
                    return book;
                }
            }

            throw new FaultException<Exceptions.NoSuchBookException>(new Exceptions.NoSuchBookException("No such book!"));
        }

        [OperationBehavior]
        public bool BorrowBook(int bookId, int userId)
        {
            Book book = BookInfo(bookId);
            foreach(BorrowedItem item in borrowedItems)
            {
                if ( item.Book.Id == bookId )
                {
                    return false;
                }
            }

            BorrowedItem borrowed = new BorrowedItem();
            borrowed.Book = book;
            borrowed.BorrowDate = DateTime.Now;
            borrowed.ReturnDate = borrowed.BorrowDate.AddMonths(3);
            borrowed.UserId = userId;

            borrowedItems.Add(borrowed);

            return true;
        }
        [OperationBehavior]
        public List<Book> GetBorrowedBooks(int userId)
        {
            List<Book> userBooks = new List<Book>();

            foreach(BorrowedItem book in borrowedItems)
            {
                if ( book.UserId == userId )
                {
                    userBooks.Add(book.Book);
                }
            }

            return userBooks;
        }

        [OperationBehavior]
        public List<BorrowedItem> ListOfBorrowedItems()
        {
            return borrowedItems;
        }
    }
}
