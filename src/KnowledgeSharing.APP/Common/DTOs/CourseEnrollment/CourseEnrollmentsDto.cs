namespace KnowledgeSharing.APP.Common.DTOs.CourseEnrollment;

public sealed class CourseEnrollmentsDto
{
    public IEnumerable<CourseEnrollmentDto> Enrollments { get; init; } = Array.Empty<CourseEnrollmentDto>();
}
