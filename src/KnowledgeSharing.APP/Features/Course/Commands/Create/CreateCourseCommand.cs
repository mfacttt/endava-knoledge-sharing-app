using MediatR;
using KnowledgeSharing.CORE.Enums;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Commands.Create;

public sealed record CreateCourseCommand(string Title,
                                         string Description,
                                         CourseDisciplines CourseDiscipline,
                                         CourseDifficulty CourseDifficulty
                                        ) :IRequest<Response<int>>;