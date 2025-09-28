using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Module;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Module.Queries.GetAll;

public sealed record GetModulesByCourseIdQuery(int CourseId) : IRequest<Response<ModuleDetailsListDto>>;
