using MediatR;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Queries.GetById;

public sealed record GetCourseByIdQuery(int Id) : IRequest<Response<CourseInfoDto>>;
