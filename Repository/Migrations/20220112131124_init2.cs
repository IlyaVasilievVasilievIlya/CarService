using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTypes_Mechanics_MechanicId",
                table: "WorkTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkTypes_MechanicId",
                table: "WorkTypes");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "WorkTypes");

            migrationBuilder.CreateTable(
                name: "MechanicWorkType",
                columns: table => new
                {
                    MechanicsId = table.Column<int>(type: "integer", nullable: false),
                    WorkScopeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicWorkType", x => new { x.MechanicsId, x.WorkScopeId });
                    table.ForeignKey(
                        name: "FK_MechanicWorkType_Mechanics_MechanicsId",
                        column: x => x.MechanicsId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicWorkType_WorkTypes_WorkScopeId",
                        column: x => x.WorkScopeId,
                        principalTable: "WorkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicWorkType_WorkScopeId",
                table: "MechanicWorkType",
                column: "WorkScopeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicWorkType");

            migrationBuilder.AddColumn<int>(
                name: "MechanicId",
                table: "WorkTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTypes_MechanicId",
                table: "WorkTypes",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTypes_Mechanics_MechanicId",
                table: "WorkTypes",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
