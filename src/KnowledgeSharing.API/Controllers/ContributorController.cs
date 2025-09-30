using MediatR;
using Microsoft.AspNetCore.Mvc;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Enroll;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;
using GetCourseEnrollmentsQuery = KnowledgeSharing.APP.Features.CourseEnrollment.Queries.GetAll.GetEnrollmentsByCourseIdQuery;

public class ContributorController(ISender sender) : ControllerBase
{
    [HttpPost("{courseId:int}/[controller]")]
    public async Task<IActionResult> Add([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new EnrollUserCommand(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpDelete("{courseId:int}/[controller]")]
    public async Task<IActionResult> Remove([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new UnenrollUserCommand(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpGet("{courseId:int}/[controller]")]
    public async Task<IActionResult> Get([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCourseEnrollmentsQuery(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok(response.Data);
    }
}