using AutoMapper;
using KnowledgeSharing.APP.Features.Course.Commands.Create;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<CreateCourseCommand, Course>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Discipline, opt => opt.MapFrom(src => src.CourseDiscipline))
            .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.CourseDifficulty));   

    }
}