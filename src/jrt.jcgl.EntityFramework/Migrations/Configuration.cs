using System.Data.Entity.Migrations;
using jrt.jcgl.Migrations.Seed;

namespace jrt.jcgl.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<jcgl.EntityFramework.AbpZeroTemplateDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpZeroTemplate";
        }

        protected override void Seed(jcgl.EntityFramework.AbpZeroTemplateDbContext context)
        {
            new InitialDbBuilder(context).Create();
        }
    }
}
