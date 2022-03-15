using System;

namespace Business.Services.Exceptions
{
    public class RecourceAlreadyExistsException : Exception
    {
        public RecourceAlreadyExistsException() {  }

        public RecourceAlreadyExistsException(string message) : base(message)  { }
    }
}
