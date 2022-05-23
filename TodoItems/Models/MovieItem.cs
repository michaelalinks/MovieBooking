using System.ComponentModel.DataAnnotations;

public class MovieItem
{
    [Key]
    public int Id { get; set; } // primary key

    [Required(ErrorMessage = "Movie title is required")]
    public string? MovieTitle{ get; set; }
}