using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.APP.Common.DTOs.CourseContributor;

namespace KnowledgeSharing.APP.Features.CourseContributer.Query.GetAll;

public sealed record GetAllContributorsQuery(int CourseId) : IRequest<Response<CourseContributorsDto>>;