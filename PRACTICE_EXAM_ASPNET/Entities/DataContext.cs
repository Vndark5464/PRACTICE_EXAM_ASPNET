using Microsoft.EntityFrameworkCore;

namespace PRACTICE_EXAM_ASPNET.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}