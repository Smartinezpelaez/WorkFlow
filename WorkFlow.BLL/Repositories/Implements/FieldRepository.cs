using WorkFlow.BLL.DTOs;
using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public class FieldRepository : GenericRepository<Field>, IFieldRepository
{
    private readonly WorkFlowsContext context;

    public FieldRepository(WorkFlowsContext context): base(context)
    {
        this.context = context;        
    }

    public IEnumerable<FlowStepsFieldDTO> GetFieldsByFlowId(int flowId)
    {
        var fields = context.FlowSteps
            .Where(fs => fs.FlowdId == flowId)
            .SelectMany(fs => fs.FlowStepsFields)
            .Select(fsField => new FlowStepsFieldDTO
            {
                FlowStepsFieldId = fsField.FlowStepsFieldId,
                FlowsStepId = fsField.FlowsStepId,
                FieldId = fsField.FieldId,
                Field = fsField.Field, 
                FlowsStep = fsField.FlowsStep 
            })
            .ToList();

        return fields;
    }

}
