using Microsoft.EntityFrameworkCore;
using DataModel.DomainClasses;

namespace Yara.Infrastructure.Data.Context
{
    public partial class YaraContext : DbContext, IYaraContext
    {
        public YaraContext()
        {
        }

        public YaraContext(DbContextOptions<YaraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public DbSet<AccountPermission> AccountPermissions { get; set; }
        public virtual DbSet<DocumentFile> DocumentFiles { get; set; }
       
        public virtual DbSet<Analysis> Analysis { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Yara;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
