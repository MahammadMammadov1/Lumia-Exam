using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.CustomExceptions.Setting
{
    public class SettingNotFoundException : Exception
    {
        public string Property { get; set; }
        public SettingNotFoundException()
        {
        }

        public SettingNotFoundException(string ex, string? message) : base(message)
        {
            Property = ex;
        }
    }
}
