using AutoMapper;
using KnowledgeSharing.CORE.Entities;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Features.Course.Commands.Create;
using KnowledgeSharing.APP.Features.Course.Commands.Update;

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

        CreateMap<UpdateCourseCommand, Course>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Discipline, opt => opt.MapFrom(src => src.CourseDiscipline))
            .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.CourseDifficulty));

        // Exept Created - it will be mapped in the handler
        CreateMap<Course, CourseInfoDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Discipline, opt => opt.MapFrom(src => src.Discipline))
            .ForMember(dest => dest.Difficulty, opt => opt.MapFrom(src => src.Difficulty))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(d => d.Modules, opt => opt.MapFrom(
                src => (src.Modules ?? Array.Empty<Module>())
                        .OrderBy(m => m.Order)
            ));
    }
}