using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FlowStepDTO
{
    public int FlowsStepId { get; set; }

    public int? StepId { get; set; }

    public int? FlowdId { get; set; }

    public virtual ICollection<FlowStepsDepend> FlowStepsDepends { get; set; } = new List<FlowStepsDepend>();

    public virtual ICollection<FlowStepsField> FlowStepsFields { get; set; } = new List<FlowStepsField>();

    public virtual Flow? Flowd { get; set; }

    public virtual Step? Step { get; set; }
}
