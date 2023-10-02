using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class Flow
{
    public int FlowId { get; set; }

    public string FlowName { get; set; } = null!;

    public virtual ICollection<FlowStep> FlowSteps { get; set; } = new List<FlowStep>();

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();
}
