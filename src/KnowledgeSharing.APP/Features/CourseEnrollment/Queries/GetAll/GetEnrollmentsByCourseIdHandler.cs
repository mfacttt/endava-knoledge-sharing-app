using MediatR;
using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.Responses;
using KnowledgeSharing.APP.Common.DTOs.CourseEnrollment;
using KnowledgeSharing.APP.Features.CourseEnrollment.Queries.GetAll;

public sealed class GetEnrollmentsByCourseIdHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetEnrollmentsByCourseIdQuery, Response<CourseEnrollmentsDto>>
{
    public async Task<Response<CourseEnrollmentsDto>> Handle(GetEnrollmentsByCourseIdQuery request, CancellationToken cancellationToken)
    {
        // validate
        if (request.CourseId <= 0) return Response<CourseEnrollmentsDto>.Failure(
                        new ValidationErrorDto("CourseId", "CourseId must be greater than zero", request.CourseId.ToString()));

        // check if course exists
        var course = await unitOfWork.Courses.GetByIdAsync(request.CourseId, cancellationToken);

        // if not, return error
        if (course == null) return Response<CourseEnrollmentsDto>.Failure(
                        new ValidationErrorDto("CourseId", "Course not found", request.CourseId.ToString()));

        // get enrollments
        var enrollments = await unitOfWork.CourseEnrollments.GetAll(request.CourseId, cancellationToken);

        // map
        var mappedEnrollments = mapper.Map<List<CourseEnrollmentDto>>(enrollments);

        // return
        return Response<CourseEnrollmentsDto>.Success(new CourseEnrollmentsDto { Enrollments = mappedEnrollments });
    }
}