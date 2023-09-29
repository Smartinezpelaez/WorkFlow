using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkFlow.BLL.DTOs;
using WorkFlow.BLL.Repositories;
using WorkFlow.DAL.Models;

namespace WorkFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        readonly IFieldRepository fieldRepository;
        readonly IMapper mapper;

        public FieldsController(IFieldRepository fieldRepository, IMapper mapper)
        {
            this.fieldRepository = fieldRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Metodo para obtener todos los campos
        /// </summary>
        /// <remarks>
        /// Detalle del metodo para obtener todos los campos
        /// </remarks>
        /// <returns>Resultado de la operacion</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var field = fieldRepository.GetAll();
            var fieldsDTO = field.Select(x => mapper.Map<FieldDTO>(x));
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = fieldsDTO });
        }

        /// <summary>
        /// Metodo para obtener los campos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var field = fieldRepository.GetByIdAsync(id).Result;
            var fieldsDTO = mapper.Map<FieldDTO>(field);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = fieldsDTO });
        }

        /// <summary>
        /// Metodo para crear un Campo
        /// </summary>
        /// <param name="fieldDTO">Objeto del campo</param>
        /// <returns>Resultado de la operacion</returns>
        [HttpPost("Insert")]
        public IActionResult Insert(FieldDTO fieldDTO)
        {
            try
            {
                var field = mapper.Map<Field>(fieldDTO);
                if (field != null)
                {
                    field = fieldRepository.InsertAsync(field).Result;
                    fieldDTO.FieldId = field.FieldId;
                }
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = fieldDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para actualizar un cliente
        /// </summary>
        /// <param name="fieldDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public IActionResult Update(FieldDTO fieldDTO, int id)
        {
            try
            {
                var field = fieldRepository.GetByIdAsync(id).Result;
                if (field == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                field = mapper.Map<Field>(fieldDTO);//objeto
                field = fieldRepository.UpdateAsync(field).Result;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = fieldDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para eliminar un campo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var field = fieldRepository.GetByIdAsync(id).Result;
                if (field == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                await fieldRepository.DeleteAsync(id);
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }
}
