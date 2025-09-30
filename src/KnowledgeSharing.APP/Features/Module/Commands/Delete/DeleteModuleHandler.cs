using MediatR;
using KnowledgeSharing.APP.Common.DTOs.Responses;

namespace KnowledgeSharing.APP.Features.Module.Commands.Delete;


public sealed class DeleteModuleHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteModuleCommand, Response<bool>>
{
    public async Task<Response<bool>> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
    {
        // get user id from the token
        var guid = Guid.Parse("00000000-0000-0000-0000-000000000001");

        // get module by id
        var module = await unitOfWork.Modules.GetByIdAsync(request.Id, cancellationToken);
        if (module is null)
            return Response<bool>.Failure(new ValidationErrorDto("ModuleId", "Module not found", request.Id.ToString()));

        // check if user is a module author
        if (module.CreatedBy != guid)
            return Response<bool>.Failure(new ValidationErrorDto("ModuleId", "You are not the author of this module", request.Id.ToString()));

        // delete module
        var isDeleted = await unitOfWork.Modules.DeleteAsync(request.Id, cancellationToken);
        if (!isDeleted)
            return Response<bool>.Failure(new ValidationErrorDto("Module", "Module could not be deleted", request.Id.ToString()));
            
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Response<bool>.Success(true);
    }
    
}