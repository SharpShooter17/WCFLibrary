using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    [DataContract]
    public class Book
    {
        private string title;
        private int id;

        public Book(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public Book(Book b)
        {
            Title = b.Title;
            Id = b.id;
        }

        [DataMember]
        public string Title { get => title; set => title = value; }
        [DataMember]
        public int Id { get => id; set => id = value; }
    }
}
