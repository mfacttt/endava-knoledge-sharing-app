using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Module.Commands.Update;

public sealed record UpdateModuleCommand(int Id,
                                        string Title,
                                        string Description,
                                        string Content,
                                        int CourseId) : IRequest<Response<bool>>;