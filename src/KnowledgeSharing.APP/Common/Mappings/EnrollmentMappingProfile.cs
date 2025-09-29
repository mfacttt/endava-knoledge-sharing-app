using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.CourseEnrollment;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Enroll;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class EnrollmentMappingProfile : Profile
{
    public EnrollmentMappingProfile()
    {
        CreateMap<EnrollUserCommand, CourseEnrollment>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.EnrolledAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<UnenrollUserCommand, CourseEnrollment>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.EnrolledAt, opt => opt.Ignore());



        // Except name - it will handle in the handler
        CreateMap<CourseEnrollment, CourseEnrollmentDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<IEnumerable<CourseEnrollment>, CourseEnrollmentsDto>()
            .ForMember(dest => dest.Enrollments, opt => opt.MapFrom(src => src));
    }
}

