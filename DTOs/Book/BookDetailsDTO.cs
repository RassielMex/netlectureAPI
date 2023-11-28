using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.DTOs.Author;
using netlectureAPI.DTOs.Genre;

namespace netlectureAPI.DTOs.Book
{
    public class BookDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Grade { get; set; }
        public string Summary { get; set; }
        public string ImageURL { get; set; }
        public uint Rate { get; set; }
        public AuthorDTO Author { get; set; }
        public GenreDTO Genre { get; set; }
    }
}