namespace KnowledgeSharing.APP.Common.DTOs.CourseContributor;

public sealed class CourseContributorsDto
{
    public IEnumerable<CourseContributorDto> Contributors { get; init; } = Array.Empty<CourseContributorDto>();
}