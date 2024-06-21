using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListDb : DbContext
    {
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=password");
        }
    }
}
