using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public class StepRepository : GenericRepository<Step>, IStepRepository
{
    private readonly WorkFlowsContext context;

    public StepRepository(WorkFlowsContext context): base(context)
    {
            this.context = context;
    }
}
