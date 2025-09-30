using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Module.Commands.Create;

public sealed record CreateModuleCommand(string Title,
                                        string Description,
                                        string Content,
                                        int CourseId,
                                        int Order) : IRequest<Response<int>>;