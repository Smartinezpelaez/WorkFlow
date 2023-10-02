using System;
using System.Collections.Generic;

namespace WorkFlow.DAL.Models;

public partial class Field
{
    public int FieldId { get; set; }

    public string FieldCode { get; set; } = null!;

    public string FieldName { get; set; } = null!;

    public virtual ICollection<FlowStepsField> FlowStepsFields { get; set; } = new List<FlowStepsField>();
}
