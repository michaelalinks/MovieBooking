using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TicketAvailabilityItem
{
    [Key]
    public int Id { get; set; } // primary key

   [ForeignKey("MovieItem")]
    public string? MovieItemID { get; set; } // foreign key
    public string? booking_date { get; set; }
    public string? seats { get; set; }
}