using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.CourseEnrollment.Command.Enroll;

public sealed record EnrollUserCommand(int CourseId, Guid UserId = default) : IRequest<Response<bool>>;
