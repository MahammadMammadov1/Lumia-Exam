using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.CustomExceptions.Team
{
    public class TeamNotFoundException : Exception
    {
        public string Property { get; set; }
        public TeamNotFoundException()
        {
        }

        public TeamNotFoundException(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
