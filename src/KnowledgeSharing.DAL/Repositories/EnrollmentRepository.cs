using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.Repositories;

public sealed class EnrollmentRepository : ICourseEnrollmentRepository
{
    public Task AddUser(int courseId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseEnrollment>> GetAll(int courseId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUser(int courseId, Guid userId)
    {
        throw new NotImplementedException();
    }
}