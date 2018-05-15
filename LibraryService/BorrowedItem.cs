using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    [DataContract]
    public class BorrowedItem
    {
        private Book book;
        private DateTime borrowDate;
        private DateTime returnDate;
        private int userId;

        public BorrowedItem()
        {

        }

        public BorrowedItem(BorrowedItem b)
        {
            Book = b.Book;
            BorrowDate = b.BorrowDate;
            ReturnDate = b.ReturnDate;
            UserId = b.UserId;
        }

        [DataMember]
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        [DataMember]
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }
        [DataMember]
        public int UserId { get => userId; set => userId = value; }
        [DataMember]
        internal Book Book { get => book; set => book = value; }
    }
}
