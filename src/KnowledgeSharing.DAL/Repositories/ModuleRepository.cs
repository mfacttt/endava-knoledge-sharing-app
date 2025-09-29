using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.Repositories;

public sealed class ModuleRepository : IModuleRepository
{
    public Task<int> CreateAsync(Module entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Module>> GetAllByCourseIdAsync(int courseId, int page, int pageSize, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Module?> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Module entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}