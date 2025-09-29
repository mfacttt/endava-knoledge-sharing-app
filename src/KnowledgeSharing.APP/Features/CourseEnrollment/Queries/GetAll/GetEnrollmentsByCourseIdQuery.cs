using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.APP.Common.DTOs.CourseEnrollment;

namespace KnowledgeSharing.APP.Features.CourseEnrollment.Queries.GetAll;

public sealed record GetEnrollmentsByCourseIdQuery(int CourseId) : IRequest<Response<CourseEnrollmentsDto>>;