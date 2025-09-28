using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs.CourseContributor;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class ContributorMappingProfile : Profile
{
    public ContributorMappingProfile()
    {
        // Except name - it will handle in the handler
        CreateMap<CourseContributor, CourseContributorDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<IEnumerable<CourseContributor>, CourseContributorsDto>()
            .ForMember(dest => dest.Contributors, opt => opt.MapFrom(src => src));   
    }
}
