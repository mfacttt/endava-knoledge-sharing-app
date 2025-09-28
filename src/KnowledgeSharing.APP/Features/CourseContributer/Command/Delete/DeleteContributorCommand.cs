using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.CourseContributer.Command.Delete;

public sealed record DeleteContributorCommand(int CourseId, Guid UserId = default) : IRequest<Response<bool>>;