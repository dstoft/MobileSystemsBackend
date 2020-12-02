using FluentMigrator;

namespace MobileSystemsBackend.Infrastructure.Migrations
{
    [Migration(202012022206)]
    public class AddTripTable : Migration
    {
        public override void Up()
        {
            Create.Table("Trip")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Time").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("Trip");
        }
    }
}