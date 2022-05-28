using Notes.Domain;
using System.Linq;

namespace Notes.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(NotesDbContext context)
        {
            CreateBaseMatrices(context);
            CreateBaseProgressConditions(context);
        }
        private static void CreateBaseMatrices(NotesDbContext context)
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
        }
        private static void CreateBaseProgressConditions(NotesDbContext context)
        {
            if (!context.ProgressConditions.Any())
            {
                var planned = new ProgressCondition { Id = ProgressConditionEnum.Planned, Name = "Planned" };
                var during = new ProgressCondition { Id = ProgressConditionEnum.During, Name = "During" };
                var ready = new ProgressCondition { Id = ProgressConditionEnum.Ready, Name = "Ready" };
                context.ProgressConditions.AddRange(planned, during, ready);
                context.SaveChanges();
            }
        }
    }
}
