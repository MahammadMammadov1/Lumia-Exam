using Lumia.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Core.Models
{
    public class Team : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Profession { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Description { get; set; }
        
        [StringLength(maximumLength:100)]

        public string? InstagramUrl { get; set; }

        [StringLength(maximumLength: 100)]

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
