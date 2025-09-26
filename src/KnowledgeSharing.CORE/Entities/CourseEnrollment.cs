namespace KnowledgeSharing.CORE.Entities;

public class CourseEnrollment
{
    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;
    public Guid UserId { get; set; }
    public DateTime EnrolledAt { get; set; }
}