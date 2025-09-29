using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.CourseContributor;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.APP.Features.CourseContributer.Query.GetAll;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using MediatR;

public sealed class GetAllContributorsHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllContributorsQuery, Response<CourseContributorsDto>>
{
    public async Task<Response<CourseContributorsDto>> Handle(GetAllContributorsQuery request, CancellationToken cancellationToken)
    {
        // validate
        if (request.CourseId <= 0) return Response<CourseContributorsDto>.Failure(
                        new ValidationErrorDto("CourseId", "CourseId must be greater than zero", request.CourseId.ToString()));

        // check if course exists
        var course = await unitOfWork.Courses.GetByIdAsync(request.CourseId, cancellationToken);

        // if not, return error
        if (course == null) return Response<CourseContributorsDto>.Failure(
                        new ValidationErrorDto("CourseId", "Course not found", request.CourseId.ToString()));

        // get contributors
        var contributors = await unitOfWork.CourseContributors.GetAll(request.CourseId, cancellationToken);

        // map
        var mappedContributors = mapper.Map<List<CourseContributorDto>>(contributors);

        // return success response
        return Response<CourseContributorsDto>.Success(new CourseContributorsDto { Contributors = mappedContributors });
    }
}
