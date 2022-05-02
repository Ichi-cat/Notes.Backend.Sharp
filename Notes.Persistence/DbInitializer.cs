using Notes.Domain;
using System.Linq;

namespace Notes.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            if (!context.Matrices.Any())
            {
                var IU = new Matrix { Id = MatricesEnum.ImportantUrgent, Name = "ImportantUrgent" };
                var INU = new Matrix { Id = MatricesEnum.ImportantNotUrgent, Name = "ImportantNotUrgent" };
                var NIU = new Matrix { Id = MatricesEnum.NotImportantUrgent, Name = "NotImportantUrgent" };
                var NINU = new Matrix { Id = MatricesEnum.NotImportantNotUrgent, Name = "NotImportantNotUrgent" };
                context.Matrices.AddRange(IU, INU, NIU, NINU);
                context.SaveChanges();
            }
            //context.Database.EnsureDeleted();
            //context.Database.Migrate();
            //context.Database.EnsureCreated();
        }
    }
}
