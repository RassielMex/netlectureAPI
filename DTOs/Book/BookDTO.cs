using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.DTOs.Author;
using netlectureAPI.DTOs.Genre;
using netlectureAPI.Models;

namespace netlectureAPI.DTOs.Book
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Grade { get; set; }
        public uint Qualification { get; set; }
        public AuthorDTO Author { get; set; }
        public GenreDTO Genre { get; set; }
    }
}