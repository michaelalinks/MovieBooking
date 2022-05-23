using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BookingDetailsItem
{
    [Key]
    public int Id { get; set; } // primary key
    public string? fName { get; set; }
    public string? lName { get; set; }
    
    [ForeignKey("TicketAvailabilityItem")]
    public string? TicketAvailabilityItemID { get; set; } //foreign key

    [ForeignKey("MovieItem")]
    public string? MovieItemID { get; set; } //foreign key
    public string? no_tickets { get; set; }

    
}