using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netlectureAPI.DTOs.Author;
using netlectureAPI.Models;
using PeliculasAPI.Controllers;

namespace netlectureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : CustomControllerBase
    {
        public AuthorsController(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<AuthorDTO>>> GetAllAuthors()
        {
            return await GetAll<Author, AuthorDTO>();
        }


        [HttpGet("{id:int}", Name = "GetAuthorsById")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById(int id)
        {
            return await GetByID<Author, AuthorDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor(AuthorCreationDTO authorCreationDTO)
        {
            return await Post<AuthorCreationDTO, Author, AuthorDTO>(authorCreationDTO, "GetAuthorsById");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            return await Delete<Author>(id);
        }
    }
}