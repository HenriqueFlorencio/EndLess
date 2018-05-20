using System.Data.Entity;

namespace EndLess.Data.EF
{
    public class DbInitializer: CreateDatabaseIfNotExists<EndLessDataContext>
    {
        protected override void Seed(EndLessDataContext context)
        {
            //base.Seed(context);
        }
    }
}
