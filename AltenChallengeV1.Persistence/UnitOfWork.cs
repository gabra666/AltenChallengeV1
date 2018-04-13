using System.Threading.Tasks;
using AltenChallengeV1.Persistence.Interfaces;

namespace AltenChallengeV1.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        AltenChallengeContext context;

        public UnitOfWork(AltenChallengeContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}