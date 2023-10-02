using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FlowDTO
{
    public int FlowId { get; set; }

    public string FlowName { get; set; } = null!;
    //public List<StepDTO>? Steps { get; set; }

    public virtual IEnumerable<FlowStep> Steps { get; set; } = new List<FlowStep>();

    // public virtual ICollection<Step> Steps { get; set; } = new List<Step>();

}
