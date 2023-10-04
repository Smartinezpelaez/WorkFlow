using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.DTOs;

public class FieldDTO
{
    public int FieldId { get; set; }

    public string FieldCode { get; set; } = null!;

    public string FieldName { get; set; } = null!;  

    public virtual ICollection<FlowStepsField> FlowStepsFields { get; set; } = new List<FlowStepsField>();
}
