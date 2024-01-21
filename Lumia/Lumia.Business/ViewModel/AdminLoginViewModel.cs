using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.ViewModel
{
    public class AdminLoginViewModel
    {
        [Required]
        [MinLength(3)]
        [StringLength(maximumLength: 50)]
        public string UserName { get; set; }
        [Required]
        [MinLength(8)]
        [StringLength(maximumLength:30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

