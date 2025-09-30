using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Module;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using MediatR;

namespace KnowledgeSharing.APP.Features.Module.Queries.GetById;

public sealed class GetModuleByIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetModuleByIdQuery, Response<ModuleDetailsDto>>
{
    public async Task<Response<ModuleDetailsDto>> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
    {
        // get guid from token
        var guid = Guid.Parse("00000000-0000-0000-0000-000000000001");

        // check if user enrolled in course
        var isEnrolled = await unitOfWork.CourseEnrollments.IsExisting(new CORE.Entities.CourseEnrollment()
        {
            CourseId = request.Id,
            UserId = guid
        }, cancellationToken);

        // if not enrolled return error
        if (!isEnrolled)
            return Response<ModuleDetailsDto>.Failure(new ValidationErrorDto("", "User is not enrolled in this course", ""));

        var module = await unitOfWork.Modules.GetByIdAsync(request.Id, cancellationToken);
        if (module is null)
            return Response<ModuleDetailsDto>.Failure(new ValidationErrorDto("", "Module not found", ""));

        // map 
        var moduleDto = mapper.Map<ModuleDetailsDto>(module);

        return Response<ModuleDetailsDto>.Success(moduleDto);

    }
}
