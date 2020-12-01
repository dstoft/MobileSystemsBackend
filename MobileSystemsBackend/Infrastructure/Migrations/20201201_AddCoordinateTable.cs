using FluentMigrator;

namespace MobileSystemsBackend.Infrastructure.Migrations
{
    // https://dotnetcorecentral.com/blog/fluentmigrator/
    // https://fluentmigrator.github.io/articles/quickstart.html?tabs=runner-in-process
    [Migration(202012011607)]
    public class AddCoordinateTable : Migration
    {
        public override void Up()
        {
            Create.Table("Coordinate")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Time").AsInt64()
                .WithColumn("Latitude").AsDouble()
                .WithColumn("Longitude").AsDouble();
        }

        public override void Down()
        {
            Delete.Table("Coordinate");
        }
    }
}