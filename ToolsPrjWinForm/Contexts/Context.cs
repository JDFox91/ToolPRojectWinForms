using System.Data.Entity;
using ToolsPrjWinForm.Entities;

namespace ToolsPrjWinForm.Contexts
{
    class Context : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
