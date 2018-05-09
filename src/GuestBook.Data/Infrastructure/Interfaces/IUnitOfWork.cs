using System.Threading.Tasks;

namespace GuestBook.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
