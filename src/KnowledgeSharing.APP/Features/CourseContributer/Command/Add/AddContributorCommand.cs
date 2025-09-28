using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.CourseContributer.Command.Add;

public sealed record AddContributorCommand(int CourseId, Guid UserId = default) : IRequest<Response<bool>>;