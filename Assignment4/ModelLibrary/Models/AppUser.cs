using Microsoft.AspNetCore.Identity;
using ModelLibrary.Models.Candidates;

namespace ModelLibrary.Models;

public class AppUser : IdentityUser
{
    public Candidate Candidate { get; set; }
}
