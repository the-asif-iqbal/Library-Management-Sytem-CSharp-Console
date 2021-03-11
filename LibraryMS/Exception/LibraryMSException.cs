using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS.Exception
{
    public class LibraryMSException:ApplicationException
    {
        //CUSTOM EXCEPTION HANDLING METHODS
        public LibraryMSException() : base()
        {

        }
        public LibraryMSException(string message) : base(message)
        {

        }
        public LibraryMSException(string msg, FormatException InneException) : base(msg, InneException)
        {

        }
    }
}
