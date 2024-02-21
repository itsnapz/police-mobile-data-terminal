using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class newmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Citizens_CitizenId",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropColumn(
                name: "Fine",
                table: "Record");

            migrationBuilder.RenameTable(
                name: "Record",
                newName: "Records");

            migrationBuilder.RenameIndex(
                name: "IX_Record_CitizenId",
                table: "Records",
                newName: "IX_Records_CitizenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Records",
                table: "Records",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CitizenId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReleasedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    CitizenId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warrants_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fines_CitizenId",
                table: "Fines",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_Warrants_CitizenId",
                table: "Warrants",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Citizens_CitizenId",
                table: "Records",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Citizens_CitizenId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Warrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Records",
                table: "Records");

            migrationBuilder.RenameTable(
                name: "Records",
                newName: "Record");

            migrationBuilder.RenameIndex(
                name: "IX_Records_CitizenId",
                table: "Record",
                newName: "IX_Record_CitizenId");

            migrationBuilder.AddColumn<int>(
                name: "Fine",
                table: "Record",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Citizens_CitizenId",
                table: "Record",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
