using MCTS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MCTS.DB
{
    public class MctsContext : DbContext
    {
        public MctsContext(DbContextOptions<MctsContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
