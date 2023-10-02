namespace WorkFlow.BLL.DTOs;

public class FlowWithStepsDTO
{
    public int FlowId { get; set; }
    public string FlowName { get; set; }
    // Otros campos del flujo

    public List<StepDTO> Steps { get; set; } = new List<StepDTO>();
}
