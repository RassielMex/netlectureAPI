using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using netlectureAPI.DTOs.Author;
using netlectureAPI.DTOs.Book;
using netlectureAPI.DTOs.Genre;
using netlectureAPI.Models;

namespace netlectureAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Books
            CreateMap<Book, BookDTO>()
            .ReverseMap();

            CreateMap<BookCreationDTO, Book>()
            .ForMember(book => book.ImageURL, options => options.Ignore());

            CreateMap<BookPatchDTO, Book>()
            .ForMember(book => book.ImageURL, options => options.Ignore())
            .ReverseMap();

            //Author
            CreateMap<Author, AuthorDTO>()
            .ReverseMap();
            CreateMap<AuthorCreationDTO, Author>()
            .ReverseMap();

            //Genres
            CreateMap<Genre, GenreDTO>()
           .ReverseMap();
            CreateMap<GenreCreationDTO, Genre>()
            .ReverseMap();


        }


    }
}