using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Note> Notes { get; set; }
        DbSet<Matrix> Matrices { get; set; }
        DbSet<ProgressCondition> ProgressConditions { get; set; }
        DbSet<NoteTask> Tasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
