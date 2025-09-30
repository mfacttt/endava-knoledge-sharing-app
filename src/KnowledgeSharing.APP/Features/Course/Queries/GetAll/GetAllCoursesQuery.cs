using MediatR;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Queries.GetAll;

public sealed record GetAllCoursesQuery(int Page, int PageSize) : IRequest<Response<CourseInfoListDto>>;
