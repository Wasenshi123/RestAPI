namespace DAL
{
    using System.Data.Entity;

    public partial class CreditCardContext : DbContext
    {
        public CreditCardContext()
            : base("name=CreditCardContext")
        {
        }

        public virtual DbSet<Cards> Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
