
using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.APP.Common.DTOs.Module;

namespace KnowledgeSharing.APP.Features.Course.Queries.GetById;

public sealed class GetCourseByIdHandler(IMapper mapper, IUnitOfWork unitOfWork)
                                        : IRequestHandler<GetCourseByIdQuery, Response<CourseInfoDto>>
{
    public async Task<Response<CourseInfoDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        // get course by id
        var course = await unitOfWork.Courses.GetByIdAsync(request.Id, cancellationToken);

        if (course is null)
            return Response<CourseInfoDto>.Failure(new ValidationErrorDto("NotFound", $"Course with Id {request.Id} not found.", "GetCourseById"));


        // get modules for course - fix
        var modules = await unitOfWork.Modules.GetAllByCourseIdAsync(request.Id, 1, 10, cancellationToken);

        var courseDto = mapper.Map<CourseInfoDto>(course);
        var modulesDto = mapper.Map<ModuleDetailsListDto>(modules);


        foreach (var module in modulesDto.Modules)
            courseDto.Modules.Add(new ModuleHeaderDto { Id = module.Id, Title = module.Title});

        return Response<CourseInfoDto>.Success(courseDto);
    }
}