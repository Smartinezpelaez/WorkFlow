using WorkFlow.BLL.DTOs;
using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories;

public interface IFieldRepository: IGenericRepository<Field>
{
    IEnumerable<FlowStepsFieldDTO> GetFieldsByFlowId(int flowId);

}
