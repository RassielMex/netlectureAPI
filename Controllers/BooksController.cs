using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            .Include(book => book.Genre)
            .ToListAsync();
            var dtos = mapper.Map<List<BookDTO>>(entities);
            return dtos;
        }

        [HttpGet("{id:int}", Name = "GetBookById")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            return await GetByID<Book, BookDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromForm] BookCreationDTO bookCreationDTO)
        {
            return await Post<BookCreationDTO, Book, BookDTO>(bookCreationDTO, "GetBookById");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<BookPatchDTO> patchDocument)
        {

            return await Patch<Book, BookPatchDTO>(id, patchDocument);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            return await Delete<Book>(id);
        }


    }
}