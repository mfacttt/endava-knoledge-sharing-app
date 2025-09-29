using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Features.CourseContributer.Command.Delete;

public sealed class DeleteContributorHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteContributorCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteContributorCommand request, CancellationToken cancellationToken)
    {
        // Validate
        if (request.CourseId <= 0)
            return Response<bool>.Failure(
                new ValidationErrorDto("CourseId", "CourseId must be greater than zero.", request.CourseId.ToString()));

        if (request.UserId == Guid.Empty)
            return Response<bool>.Failure(
                new ValidationErrorDto("UserId", "UserId must be a valid GUID.", request.UserId.ToString()));


        // Check if the course exists
        var course = await unitOfWork.Courses.GetByIdAsync(request.CourseId, cancellationToken);
        if (course is null)
            return Response<bool>.Failure(
                new ValidationErrorDto("CourseId", "Course not found.", request.CourseId.ToString()));

        // Map
        var contributor = mapper.Map<CourseContributor>(request);

        // Check if the user is already a contributor
        var isExisting = await unitOfWork.CourseContributors.IsExisting(contributor, cancellationToken);
        if (!isExisting)
            return Response<bool>.Failure(
                new ValidationErrorDto("UserId", "User is not a contributor.", request.UserId.ToString()));

        // remove and check if removed successfully
        var wasRemoved = await unitOfWork.CourseContributors.UnenrollUser(contributor, cancellationToken);
        if (!wasRemoved)
            return Response<bool>.Failure(
                new ValidationErrorDto("UserId", "Something went wrong.", request.UserId.ToString()));

        // Save
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // return success response
        return Response<bool>.Success(true);
    }
}