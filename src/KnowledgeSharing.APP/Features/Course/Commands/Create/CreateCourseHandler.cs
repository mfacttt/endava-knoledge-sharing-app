using MediatR;
using AutoMapper;
using FluentValidation;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using CourseEntity = KnowledgeSharing.CORE.Entities.Course;

namespace KnowledgeSharing.APP.Features.Course.Commands.Create;

public sealed class CreateCourseHandler(ICourseRepository courseRepository,
                                        IValidator<CreateCourseCommand> validator,
                                        IMapper mapper)
                                        : IRequestHandler<CreateCourseCommand, Response<int>>
{
    public async Task<Response<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => new ValidationErrorDto(e.PropertyName, e.ErrorMessage, e.AttemptedValue?.ToString()));
            return Response<int>.Failure(errors);
        }

        var courseEf = mapper.Map<CourseEntity>(request);

        var createdCourseId = await courseRepository.CreateAsync(courseEf, cancellationToken);

        return Response<int>.Success(createdCourseId);
    }
}