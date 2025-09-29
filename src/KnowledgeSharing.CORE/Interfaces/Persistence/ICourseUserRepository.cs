namespace KnowledgeSharing.CORE.Interfaces.Persistence;

public interface ICourseUserRepository<TUser>
{
    Task<bool> EnrollUser(TUser user, CancellationToken cancellationToken);
    Task<bool> UnenrollUser(TUser user, CancellationToken cancellationToken);
    Task<bool> IsExisting(TUser user, CancellationToken cancellationToken);
    Task<IEnumerable<TUser>> GetAll(int courseId, CancellationToken cancellationToken);
}