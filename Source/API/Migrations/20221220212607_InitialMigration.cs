using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OCBManager.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TurnoverSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomingBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutgoingBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutgoingBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoverSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurnoverSheetId = table.Column<int>(type: "int", nullable: false),
                    IncomingBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomingBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutgoingBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutgoingBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillClasses_TurnoverSheets_TurnoverSheetId",
                        column: x => x.TurnoverSheetId,
                        principalTable: "TurnoverSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    IncomingBalanceId = table.Column<int>(type: "int", nullable: false),
                    OutgoingBalanceId = table.Column<int>(type: "int", nullable: false),
                    TurnoverId = table.Column<int>(type: "int", nullable: false),
                    BillClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_BillClasses_BillClassId",
                        column: x => x.BillClassId,
                        principalTable: "BillClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomingBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Passive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingBalances_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutgoingBalances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Passive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutgoingBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutgoingBalances_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turnovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnovers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnovers_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillClasses_TurnoverSheetId",
                table: "BillClasses",
                column: "TurnoverSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BillClassId",
                table: "Bills",
                column: "BillClassId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingBalances_BillId",
                table: "IncomingBalances",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutgoingBalances_BillId",
                table: "OutgoingBalances",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnovers_BillId",
                table: "Turnovers",
                column: "BillId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomingBalances");

            migrationBuilder.DropTable(
                name: "OutgoingBalances");

            migrationBuilder.DropTable(
                name: "Turnovers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "BillClasses");

            migrationBuilder.DropTable(
                name: "TurnoverSheets");
        }
    }
}
