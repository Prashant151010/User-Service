using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace User.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]   
    [EnableRateLimiting("fixedLimit")]
    public class AuthController : ControllerBase
    {
    }
}
