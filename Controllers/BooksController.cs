using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using netlectureAPI.DTOs.Book;
using netlectureAPI.Models;
using PeliculasAPI.Controllers;

namespace netlectureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : CustomControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly IMapper mapper;

        public BooksController(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            var entities = await context.Books
            .Include(book => book.Author)
            .ToListAsync();
            var dtos = mapper.Map<List<BookDTO>>(entities);
            return dtos;
        }

        [HttpGet("filter")]
        public async Task<ActionResult<List<BookDTO>>> GetBooksWithFilter([FromQuery] BookFilter filter)
        {
            var books = new List<Book>();

            foreach (var grade in filter.Grades)
            {
                var entities = await context.Books
                                            .Where(book => book.Grade.Contains(grade))
                                            .Include(books => books.Author)
                                            .AsNoTracking()
                                            .ToListAsync();
                books.AddRange(entities);

            }
            var dtos = mapper.Map<List<BookDTO>>(books);
            return dtos;
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookDetailsDTO>> GetBookById(Guid id)
        {
            var entity = await context.Books
                                    .Include(book => book.Author)
                                    .Include(book => book.Genre)
                                    .FirstOrDefaultAsync(book => book.Id == id);
            var dto = mapper.Map<BookDetailsDTO>(entity);
            return dto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromForm] BookCreationDTO bookCreationDTO)
        {
            return await Post<BookCreationDTO, Book, BookDTO>(bookCreationDTO, "GetBookById");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<BookPatchDTO> patchDocument)
        {

            return await Patch<Book, BookPatchDTO>(id, patchDocument);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            return await Delete<Book>(id);
        }


    }
}