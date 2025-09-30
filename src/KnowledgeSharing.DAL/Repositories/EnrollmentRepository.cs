using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.Repositories;

public sealed class EnrollmentRepository : ICourseEnrollmentRepository
{
    public Task<bool> EnrollUser(CourseEnrollment user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseEnrollment>> GetAll(int courseId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExisting(CourseEnrollment user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UnenrollUser(CourseEnrollment user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}