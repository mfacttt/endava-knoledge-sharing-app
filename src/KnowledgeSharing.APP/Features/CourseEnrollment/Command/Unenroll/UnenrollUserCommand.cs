using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;

public sealed record UnenrollUserCommand(int CourseId, Guid UserId = default) : IRequest<Response<bool>>;
