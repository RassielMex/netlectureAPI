using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Interfaces;

namespace netlectureAPI.Models
{
    public class Genre : IModelBase
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}