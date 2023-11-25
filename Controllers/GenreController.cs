using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using netlectureAPI.DTOs.Genre;
using netlectureAPI.Models;
using PeliculasAPI.Controllers;

namespace netlectureAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : CustomControllerBase
    {
        public GenreController(ApplicationDBContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> GetAllGenres()
        {
            return await GetAll<Genre, GenreDTO>();
        }


        [HttpGet("{id}", Name = "GetGenreById")]
        public async Task<ActionResult<GenreDTO>> GetGenreById(Guid id)
        {
            return await GetByID<Genre, GenreDTO>(id);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGenre(GenreCreationDTO authorCreationDTO)
        {
            return await Post<GenreCreationDTO, Genre, GenreDTO>(authorCreationDTO, "GetGenreById");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGenre(Guid id)
        {
            return await Delete<Genre>(id);
        }
    }
}