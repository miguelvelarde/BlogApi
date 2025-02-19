namespace BlogApi.Models.Dtos;

[Table("Posts")]
public class PostDtoUpdate
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string? ImagePath { get; set; }

    public string Tags { get; set; }

    public DateTime CreatedAt { get; set; }

}