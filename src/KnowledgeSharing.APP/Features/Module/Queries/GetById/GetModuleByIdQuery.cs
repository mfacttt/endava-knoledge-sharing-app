using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Module;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Module.Queries.GetById;

public sealed record GetModuleByIdQuery(int Id) : IRequest<Response<ModuleDetailsDto>>;
