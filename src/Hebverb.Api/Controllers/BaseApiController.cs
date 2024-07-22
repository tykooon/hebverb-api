using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Hebverb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BaseApiController : ControllerBase
{
}
