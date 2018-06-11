using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LibraryService.Exceptions
{
    [DataContract]
    public class NoSuchBookException
    {
        [DataMember]
        String _message;

        [DataMember]
        public string Message { get => _message; set => _message = value; }

        public NoSuchBookException(String message)
        {
            this._message = message;
        }
    }
}

