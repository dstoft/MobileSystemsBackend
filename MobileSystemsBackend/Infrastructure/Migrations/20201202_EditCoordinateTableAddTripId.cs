using FluentMigrator;

namespace MobileSystemsBackend.Infrastructure.Migrations
{
    [Migration(202012022224)]
    public class EditCoordinateTableAddTripId : Migration
    {
        public override void Up()
        {
            Alter.Table("Coordinate").AddColumn("TripId").AsInt32().ForeignKey("Trip", "Id");
        }

        public override void Down()
        {
            Delete.Column("TripId").FromTable("Coordinate");
        }
    }
}