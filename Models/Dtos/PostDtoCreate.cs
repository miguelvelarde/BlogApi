namespace BlogApi.Models.Dtos;

[Table("Posts")]
public class PostDtoCreate
{  
    [Required(ErrorMessage = "This value is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "This value is required.")]
    public string Content { get; set; }

    public string? ImagePath { get; set; }

    [Required(ErrorMessage = "This value is required.")]
    public string Tags { get; set; }

}