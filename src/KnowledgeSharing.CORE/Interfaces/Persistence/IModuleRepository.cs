using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.CORE.Interfaces.Persistence;

public interface IModuleRepository : IBaseRepository<Module, int>
{
    Task<IEnumerable<Module>> GetAllByCourseIdAsync(int courseId, int page, int pageSize, CancellationToken ct);
}