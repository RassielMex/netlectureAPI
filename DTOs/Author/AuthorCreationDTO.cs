using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace netlectureAPI.DTOs.Author
{
    public class AuthorCreationDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}