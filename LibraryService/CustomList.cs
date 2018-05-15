using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    [DataContract]
    class CustomList<T> : List<T>
    {
        
    }
}
