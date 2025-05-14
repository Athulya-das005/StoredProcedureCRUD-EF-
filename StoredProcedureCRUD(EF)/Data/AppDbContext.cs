using Microsoft.EntityFrameworkCore;
using StoredProcedureCRUD_EF_.Model;

namespace StoredProcedureCRUD_EF_.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

    }
}
