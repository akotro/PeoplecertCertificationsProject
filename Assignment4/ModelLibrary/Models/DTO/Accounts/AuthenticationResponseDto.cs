namespace ModelLibrary.Models.DTO.Accounts;

public class AuthenticationResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
