using System;

namespace MyLib
{
    public class MyLibraryException : Exception
    {
        public MyLibraryException()
        { }

        public MyLibraryException(string message)
            : base(message)
        { }

        public MyLibraryException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}