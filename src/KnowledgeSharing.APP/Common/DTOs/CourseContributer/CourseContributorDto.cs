namespace KnowledgeSharing.APP.Common.DTOs.CourseContributor;

public sealed class CourseContributorDto
{
    public Guid UserId { get; init; }
    public int CourseId { get; init; }
    public string Name { get; init; } = "Alex";
}