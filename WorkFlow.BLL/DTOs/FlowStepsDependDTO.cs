using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FlowStepsDependDTO
{
    public int FlowStepsDependId { get; set; }

    public int? FlowsStepId { get; set; }

    public virtual FlowStep? FlowsStep { get; set; }
}
