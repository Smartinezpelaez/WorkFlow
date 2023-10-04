using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class StepDTO
{
    public int StepId { get; set; }

    public int? FlowId { get; set; }

    public string StepCode { get; set; } = null!;

    public string StepName { get; set; } = null!;

    public virtual ICollection<FlowStep> FlowSteps { get; set; } = new List<FlowStep>();
}


