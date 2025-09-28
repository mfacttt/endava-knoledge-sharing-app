using KnowledgeSharing.APP.Common.DTOs.Responses;
using MediatR;

namespace KnowledgeSharing.APP.Features.Module.Commands.Delete;

public sealed record DeleteModuleCommand(int Id) : IRequest<Response<bool>>;