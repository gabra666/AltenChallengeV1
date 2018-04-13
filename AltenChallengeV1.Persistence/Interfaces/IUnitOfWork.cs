using System.Threading.Tasks;

namespace AltenChallengeV1.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}