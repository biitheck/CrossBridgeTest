namespace Contacts.Web.Data
{
    using Contacts.Domain;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        #region Properties
        public DbSet<Contact> Contacts { get; set; }
        #endregion

        #region Constructors

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        #region Protected Overrides Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
