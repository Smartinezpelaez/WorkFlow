using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkFlow.BLL.DTOs;
using WorkFlow.BLL.Repositories;
using WorkFlow.BLL.Repositories.Implements;

namespace WorkFlow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlowsController : ControllerBase
{
    readonly IFlowRepository flowRepository;
    readonly IStepRepository stepRepository;
    readonly IFlowStepRepository flowStepRepository;
    readonly IFieldRepository fieldRepository; // Añadir el repositorio de Field
    readonly IMapper mapper;
    public FlowsController(IFlowRepository flowRepository, IStepRepository stepRepository, IFieldRepository fieldRepository, IMapper mapper)
    {
        this.flowRepository = flowRepository;
        this.stepRepository = stepRepository;
        this.fieldRepository = fieldRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Metodo para obtener todos los flujos
    /// </summary>
    /// <remarks>
    /// Detalle del metodo para obtener todos los flujos
    /// </remarks>
    /// <returns>Resultado de la operacion</returns>
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var flow = flowRepository.GetAll();
        var flowWithStepsDTOs = new List<FlowDTO>();
        var flowsDTO = flow.Select(x => mapper.Map<FlowDTO>(x));
        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = flowsDTO });
    }

    /// <summary>
    /// Obtiene los flujos con los pasos
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllWithSteps")]
    public IActionResult GetAllWithSteps()
    {
        var flows = flowRepository.GetAll();

        var flowWithStepsDTOs = new List<FlowWithStepsDTO>();

        foreach (var flow in flows)
        {
            var steps = stepRepository.GetStepsByFlowId(flow.FlowId);

            var flowWithStepsDTO = new FlowWithStepsDTO
            {
                FlowId = flow.FlowId,
                FlowName = flow.FlowName,
                // Mapear otros campos del flujo

                Steps = steps.Select(x => mapper.Map<StepDTO>(x)).ToList()
            };

            flowWithStepsDTOs.Add(flowWithStepsDTO);
        }

        return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = flowWithStepsDTOs });
    }


    /// <summary>
    /// Obtiene los campos por ID de flujo
    /// </summary>
    /// <param name="flowId">ID del flujo</param>
    /// <returns></returns>
    [HttpGet("GetFieldsByFlowId/{flowId}")]
    public IActionResult GetFieldsByFlowId(int flowId)
    {
        try
        {
            var fields = fieldRepository.GetFieldsByFlowId(flowId);

            if (fields == null || !fields.Any())
            {
                return NotFound(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "No se encontraron campos para el flujo proporcionado." });
            }

            var fieldDTOs = fields.Select(x => mapper.Map<FlowStepsFieldDTO>(x));

            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = fieldDTOs });
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = "Error interno del servidor." });
        }
    }

}
