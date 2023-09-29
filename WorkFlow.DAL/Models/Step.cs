using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class Step
{
    public int StepId { get; set; }

    public int? FlowId { get; set; }

    public string StepCode { get; set; } = null!;

    public string StepName { get; set; } = null!;

    public virtual Flow? Flow { get; set; }

    public virtual ICollection<StepField> StepFields { get; set; } = new List<StepField>();
}
