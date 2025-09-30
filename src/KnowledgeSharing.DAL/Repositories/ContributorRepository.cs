using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.Repositories;

public sealed class ContributorRepository : ICourseContributorRepository
{
    public Task<bool> EnrollUser(CourseContributor user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseContributor>> GetAll(int courseId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExisting(CourseContributor user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UnenrollUser(CourseContributor user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}