using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreTemplate.Application.Users.SearchUsers;

namespace NetCoreTemplate.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("Hello")]
    public IActionResult Hello()
    {
        return Ok("Hello world");
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var commnad = new SearchUserCommand();

        var result = await _sender.Send(commnad, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public IActionResult Update()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }

}
