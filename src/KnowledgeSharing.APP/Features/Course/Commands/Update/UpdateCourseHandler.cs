using MediatR;
using AutoMapper;
using FluentValidation;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using KnowledgeSharing.APP.Features.Course.Commands.Update;

public sealed class UpdateCourseHandler(IMapper mapper,IUnitOfWork unitOfWork, IValidator<UpdateCourseCommand> validator)
                         : IRequestHandler<UpdateCourseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
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

        // validate request
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Response<bool>.Failure(validationResult.Errors.Select(e => new ValidationErrorDto(e.PropertyName, e.ErrorMessage, e.AttemptedValue?.ToString())).ToList());

        // map 
        mapper.Map(request, course);

        // update course
        var wasUpdated = await unitOfWork.Courses.UpdateAsync(course, cancellationToken);

        // check if update was successful
        if (!wasUpdated)
            return Response<bool>.Failure(new ValidationErrorDto("Course", "Failed to update course.", request.Id.ToString()));

        // save changes
        await unitOfWork.SaveChangesAsync(cancellationToken);

        // return success response
        return Response<bool>.Success(true);
    }
}