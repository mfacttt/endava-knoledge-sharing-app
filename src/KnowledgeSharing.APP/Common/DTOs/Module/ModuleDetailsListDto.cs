namespace KnowledgeSharing.APP.Common.DTOs.Module;

public sealed class ModuleDetailsListDto
{
    public IEnumerable<ModuleDetailsDto> Modules { get; init; } = Array.Empty<ModuleDetailsDto>();
}