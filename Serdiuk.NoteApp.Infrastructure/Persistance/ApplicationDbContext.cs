using Microsoft.EntityFrameworkCore;
using Serdiuk.NoteApp.Appication.Common.Interfaces;
using Serdiuk.NoteApp.Domain;

namespace Serdiuk.NoteApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Note> Notes { get; set; }
    }
}
