using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.Repositories;

public sealed class CourseRepository : ICourseRepository
{
    public Task<int> CreateAsync(Course entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> GetAllAsync(int page, int pageSize, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Course?> GetByIdAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Course entity, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}