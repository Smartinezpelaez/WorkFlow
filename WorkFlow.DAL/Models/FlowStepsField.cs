using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class FlowStepsField
{
    public int FlowStepsFieldId { get; set; }

    public int? FlowsStepId { get; set; }

    public int? FieldId { get; set; }

    public virtual Field? Field { get; set; }

    public virtual FlowStep? FlowsStep { get; set; }
}
