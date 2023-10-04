using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public interface IFlowStepRepository
{
    IEnumerable<FlowStep> GetFlowStepsByFlowId(int flowId);
    
}
