using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class StepField
{
    public int StepId { get; set; }

    public int FieldId { get; set; }

    public bool? IsInput { get; set; }

    public bool? IsOutput { get; set; }

    public virtual Field Field { get; set; } = null!;

    public virtual Step Step { get; set; } = null!;
}
