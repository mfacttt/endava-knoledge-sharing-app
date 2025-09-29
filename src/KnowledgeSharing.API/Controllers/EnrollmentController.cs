using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Enroll;
using KnowledgeSharing.APP.Features.CourseEnrollment.Command.Unenroll;
using KnowledgeSharing.APP.Features.CourseEnrollment.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/courses/{courseId:int}/[controller]")]
public class EnrollmentController(ISender sender) : ControllerBase
{
    [HttpPost("{courseId:int}/[controller]")]
    public async Task<IActionResult> Enroll([FromRoute] int courseId, CancellationToken cancellationToken, Guid userId = default)
    {
        var response = await sender.Send(new EnrollUserCommand(courseId, userId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpDelete("{courseId:int}/[controller]")]
    public async Task<IActionResult> Unenroll([FromRoute] int courseId, CancellationToken cancellationToken, Guid userId = default)
    {
        var response = await sender.Send(new UnenrollUserCommand(courseId, userId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok();
    }

    [HttpGet("{courseId:int}/[controller]")]
    public async Task<IActionResult> GetEnrollments([FromRoute] int courseId, CancellationToken cancellationToken)
    {
        var response = await sender.Send(new GetCourseEnrollmentsQuery(courseId), cancellationToken);
        if (!response.IsSuccess)
            return BadRequest(response.Errors);
        return Ok(response.Data);
    }
}
