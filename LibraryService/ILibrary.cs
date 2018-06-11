using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LibraryService
{
    [ServiceContract]
    public interface ILibrary
    {
        [OperationContract]
        List<BorrowedItem> ListOfBorrowedItems();

        [OperationContract]
        List<Book> GetBorrowedBooks(int userId);

        [OperationContract]
        [FaultContract(typeof(Exceptions.NoSuchBookException))]
        Book BookInfo(int bookId);

        [OperationContract]
        bool BorrowBook(int bookId, int userId);
    }
}
