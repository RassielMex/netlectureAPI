using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Interfaces;
using netlectureAPI.Models;
using netlectureAPI.Validations;

namespace netlectureAPI.Models
{
    public class Book : IModelBase
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido")]
        [StringLength(50, ErrorMessage = "El titulo no debe exeder {0}caracteres")]
        public string Title { get; set; }
        [Required(ErrorMessage = "El {0} es Requerido")]
        [GradeValue]
        public string Grade { get; set; }
        [StringLength(300, ErrorMessage = "El {0} no debe exeder {1}caracteres")]
        public string Summary { get; set; }
        public string ImageURL { get; set; }
        [Range(1, 5, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        [DefaultValue(1)]
        public uint Rate { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}