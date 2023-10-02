using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class FlowStepsDepend
{
    public int FlowStepsDependId { get; set; }

    public int? FlowsStepId { get; set; }

    public virtual FlowStep? FlowsStep { get; set; }
}
