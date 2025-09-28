using MediatR;
using AutoMapper;
using FluentValidation;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using KnowledgeSharing.APP.Features.Course.Commands.Update;

public sealed class UpdateCourseHandler(ICourseRepository courseRepository,
                                        IMapper mapper,
                                        IValidator<UpdateCourseCommand> validator) : IRequestHandler<UpdateCourseCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => new ValidationErrorDto(e.PropertyName, e.ErrorMessage, e.AttemptedValue?.ToString()));
            return Response<bool>.Failure(errors);
        }

        var course = await courseRepository.GetByIdAsync(request.Id, cancellationToken);

        if (course == null)
            return Response<bool>.Failure(new ValidationErrorDto("Id", "Course not found.", request.Id.ToString()));

        mapper.Map(request, course);

        bool updated = await courseRepository.UpdateAsync(course, cancellationToken);

        return updated
            ? Response<bool>.Success(true)
            : Response<bool>.Failure(new ValidationErrorDto("Update", "Failed to update the course.", course.Id.ToString()));
    }
}