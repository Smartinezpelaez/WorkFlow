using AutoMapper;
using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Field, FieldDTO>().ReverseMap();
        CreateMap<Flow, FlowDTO>().ReverseMap();
        CreateMap<Step, StepDTO>().ReverseMap();
      
    }
}
