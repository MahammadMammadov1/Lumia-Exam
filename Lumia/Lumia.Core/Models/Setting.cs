using Lumia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Core.Models
{
    public class Setting : BaseEntity
    {
        public string? Key { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Value { get; set; }
    }
}
