namespace KnowledgeSharing.CORE.Interfaces.Persistence;

public interface ICourseUserRepository<TUser>
{
    Task AddUser(int courseId, Guid userId);
    Task RemoveUser(int courseId, Guid userId);
    Task<IEnumerable<TUser>> GetAll(int courseId);
}