using MediatR;
using Microsoft.AspNetCore.Mvc;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Enroll;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;
using GetCourseEnrollmentsQuery = KnowledgeSharing.APP.Features.CourseEnrollment.Queries.GetAll.GetEnrollmentsByCourseIdQuery;

[ApiController]
[Route("api/courses/{courseId:int}/[controller]")]
public class ContributorController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new EnrollUserCommand(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Remove([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new UnenrollUserCommand(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCourseEnrollmentsQuery(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok(response.Data);
    }
}