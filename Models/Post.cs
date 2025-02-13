namespace BlogApi.Models;

[Table("Posts")] // Nombre de la tabla en la base de datos
public class Post
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental
    public int Id { get; set; }

    [Required]
    [StringLength(255)] 
    public string Title { get; set; }

    [Required]
    [StringLength(5000)] 
    public string Content { get; set; }
    
    public string? ImagePath { get; set; }

    [Required]
    [StringLength(100)] 
    public string Tags { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
