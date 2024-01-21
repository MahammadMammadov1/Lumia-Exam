using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.CustomExceptions.Team
{
    public class FileLengthException : Exception
    {
        public string Property { get; set; }
        public FileLengthException()
        {
        }

        public FileLengthException(string ex , string? message) : base(message)
        {
            Property = ex;
        }
    }
}
