using Microsoft.EntityFrameworkCore;
using Social.Manager.DAL.Models;

namespace Social.Manager.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<PersonalInformation> PersonnalInformations { get; set; }
    }
}
