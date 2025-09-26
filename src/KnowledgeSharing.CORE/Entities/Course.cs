using KnowledgeSharing.CORE.Enums;

namespace KnowledgeSharing.CORE.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public CourseDisciplines Discipline { get; set; }
    public CourseDifficulty Difficulty { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid CreatedBy { get; set; }
    public ICollection<Module> Modules { get; set; } = new List<Module>();
    public ICollection<CourseContributor> Contributors { get; set; } = new List<CourseContributor>();
    public ICollection<CourseEnrollment> Enrollments { get; set; } = new List<CourseEnrollment>();
}