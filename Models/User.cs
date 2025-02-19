using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.Models;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string UserName { get; set; }

    [StringLength(255)]
    public string NickName { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }
}



