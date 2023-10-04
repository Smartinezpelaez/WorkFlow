using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkFlow.BLL.DTOs;
using WorkFlow.BLL.Repositories;
using WorkFlow.BLL.Repositories.Implements;
using WorkFlow.DAL.Models;

namespace WorkFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StepsController : ControllerBase
{
    readonly IStepRepository stepRepository;
    readonly IMapper mapper;

    public StepsController(IStepRepository stepRepository, IMapper mapper)
    {
        this.stepRepository = stepRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Metodo para obtener todos los pasos
    /// </summary>
    /// <remarks>
    /// Detalle del metodo para obtener todos los pasos
    /// </remarks>
    /// <returns>Resultado de la operacion</returns>
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var step = stepRepository.GetAll();
        var stepsDTO = step.Select(x => mapper.Map<StepDTO>(x));
        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = stepsDTO });
    }

    

    /// <summary>
    /// Metodo para obtener los pasos por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var step = stepRepository.GetByIdAsync(id).Result;
        var stepsDTO = mapper.Map<StepDTO>(step);
        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = stepsDTO });
    }

    /// <summary>
    /// Metodo para crear un paso
    /// </summary>
    /// <param name="stepDTO">Objeto del paso</param>
    /// <returns>Resultado de la operacion</returns>
    [HttpPost("Insert")]
    public IActionResult Insert(StepDTO stepDTO)
    {
        try
        {
            var step = mapper.Map<Step>(stepDTO);
            if (step != null)
            {
                step = stepRepository.InsertAsync(step).Result;
                stepDTO.StepId = step.StepId;
            }
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = stepDTO });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

    /// <summary>
    /// Método para actualizar un paso
    /// </summary>
    /// <param name="stepDTO"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("Update/{id}")]
    public IActionResult Update(StepDTO stepDTO, int id)
    {
        try
        {
            var step = stepRepository.GetByIdAsync(id).Result;
            if (step == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

            step = mapper.Map<Step>(stepDTO);//objeto
            step = stepRepository.UpdateAsync(step).Result;

            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = stepDTO });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

    /// <summary>
    /// Método para eliminar un paso
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteAsync/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var step = stepRepository.GetByIdAsync(id).Result;
            if (step == null)
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

            await stepRepository.DeleteAsync(id);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
        }
        catch (Exception ex)
        {
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
        }
    }

}
