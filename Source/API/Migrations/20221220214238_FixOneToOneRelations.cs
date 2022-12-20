using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCBManager.API.Migrations
{
    /// <inheritdoc />
    public partial class FixOneToOneRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomingBalanceId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "OutgoingBalanceId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TurnoverId",
                table: "Bills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncomingBalanceId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutgoingBalanceId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TurnoverId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
