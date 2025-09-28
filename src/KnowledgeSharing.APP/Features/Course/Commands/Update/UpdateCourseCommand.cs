using MediatR;
using KnowledgeSharing.CORE.Enums;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Commands.Update;

public sealed record UpdateCourseCommand(int Id,
                                         string Title,
                                         string Description,
                                         CourseDisciplines CourseDiscipline,
                                         CourseDifficulty CourseDifficulty
                                        ) : IRequest<Response<bool>>;