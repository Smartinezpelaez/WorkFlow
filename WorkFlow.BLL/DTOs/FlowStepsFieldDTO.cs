using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FlowStepsFieldDTO
{
    public int FlowStepsFieldId { get; set; }

    public int? FlowsStepId { get; set; }

    public int? FieldId { get; set; }

    public virtual Field? Field { get; set; }

    public virtual FlowStep? FlowsStep { get; set; }
}
