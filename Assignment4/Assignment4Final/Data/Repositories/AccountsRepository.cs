using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.Accounts;

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
        return await _userManager.FindByEmailAsync(email);
    }

    public List<string> GetAllClaims()
    {
        return _context.UserClaims.ToList().Select(c => c.ClaimValue).Distinct().ToList();
    }

    public async Task<IList<Claim>> GetClaims(AppUser user)
    {
        return await _userManager.GetClaimsAsync(user);
    }

    public string? GetUserRole(string email)
    {
        return GetClaims(GetAppUser(email).Result).Result
            ?.FirstOrDefault(c => c.Type == "role")
            ?.Value;
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

    public async Task<IdentityResult> Create(AppUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<SignInResult> Login(string email, string password)
    {
        var user = await GetAppUser(email);
        return await _signInManager.PasswordSignInAsync(
            user,
            password,
            isPersistent: false,
            lockoutOnFailure: false
        );
    }

    public async Task<IdentityResult> Update(string email, AppUser user, LoginDto? credentials)
    {
        var dbUser = await GetAppUser(email);

        var identityErrors = new List<IdentityError>();

        if (dbUser != null)
        {
            var usernameResult = await _userManager.SetUserNameAsync(dbUser, user.UserName);
            if (!usernameResult.Succeeded)
            {
                identityErrors.AddRange(usernameResult.Errors);
                return IdentityResult.Failed(identityErrors.ToArray());
            }

            var emailResult = await _userManager.SetEmailAsync(dbUser, user.Email);
            if (!emailResult.Succeeded)
            {
                identityErrors.AddRange(emailResult.Errors);
                return IdentityResult.Failed(identityErrors.ToArray());
            }
            else
            {
                dbUser.EmailConfirmed = true;
            }

            var phoneNumberResult = await _userManager.SetPhoneNumberAsync(
                dbUser,
                user.PhoneNumber
            );
            if (!phoneNumberResult.Succeeded)
            {
                identityErrors.AddRange(phoneNumberResult.Errors);
                return IdentityResult.Failed(identityErrors.ToArray());
            }

            if (credentials != null)
            {
                var passwordResult = await _userManager.ChangePasswordAsync(
                    dbUser,
                    credentials.Password,
                    credentials.NewPassword
                );

                if (!passwordResult.Succeeded)
                {
                    identityErrors.AddRange(passwordResult.Errors);
                    return IdentityResult.Failed(identityErrors.ToArray());
                }
                else
                {
                    dbUser.LockoutEnabled = false;
                }
            }

            return await _userManager.UpdateAsync(dbUser);
        }

        return IdentityResult.Failed(
            new IdentityError
            {
                Code = "User",
                Description = $"Could not find User with email {email}"
            }
        );
    }

    public async Task<IdentityResult> Delete(string email)
    {
        var user = await GetAppUser(email);
        return await _userManager.DeleteAsync(user);
    }
}
