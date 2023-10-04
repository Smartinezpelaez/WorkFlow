namespace WorkFlow.BLL.DTOs;

public class FlowWithStepsDTO
{
    public int FlowId { get; set; }
    public string FlowName { get; set; }
   
    public List<StepDTO> Steps { get; set; } = new List<StepDTO>();
}
