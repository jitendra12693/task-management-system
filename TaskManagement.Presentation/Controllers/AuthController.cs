using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TaskManagement.Application;
using TaskManagement.Application.Dtos;

namespace TaskManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _cache=memoryCache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand req)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            var result = await _mediator.Send(req);
            if(result.StatusCode!=200)
                return BadRequest(new { errors = result.StatusMessage });
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand req)
        {
            return Ok(await _mediator.Send(req));
        }

        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            bool isAvailable = _cache.TryGetValue("users", out Response users);
            if (!isAvailable)
            {
                users = await _mediator.Send(new GetAllUserQuery());
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set("users", users, cacheEntryOptions);
            }
            return Ok(await _mediator.Send(new GetAllUserQuery()));
        }
    }
}
