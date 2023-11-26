using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netlectureAPI.Models;

namespace netlectureAPI.DTOs.Book
{
    public class BookDetailsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Grade { get; set; }
        public string Summary { get; set; }
        public string ImageURL { get; set; }
        public uint Qualification { get; set; }
        public Models.Author Author { get; set; }
        public Models.Genre Genre { get; set; }
    }
}