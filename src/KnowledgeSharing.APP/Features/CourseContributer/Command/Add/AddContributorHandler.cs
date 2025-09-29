using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Features.CourseContributer.Command.Add;

public sealed class AddContributorHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<AddContributorCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddContributorCommand request, CancellationToken cancellationToken)
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
        if (isExisting)
            return Response<bool>.Failure(
                new ValidationErrorDto("UserId", "User is already a contributor.", request.UserId.ToString()));

        // Add and check if added successfully
        var wasAdded = await unitOfWork.CourseContributors.EnrollUser(contributor, cancellationToken);
        if (!wasAdded)
            return Response<bool>.Failure(
                new ValidationErrorDto("UserId", "Something went wrong.", request.UserId.ToString()));

        // Save
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // return success response
        return Response<bool>.Success(true);
    }
}