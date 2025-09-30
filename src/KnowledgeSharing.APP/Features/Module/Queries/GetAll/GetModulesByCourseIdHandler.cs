using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Module;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using MediatR;

namespace KnowledgeSharing.APP.Features.Module.Queries.GetAll;

public sealed class GetModulesByCourseIdHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<GetModulesByCourseIdQuery, Response<ModuleDetailsListDto>>
{
    public async Task<Response<ModuleDetailsListDto>> Handle(GetModulesByCourseIdQuery request, CancellationToken cancellationToken)
    {
        // get guid from token
        var guid = Guid.Parse("00000000-0000-0000-0000-000000000001");

        // check if user enrolled in course
        var isEnrolled = await unitOfWork.CourseEnrollments.IsExisting(new CORE.Entities.CourseEnrollment()
        {
            CourseId = request.CourseId,
            UserId = guid
        }, cancellationToken);

        var modules = await unitOfWork.Modules.GetAllByCourseIdAsync(request.CourseId, request.Page, request.PageSize, cancellationToken);

        // if not enrolled return m
        if (isEnrolled)
        {
            var moduleDetailsDtos = mapper.Map<List<ModuleDetailsDto>>(modules);
            return Response<ModuleDetailsListDto>.Success(new ModuleDetailsListDto { Modules = moduleDetailsDtos });
        }

        var limitedModuleDetailsDtos = modules.Select(m =>
                 new ModuleDetailsDto { Id = m.Id, Title = m.Title });

        return Response<ModuleDetailsListDto>.Success(new ModuleDetailsListDto { Modules = limitedModuleDetailsDtos.ToList() });
    }
}
