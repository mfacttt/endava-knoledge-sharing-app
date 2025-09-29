using MediatR;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Commands.Delete;

public sealed class DeleteCourseHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCourseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        // get user id from token
        var guid = new Guid("00000000-0000-0000-0000-000000000001");

        // check if course exists
        var course = await unitOfWork.Courses.GetByIdAsync(request.Id, cancellationToken);
        if (course == null)
            return Response<bool>.Failure(new ValidationErrorDto("Id", "Course not found.", request.Id.ToString()));

        // check if user is the creator of the course
        if (course.CreatedBy != guid)
            return Response<bool>.Failure(new ValidationErrorDto("Id", "You are not the creator of this course.", request.Id.ToString()));

        // delete course
        var wasDeleted = await unitOfWork.Courses.DeleteAsync(request.Id, cancellationToken);

        // save changes
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return wasDeleted
            ? Response<bool>.Success(wasDeleted)
            : Response<bool>.Failure(new ValidationErrorDto("Id", "Course not found.", request.Id.ToString()));
    }
}