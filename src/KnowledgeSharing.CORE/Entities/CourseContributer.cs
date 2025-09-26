namespace KnowledgeSharing.CORE.Entities;

public class CourseContributor
{
    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;
    public Guid UserId { get; set; }
    public DateTime AddedAt { get; set; }
}