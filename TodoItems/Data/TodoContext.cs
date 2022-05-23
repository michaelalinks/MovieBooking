using Microsoft.EntityFrameworkCore;
using TodoItems.Controllers;
using TodoItems.Migrations;


namespace TodoItems.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        // doesn't need import because Models classes don't have namespace
        public DbSet<TodoItem> TodoItems { get; set; } // plural because a Collection
        public DbSet<MovieItem> MovieItems { get; set; }
        public DbSet<TicketAvailabilityItem> AvailabilityItems { get; set; }
        public DbSet<BookingDetailsItem> BookingItems { get; set; }
    }

}
