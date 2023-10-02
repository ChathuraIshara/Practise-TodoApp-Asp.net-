using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoContextDb:DbContext
    {
        public TodoContextDb(DbContextOptions<TodoContextDb> options):base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo { Id = 1, Title = "play cricket" },
                new Todo { Id = 2, Title = "go to the market" },
                new Todo { Id = 3, Title = "sing songs" }
                );


        }
    }
}
