using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Exceptions
{
    public class NoSuchBookException : Exception
    {
        public NoSuchBookException() : base("No such book in library.")
        {
        }
    }
}
