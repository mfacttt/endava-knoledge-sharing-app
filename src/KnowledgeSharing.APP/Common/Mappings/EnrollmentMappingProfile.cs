using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.CourseEnrollment;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class EnrollmentMappingProfile : Profile
{
    public EnrollmentMappingProfile()
    {
        // Except name - it will handle in the handler
        CreateMap<CourseEnrollment, CourseEnrollmentDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<IEnumerable<CourseEnrollment>, CourseEnrollmentsDto>()
            .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => src));
    }
}

