namespace BlogApi.Models.Dtos;

public class UserLoginDto
{
    [Required(ErrorMessage = "UserName is required.")]
    public string NickName { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
