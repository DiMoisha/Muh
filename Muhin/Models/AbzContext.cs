using System.Data.Entity;


namespace Muh.Models
{
    public class AbzContext : DbContext
    {
        public AbzContext()
            : base("name=AbzConnection")
        {
        }
         public DbSet<Muhin> Muhins { get; set; }
        public DbSet<Categ> Categs { get; set; }
        public DbSet<HourView> HourViews { get; set; }
        public DbSet<GraphSale> GraphSales { get; set; }
        public DbSet<Repab> Repabs { get; set; }
    }

}
