using System.Data.Entity;
using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public class StepRepository : GenericRepository<Step>, IStepRepository
{
    private readonly WorkFlowsContext context;

    public StepRepository(WorkFlowsContext context): base(context)
    {
            this.context = context;
    }

    public IEnumerable<Step> GetStepsByFlowId(int flowId)
    {
        // Suponiendo que tienes una entidad Step con una propiedad FlowId
        return context.Steps.Where(step => step.FlowId == flowId).ToList();
    }

}
