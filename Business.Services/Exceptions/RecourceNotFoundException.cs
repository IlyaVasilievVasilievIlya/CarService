using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Exceptions
{
    public class RecourceNotFoundException : Exception
    {
        public RecourceNotFoundException() { }

        public RecourceNotFoundException(string message) : base(message) { }
    }
}
