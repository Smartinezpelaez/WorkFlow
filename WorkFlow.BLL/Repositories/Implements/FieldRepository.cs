using WorkFlow.DAL.Models;

namespace WorkFlow.BLL.Repositories.Implements;

public class FieldRepository : GenericRepository<Field>, IFieldRepository
{
    private readonly WorkFlowsContext context;

    public FieldRepository(WorkFlowsContext context): base(context)
    {
        this.context = context;        
    }

    //public new async Task DeleteAsync(int id)
    //{
    //    var field = await GetByIdAsync(id);

    //    if (field == null) throw new Exception("The entity is null.");
    //    if (context.Fields.Any(x => x.FieldId == id)) throw new Exception("Foreign Key Movements.");

    //    context.Fields.Remove(field);
    //    await context.SaveChangesAsync();
    //}

}
