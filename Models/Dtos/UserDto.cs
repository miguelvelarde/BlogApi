namespace BlogApi.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "UserName is required.")]
    public string UserName { get; set; }

    public string NickName { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}



