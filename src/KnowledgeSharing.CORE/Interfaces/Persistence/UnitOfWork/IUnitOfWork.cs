using KnowledgeSharing.CORE.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IModuleRepository Modules { get; }
    ICourseContributorRepository CourseContributors { get; }
    ICourseEnrollmentRepository CourseEnrollments { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}