using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Course.Queries.GetAll;

public sealed class GetAllCoursesHandler(IMapper mapper, IUnitOfWork unitOfWork)
                                        : IRequestHandler<GetAllCoursesQuery, Response<CourseInfoListDto>>
{
    public async Task<Response<CourseInfoListDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        // get all courses
        var courses = await unitOfWork.Courses.GetAllAsync(request.Page, request.PageSize, cancellationToken);

        // map to dto
        var courseDtos = mapper.Map<CourseInfoListDto>(courses);


        // return success response
        return Response<CourseInfoListDto>.Success(courseDtos);
    }
}