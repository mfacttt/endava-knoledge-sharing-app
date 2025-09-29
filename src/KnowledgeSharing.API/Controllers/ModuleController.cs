using MediatR;
using Microsoft.AspNetCore.Mvc;
using KnowledgeSharing.APP.Features.Module.Commands.Create;
using KnowledgeSharing.APP.Features.Module.Commands.Update;
using KnowledgeSharing.APP.Features.Module.Commands.Delete;
using KnowledgeSharing.APP.Features.Module.Queries.GetById;
using KnowledgeSharing.APP.Features.Module.Queries.GetAll;

[ApiController]
[Route("api/[controller]")]
public class ModuleController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateModuleCommand command, CancellationToken cancellationToken)
    {
        var response = await sender.Send(command, cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);

        return CreatedAtAction(nameof(Get), new { id = response.Data }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateModuleCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Route id and body id do not match.");

        var response = await sender.Send(command, cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new DeleteModuleCommand(id), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetModuleByIdQuery(id), cancellationToken);
        if (!response.IsSuccess)
            return NotFound(response.Errors);

        return Ok(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int courseId, [FromQuery] int page, [FromQuery] int pageSize, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetModulesByCourseIdQuery(courseId, page, pageSize), cancellationToken);
        if (!response.IsSuccess)
            return NotFound(response.Errors);

        return Ok(response.Data);
    }
}
