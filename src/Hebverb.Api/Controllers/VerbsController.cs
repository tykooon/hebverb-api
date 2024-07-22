using Microsoft.AspNetCore.Mvc;

namespace Hebverb.Api.Controllers;

public class VerbsController : BaseApiController
{
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new { verbId = id });
    }
}
