using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FlowDTO
{
    public int FlowId { get; set; }

    public string FlowName { get; set; } = null!;

    public virtual IEnumerable<FlowStep> Steps { get; set; } = new List<FlowStep>();

}
