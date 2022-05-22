using Microsoft.EntityFrameworkCore;
using TodoItems.Migrations;
using TodoItems.Models;

namespace TodoItems.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Student> Students { get; set; } 
    }

}
