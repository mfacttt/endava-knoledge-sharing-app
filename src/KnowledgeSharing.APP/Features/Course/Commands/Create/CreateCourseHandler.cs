using MediatR;
using AutoMapper;
using FluentValidation;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using CourseEntity = KnowledgeSharing.CORE.Entities.Course;

namespace KnowledgeSharing.APP.Features.Course.Commands.Create;

public sealed class CreateCourseHandler(IUnitOfWork unitOfWork,IMapper mapper, IValidator<CreateCourseCommand> validator)
                                        : IRequestHandler<CreateCourseCommand, Response<int>>
{
    public async Task<Response<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        // get is from token
        var guid = new Guid("00000000-0000-0000-0000-000000000001");

        // validate request
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // return errors if validation fails
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => new ValidationErrorDto(e.PropertyName, e.ErrorMessage, e.AttemptedValue?.ToString()));
            return Response<int>.Failure(errors);
        }

        // map
        var courseEf = mapper.Map<CourseEntity>(request);
        courseEf.CreatedBy = guid;

        // create
        var createdCourseId = await unitOfWork.Courses.CreateAsync(courseEf, cancellationToken);

        // check if created
        if (createdCourseId == 0)
            return Response<int>.Failure(new ValidationErrorDto("Course", "Course could not be created", null));

        // save changes 
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<int>.Success(createdCourseId);
    }
}