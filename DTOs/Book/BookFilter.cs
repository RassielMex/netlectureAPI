using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Models;
using netlectureAPI.Validations;

namespace netlectureAPI.DTOs.Book
{
    public class BookFilter
    {
        [GradeValue(asArray: true)]
        [MaxLength(3)]
        public string[] Grades { get; set; }
    }
}