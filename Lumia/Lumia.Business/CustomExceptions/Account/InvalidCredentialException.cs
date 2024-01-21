using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.CustomExceptions.Account
{
    public class InvalidCredentialException : Exception
    {
        public string Property { get; set; }
        public InvalidCredentialException()
        {
        }

        public InvalidCredentialException(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
