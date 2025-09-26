namespace KnowledgeSharing.CORE.Entities;

public class Module
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Order { get; set; }

    public Guid CreatedBy { get; set; }    

    public int CourseId { get; set; }
    public Course Course { get; set; } = default!;
}