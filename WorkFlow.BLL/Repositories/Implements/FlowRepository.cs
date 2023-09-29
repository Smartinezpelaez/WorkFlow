using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public class FlowRepository : GenericRepository<Flow>, IFlowRepository
{
    private readonly WorkFlowsContext context;

    public FlowRepository(WorkFlowsContext context): base(context)
    {
        this.context = context;
    }
}
