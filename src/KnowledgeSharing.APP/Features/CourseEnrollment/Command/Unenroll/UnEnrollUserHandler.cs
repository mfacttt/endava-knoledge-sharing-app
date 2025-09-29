using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using CourseEnrollmentEf = KnowledgeSharing.CORE.Entities.CourseEnrollment;

namespace KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;

public sealed class UnEnrollUserHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UnenrollUserCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UnenrollUserCommand request, CancellationToken cancellationToken)
    {
         // validate
        if (request.CourseId <= 0) return Response<bool>.Failure(
                        new ValidationErrorDto("CourseId", "CourseId must be greater than zero", request.CourseId.ToString()));

        if (request.UserId == Guid.Empty) return Response<bool>.Failure(
                        new ValidationErrorDto("UserId", "UserId must be a valid GUID", request.UserId.ToString()));

        // check if course exists
        var course = await unitOfWork.Courses.GetByIdAsync(request.CourseId, cancellationToken);

        // if not, return error
        if (course == null) return Response<bool>.Failure(
                        new ValidationErrorDto("CourseId", "Course not found", request.CourseId.ToString()));

        // map
        var courseEnrollment = mapper.Map<CourseEnrollmentEf>(request);

        // check if user is already enrolled
        var isExisting = await unitOfWork.CourseEnrollments.IsExisting(courseEnrollment, cancellationToken);
        if (!isExisting) return Response<bool>.Failure(
                        new ValidationErrorDto("UserId", "User is not enrolled", request.UserId.ToString()));

        // remove
        var wasRemoved = await unitOfWork.CourseEnrollments.UnenrollUser(courseEnrollment, cancellationToken);


        // return error if something went wrong
        if (!wasRemoved) return Response<bool>.Failure(
                        new ValidationErrorDto("UserId", "Something went wrong", request.UserId.ToString()));

        // save
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<bool>.Success(true);
    }
}