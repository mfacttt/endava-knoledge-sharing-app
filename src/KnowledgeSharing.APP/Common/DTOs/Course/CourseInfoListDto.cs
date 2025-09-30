namespace KnowledgeSharing.APP.Common.DTOs;

public sealed class CourseInfoListDto
{
    public IEnumerable<CourseInfoDto> Courses { get; init; } = Array.Empty<CourseInfoDto>();
}