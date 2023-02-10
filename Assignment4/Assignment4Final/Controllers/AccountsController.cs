using Assignment4Final.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Models.DTO.Accounts;

namespace Assignment4Final.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly AccountsService _service;

    public AccountsController(AccountsService accountsService)
    {
        _service = accountsService;
    }

    [HttpGet("listUsers")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult<List<UserDto>>> GetListUsers()
    {
        return await _service.GetListUsers();
    }

    [HttpGet("getUser")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult<UserDto>> GetUser(string email)
    {
        var user = await _service.GetUser(email);

        if (user == null)
        {
            return NotFound($"Could not find user with email {email}");
        }

        return Ok(user);
    }

    [HttpPost("makeAdmin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeAdmin(string email)
    {
        await _service.MakeAdmin(email);
        return NoContent();
    }

    [HttpPost("removeAdmin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveAdmin(string email)
    {
        await _service.RemoveAdmin(email);
        return NoContent();
    }

    [HttpPost("makeMarker")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeMarker(string email)
    {
        await _service.MakeMarker(email);
        return NoContent();
    }

    [HttpPost("removeMarker")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveMarker(string email)
    {
        await _service.RemoveMarker(email);
        return NoContent();
    }

    [HttpPost("makeQualityControl")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeQualityControl(string email)
    {
        await _service.MakeQualityControl(email);
        return NoContent();
    }

    [HttpPost("removeQualityControl")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveQualityControl(string email)
    {
        await _service.RemoveQualityControl(email);
        return NoContent();
    }

    [HttpPost("makeCandidate")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeCandidate(string email)
    {
        await _service.MakeCandidate(email);
        return NoContent();
    }

    [HttpPost("removeCandidate")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveCandidate(string email)
    {
        await _service.RemoveCandidate(email);
        return NoContent();
    }

    [HttpPost("create")]
    public async Task<ActionResult<AuthenticationResponseDto>> Create([FromBody] UserDto user)
    {
        var authResponse = await _service.Create(user);

        if (authResponse == null)
        {
            return BadRequest("Please provide login credentials");
        }

        if (authResponse.Errors != null)
        {
            return BadRequest(authResponse.Errors);
        }

        return Ok(authResponse);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponseDto>> Login(
        [FromBody] LoginDto userCredentials
    )
    {
        var authResponse = await _service.Login(userCredentials);

        if (authResponse == null)
        {
            return BadRequest("Incorrect Login");
        }

        return Ok(authResponse);
    }

    [HttpPut("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<IActionResult> Update(string email, [FromBody] UserDto userDto)
    {
        var updateResult = await _service.Update(email, userDto);

        if (!updateResult.Succeeded)
        {
            return BadRequest(updateResult.Errors);
        }

        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<IActionResult> Delete(string email)
    {
        var deleteResult = await _service.Delete(email);

        if (!deleteResult.Succeeded)
        {
            return BadRequest(deleteResult.Errors);
        }

        return NoContent();
    }
}
