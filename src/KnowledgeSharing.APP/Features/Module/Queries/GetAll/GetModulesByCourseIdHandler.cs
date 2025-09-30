using MediatR;

namespace KnowledgeSharing.APP.Features.Module.Queries;

public sealed record GetModulesByCourseIdQuery(uint CourseId) : IRequest;
