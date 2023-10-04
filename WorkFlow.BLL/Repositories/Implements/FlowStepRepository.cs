using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements
{
    public class FlowStepRepository : IFlowStepRepository
    {
        private readonly WorkFlowsContext context; 

        public FlowStepRepository(WorkFlowsContext context)
        {
            this.context = context;
        }

        public IEnumerable<FlowStep> GetFlowStepsByFlowId(int flowId)
        {
            return context.FlowSteps
                .Where(fs => fs.FlowdId == flowId)
                .ToList();
        }
             
    }
}
