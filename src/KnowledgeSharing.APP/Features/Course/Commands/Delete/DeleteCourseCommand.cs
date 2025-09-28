using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Commands.Delete;

public sealed record DeleteCourseCommand(int Id) : IRequest<Response<bool>>;
