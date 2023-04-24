using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Appication.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
