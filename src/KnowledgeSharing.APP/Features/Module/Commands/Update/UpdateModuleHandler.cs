using MediatR;
using AutoMapper;
using FluentValidation;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using ModuleEf = KnowledgeSharing.CORE.Entities.Module;


namespace KnowledgeSharing.APP.Features.Module.Commands.Update;

public sealed class UpdateModuleHandler(IUnitOfWork unitOfWork,
                                        IMapper mapper,
                                        IValidator<UpdateModuleCommand> validator) : IRequestHandler<UpdateModuleCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
    {
        // get user id from the token
        var guid = Guid.Parse("00000000-0000-0000-0000-000000000001");

        // get course by id
        var course = await unitOfWork.Courses.GetByIdAsync(request.CourseId, cancellationToken);

        // check if course exists
        if (course is null)
            return Response<bool>.Failure(new ValidationErrorDto("CourseId", "Course not found", request.CourseId.ToString()));

        // check if user is a course author
        if (course.CreatedBy != guid)
            return Response<bool>.Failure(new ValidationErrorDto("CourseId", "You are not the author of this course", request.CourseId.ToString()));

        // validate request
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // if validation fails, return errors
        if (!validationResult.IsValid)
            return Response<bool>.Failure(validationResult.Errors
                .Select(e => new ValidationErrorDto(e.PropertyName, e.ErrorMessage, e.AttemptedValue?.ToString())));

        // map request to entity
        var module = mapper.Map<ModuleEf>(request);
        module.CreatedBy = guid;

        //save module
        bool updatedModule = await unitOfWork.Modules.UpdateAsync(module, cancellationToken);

        // check if module was created
        if (!updatedModule)
            return Response<bool>.Failure(new ValidationErrorDto("Module", "Module could not be updated", ""));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Response<bool>.Success(true);
    }
}
