namespace Wasenshi.CreditCard.DAL
{
    using System.Data.Entity;
    using Wasenshi.CreditCard.DAL.Models;

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
