using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Models;
using netlectureAPI.Validations;

namespace netlectureAPI.DTOs.Book
{
    public class BookCreationDTO
    {
        [Required(ErrorMessage = "El {0} es Requerido")]
        [StringLength(50, ErrorMessage = "El {0} no debe exeder {0}caracteres")]
        public string Title { get; set; }
        [GradeValue]
        public string Grade { get; set; }
        [StringLength(300, ErrorMessage = "La {0} no debe exeder {1}caracteres")]
        public string Review { get; set; }
        [FileSize(MaxSizeMB: 2)]
        [FileType(validFileType: ValidFileType.IMAGE)]
        public IFormFile Image { get; set; }
        [Range(1, 5, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public uint Qualification { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}