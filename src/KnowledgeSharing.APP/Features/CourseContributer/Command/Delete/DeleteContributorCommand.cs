using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

public sealed record DeleteContributorCommand(int CourseId, Guid UserId = default) : IRequest<Response<bool>>;