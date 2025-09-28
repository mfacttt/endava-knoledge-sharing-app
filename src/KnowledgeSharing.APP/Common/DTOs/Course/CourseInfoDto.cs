using KnowledgeSharing.CORE.Enums;

namespace KnowledgeSharing.APP.Common.DTOs;

public sealed class CourseInfoDto
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public string Description { get; init; } = default!;
    public CourseDisciplines Discipline { get; init; }
    public CourseDifficulty Difficulty { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public string CreatedBy { get; init; } = default!;
    public IEnumerable<ModuleHeaderDto> Modules { get; init; } = Array.Empty<ModuleHeaderDto>();
}