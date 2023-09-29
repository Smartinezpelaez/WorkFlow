namespace WorkFlow.BLL.DTOs;

public class StepFieldDTO
{
    public int StepId { get; set; }

    public int FieldId { get; set; }

    public bool? IsInput { get; set; }

    public bool? IsOutput { get; set; }
}
