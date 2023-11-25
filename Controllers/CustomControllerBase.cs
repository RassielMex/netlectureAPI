using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using netlectureAPI;
using netlectureAPI.Interfaces;
namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomControllerBase : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDBContext context;
        public CustomControllerBase(ApplicationDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        protected async Task<List<TDTO>> GetAll<TEntity, TDTO>() where TEntity : class
        {
            var entities = await context.Set<TEntity>().AsNoTracking().ToListAsync();
            var dtos = mapper.Map<List<TDTO>>(entities);
            return dtos;
        }

        // protected async Task<List<TDTO>> GetAll<TEntidad, TDTO>(PaginacionDTO paginacionDTO) where TEntidad : class
        // {
        //     var queryable = context.Set<TEntidad>().AsQueryable();
        //     await HttpContext.InsertarParametrosPaginacion(queryable, paginacionDTO.CantidadRegistrosPorPagina);
        //     var entidades = await queryable.Paginar(paginacionDTO).ToListAsync();
        //     return mapper.Map<List<TDTO>>(entidades);
        // }

        protected async Task<ActionResult<TDTO>> GetByID<TEntity, TDTO>(Guid id) where TEntity : class, IModelBase
        {
            var entity = await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return NotFound($"Entidad con id:{id} no existe");
            }
            var dto = mapper.Map<TDTO>(entity);
            return dto;
        }

        protected async Task<ActionResult> Post<TCreation, TEntity, TRead>
        (TCreation creationDTO, string routeName) where TEntity : class, IModelBase
        {
            var entity = mapper.Map<TEntity>(creationDTO);
            context.Add(entity);
            await context.SaveChangesAsync();
            var dtoRead = mapper.Map<TRead>(entity);
            return new CreatedAtRouteResult(routeName, new { id = entity.Id }, dtoRead);
        }

        protected async Task<ActionResult> Put<TCreation, TEntity>(Guid id, TCreation creationDTO) where TEntity : class, IModelBase
        {
            var entidad = mapper.Map<TEntity>(creationDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Patch<TEntity, TDTO>(Guid id, JsonPatchDocument<TDTO> patchDocument)
        where TEntity : class, IModelBase
        where TDTO : class
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var entityDB = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            if (entityDB == null)
            {
                return NotFound();
            }

            var entityDTO = mapper.Map<TDTO>(entityDB);
            patchDocument.ApplyTo(entityDTO, ModelState);

            var isValid = TryValidateModel(entityDTO);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            mapper.Map(entityDTO, entityDB);

            await context.SaveChangesAsync();

            return NoContent();
        }
        protected async Task<ActionResult> Delete<TEntity>(Guid id) where TEntity : class, IModelBase, new()
        {
            var exists = await context.Set<TEntity>().AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound($"Genero con id {id} no existe");
            }
            context.Remove(new TEntity() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}