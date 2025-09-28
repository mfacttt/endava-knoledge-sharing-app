using MediatR;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Commands.Delete;

public sealed class DeleteCourseHandler(ICourseRepository courseRepository) : IRequestHandler<DeleteCourseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var wasDeleted = await courseRepository.DeleteAsync(request.Id, cancellationToken);

        return wasDeleted
            ? Response<bool>.Success(wasDeleted)
            : Response<bool>.Failure(new ValidationErrorDto("Id", "Course not found.", request.Id.ToString()));
    }
}