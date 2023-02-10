using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;

namespace Assignment4Final.Data.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ApplicationDbContext _context;

    public AccountsRepository(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ApplicationDbContext context
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<List<AppUser>> ListUsers()
    {
        var queryable = _context.Users.AsQueryable();
        return await queryable.OrderBy(x => x.Email).ToListAsync();
    }

    public async Task<AppUser> GetAppUser(string email)
    {
        return await _userManager.FindByNameAsync(email);
    }

    public async Task<IList<Claim>> GetClaims(AppUser user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public async Task MakeAdmin(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.AddClaimAsync(user, new Claim("role", "admin"));
    }

    public async Task RemoveAdmin(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.RemoveClaimAsync(user, new Claim("role", "admin"));
    }

    public async Task MakeMarker(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.AddClaimAsync(user, new Claim("role", "marker"));
    }

    public async Task RemoveMarker(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.RemoveClaimAsync(user, new Claim("role", "marker"));
    }

    public async Task MakeQualityControl(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.AddClaimAsync(user, new Claim("role", "qualitycontrol"));
    }

    public async Task RemoveQualityControl(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.RemoveClaimAsync(user, new Claim("role", "qualitycontrol"));
    }

    public async Task MakeCandidate(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.AddClaimAsync(user, new Claim("role", "candidate"));
    }

    public async Task RemoveCandidate(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        await _userManager.RemoveClaimAsync(user, new Claim("role", "candidate"));
    }

    public async Task<IdentityResult> Create(string email, string password)
    {
        var user = new AppUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            LockoutEnabled = false
        };
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<SignInResult> Login(string email, string password)
    {
        return await _signInManager.PasswordSignInAsync(
            email,
            password,
            isPersistent: false,
            lockoutOnFailure: false
        );
    }
}
