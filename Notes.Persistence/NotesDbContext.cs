using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Matrix> Matrices { get; set; }
        public DbSet<ProgressCondition> ProgressConditions { get; set; }
        public DbSet<NoteTask> Tasks { get; set; }
    }
    class Testing
    {
        private void Test(NotesDbContext context)
        {
            context.SaveChangesAsync();
        }
    }
}
