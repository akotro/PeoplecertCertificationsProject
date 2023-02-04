using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assignment4Final.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.Accounts;

namespace Assignment4Final.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountsController : ControllerBase
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly IConfiguration configuration;
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;

    public AccountsController(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IConfiguration configuration,
        ApplicationDbContext context,
        IMapper mapper
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet("listUsers")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult<List<UserDto>>> GetListUsers()
    {
        var queryable = context.Users.AsQueryable();
        var users = await queryable.OrderBy(x => x.Email).ToListAsync();
        return mapper.Map<List<UserDto>>(users);
    }

    [HttpPost("makeAdmin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeAdmin([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.AddClaimAsync(user, new Claim("role", "admin"));
        return NoContent();
    }

    [HttpPost("removeAdmin")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveAdmin([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.RemoveClaimAsync(user, new Claim("role", "admin"));
        return NoContent();
    }

    [HttpPost("makeMarker")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeMarker([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.AddClaimAsync(user, new Claim("role", "marker"));
        return NoContent();
    }

    [HttpPost("removeMarker")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveMarker([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.RemoveClaimAsync(user, new Claim("role", "marker"));
        return NoContent();
    }

    [HttpPost("makeQualityControl")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeQualityControl([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.AddClaimAsync(user, new Claim("role", "qualitycontrol"));
        return NoContent();
    }

    [HttpPost("removeQualityControl")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveQualityControl([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.RemoveClaimAsync(user, new Claim("role", "qualitycontrol"));
        return NoContent();
    }

    [HttpPost("makeCandidate")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> MakeCandidate([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.AddClaimAsync(user, new Claim("role", "candidate"));
        return NoContent();
    }

    [HttpPost("removeCandidate")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public async Task<ActionResult> RemoveCandidate([FromBody] string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        await userManager.RemoveClaimAsync(user, new Claim("role", "candidate"));
        return NoContent();
    }

    [HttpPost("create")]
    public async Task<ActionResult<AuthenticationResponseDto>> Create(
        [FromBody] LoginDto userCredentials
    )
    {
        var user = new AppUser
        {
            UserName = userCredentials.Email,
            Email = userCredentials.Email,
            EmailConfirmed = true,
            LockoutEnabled = false
        };
        var result = await userManager.CreateAsync(user, userCredentials.Password);

        if (result.Succeeded)
        {
            return await BuildToken(userCredentials);
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponseDto>> Login(
        [FromBody] LoginDto userCredentials
    )
    {
        var result = await signInManager.PasswordSignInAsync(
            userCredentials.Email,
            userCredentials.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (result.Succeeded)
        {
            return await BuildToken(userCredentials);
        }
        else
        {
            return BadRequest("Incorrect Login");
        }
    }

    private async Task<AuthenticationResponseDto> BuildToken(LoginDto userCredentials)
    {
        var claims = new List<Claim>() { new Claim("email", userCredentials.Email) };

        var user = await userManager.FindByNameAsync(userCredentials.Email);
        var claimsDB = await userManager.GetClaimsAsync(user);

        claims.AddRange(claimsDB);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddYears(1);

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        return new AuthenticationResponseDto()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}
