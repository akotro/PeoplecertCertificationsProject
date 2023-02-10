using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ModelLibrary.Models;
using ModelLibrary.Models.DTO.Accounts;

namespace Assignment4Final.Data.Repositories;

public interface IAccountsRepository
{
    Task<List<AppUser>> ListUsers();
    Task<AppUser> GetAppUser(string email);
    Task<IList<Claim>> GetClaims(AppUser user);
    Task MakeAdmin(string email);
    Task RemoveAdmin(string email);
    Task MakeMarker(string email);
    Task RemoveMarker(string email);
    Task MakeQualityControl(string email);
    Task RemoveQualityControl(string email);
    Task MakeCandidate(string email);
    Task RemoveCandidate(string email);
    Task<IdentityResult> Create(AppUser user, string password);
    Task<SignInResult> Login(string email, string password);
    Task<IdentityResult> Update(string email, AppUser user, LoginDto? credentials = null);
    Task<IdentityResult> Delete(string email);
}
