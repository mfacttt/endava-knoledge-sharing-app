using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.CORE.Interfaces.Persistence;

public interface ICourseRepository : IBaseRepository<Course, int>
{
    Task<IEnumerable<Course>> GetAllAsync(CancellationToken ct);
}