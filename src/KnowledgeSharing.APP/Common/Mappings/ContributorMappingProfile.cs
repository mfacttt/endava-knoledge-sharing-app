using AutoMapper;
using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.APP.Common.DTOs.CourseContributor;
using KnowledgeSharing.APP.Features.CourseContributer.Command.Add;
using KnowledgeSharing.APP.Features.CourseContributer.Command.Delete;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class ContributorMappingProfile : Profile
{
    public ContributorMappingProfile()
    {
        CreateMap<AddContributorCommand, CourseContributor>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.AddedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<DeleteContributorCommand, CourseContributor>()
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));




        // Except name - it will handle in the handler
        CreateMap<CourseContributor, CourseContributorDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<IEnumerable<CourseContributor>, CourseContributorsDto>()
            .ForMember(dest => dest.Contributors, opt => opt.MapFrom(src => src));   
    }
}
