using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ModelLibrary.Models.DTO.Accounts;

public class LoginDto
{
    // public string? Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? NewPassword { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsCandidate { get; set; }
}
