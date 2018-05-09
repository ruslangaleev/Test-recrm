using GuestBook.Data.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace GuestBook.Data.Infrastructure.Logic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(IStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(IStorage));
            }

            var context = storage as ApplicationDbContext;
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
