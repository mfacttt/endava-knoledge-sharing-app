using KnowledgeSharing.CORE.Interfaces.Persistence;

namespace KnowledgeSharing.DAL.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    // private readonly AppDbContext _context;
    public ICourseRepository Courses { get; }

    public IModuleRepository Modules { get; }

    public ICourseContributorRepository CourseContributors { get; }

    public ICourseEnrollmentRepository CourseEnrollments { get; }

    public UnitOfWork(
        // AppDbContext context,
        ICourseRepository courses,
        IModuleRepository modules,
        ICourseContributorRepository courseContributors,
        ICourseEnrollmentRepository courseEnrollments)
    {

        Courses = courses;
        Modules = modules;
        CourseContributors = courseContributors;
        CourseEnrollments = courseEnrollments;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        // return await _context.SaveChangesAsync(ct);
        throw new NotImplementedException();
    }


    public void Dispose()
    {
        // _context.Dispose();
        throw new NotImplementedException();
    }
}