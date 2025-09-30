namespace KnowledgeSharing.APP.Common.DTOs.Module;

public sealed class ModuleDetailsDto
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public string Content { get; init; } = default!;
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public int Order { get; init; }
    public int CourseId { get; init; }
}
