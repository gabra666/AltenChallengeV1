using AltenChallengeV1.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace AltenChallengeV1.Persistence
{
    public class AltenChallengeContext : DbContext
    {
        public AltenChallengeContext(DbContextOptions<AltenChallengeContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
