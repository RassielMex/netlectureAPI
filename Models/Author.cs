using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Controllers;
using netlectureAPI.Interfaces;

namespace netlectureAPI.Models
{
    public class Author : IModelBase
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}