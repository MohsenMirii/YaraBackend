using DataModel.DomainClasses;
using Microsoft.EntityFrameworkCore;

namespace Yara.Infrastructure.Data.Context
{
    public interface IYaraContext
    {
        DbSet<Account> Account { get; set; }
        DbSet<Permission> Permission { get; set; }
        DbSet<AccountPermission> AccountPermissions { get; set; }
        DbSet<Analysis> Analysis { get; set; }
        DbSet<DocumentFile> DocumentFiles { get; set; }
        
    }
}