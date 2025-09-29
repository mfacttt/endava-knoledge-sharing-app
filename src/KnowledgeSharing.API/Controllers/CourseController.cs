using MediatR;
using Microsoft.AspNetCore.Mvc;
using KnowledgeSharing.APP.Features.Course.Commands.Create;
using KnowledgeSharing.APP.Features.Course.Commands.Update;
using KnowledgeSharing.APP.Features.Course.Commands.Delete;
using KnowledgeSharing.APP.Features.Course.Queries.GetById;
using KnowledgeSharing.APP.Features.Course.Queries.GetAll;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseCommand command, CancellationToken cancellationToken)
    {
        var response = await sender.Send(command, cancellationToken);
        if (response.IsSuccess == false)
            return BadRequest(response.Errors);
        return CreatedAtAction(nameof(Get), new { id = response.Data }, null);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Route id and body id do not match.");

        await sender.Send(command, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new DeleteCourseCommand(id), cancellationToken);
        if (response.IsSuccess == false)
            return BadRequest(response.Errors);
        return Ok();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCourseByIdQuery(id), cancellationToken);
        if (response.IsSuccess == false)
            return NotFound(response.Errors);
        return Ok(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Get(int page, int pageSize, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetAllCoursesQuery(page, pageSize), cancellationToken);
        if (response.IsSuccess == false)
            return NotFound(response.Errors);
        return Ok(response.Data);
    }
}