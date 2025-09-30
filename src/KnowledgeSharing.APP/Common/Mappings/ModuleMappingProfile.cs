using AutoMapper;
using KnowledgeSharing.APP.Common.DTOs;
using KnowledgeSharing.APP.Common.DTOs.Module;
using KnowledgeSharing.APP.Features.Module.Commands.Create;
using KnowledgeSharing.APP.Features.Module.Commands.Update;
using KnowledgeSharing.CORE.Entities;

namespace KnowledgeSharing.APP.Common.Mappings;

public sealed class ModuleMappingProfile : Profile
{
    public ModuleMappingProfile()
    {
        CreateMap<CreateModuleCommand, Module>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

        CreateMap<UpdateModuleCommand, Module>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));

        CreateMap<IEnumerable<Module>, ModuleDetailsListDto>()
            .ForMember(dest => dest.Modules, opt => opt.MapFrom(src => src));

        // Exept CreatedBy - it will be mapped in the handler
        CreateMap<Module, ModuleDetailsDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId));
    }
}
