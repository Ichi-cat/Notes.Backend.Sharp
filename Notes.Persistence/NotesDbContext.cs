using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
	            v => v.ToUniversalTime(),
	            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

			var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
				v => v.HasValue ? v.Value.ToUniversalTime() : v,
				v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

			foreach (var entityType in modelBuilder.Model.GetEntityTypes())
			{
				if (entityType.IsKeyless)
				{
					continue;
				}

				foreach (var property in entityType.GetProperties())
				{
					if (property.ClrType == typeof(DateTime))
					{
						property.SetValueConverter(dateTimeConverter);
					}
					else if (property.ClrType == typeof(DateTime?))
					{
						property.SetValueConverter(nullableDateTimeConverter);
					}
				}
			}
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
