using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.CustomExceptions.Team
{
    public class ImageFileRequiredException : Exception
    {
        public string Property { get; set; }
        public ImageFileRequiredException()
        {
        }

        public ImageFileRequiredException(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
