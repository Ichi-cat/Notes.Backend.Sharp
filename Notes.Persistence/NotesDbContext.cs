using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Diagnostics;

namespace Notes.Persistence
{
    public class NotesDbContext : DbContext, INotesDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Matrix> Matrices { get; set; }
        public DbSet<ProgressCondition> ProgressConditions { get; set; }
        public DbSet<NoteTask> Tasks { get; set; }
        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Notes.db");
            //optionsBuilder.LogTo(Prn, new[] { RelationalEventId.CommandExecuted });
            //optionsBuilder.LogTo(Prn, LogLevel.Trace);
        }
        //private void Prn(string print)
        //{
        //    Debug.WriteLine(print);
        //}
    }
    class Testing
    {
        private void Test(NotesDbContext context)
        {
            context.SaveChangesAsync();
        }
    }
}
