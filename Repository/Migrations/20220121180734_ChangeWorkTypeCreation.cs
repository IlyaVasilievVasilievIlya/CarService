using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ChangeWorkTypeCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCars_Cars_CarId",
                table: "ClientCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCars_Clients_ClientId",
                table: "ClientCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ClientCars_ClientCarId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ClientCarId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ClientCars",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ClientCars",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCars_Cars_CarId",
                table: "ClientCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCars_Clients_ClientId",
                table: "ClientCars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ClientCars_ClientCarId",
                table: "Orders",
                column: "ClientCarId",
                principalTable: "ClientCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCars_Cars_CarId",
                table: "ClientCars");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCars_Clients_ClientId",
                table: "ClientCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ClientCars_ClientCarId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ClientCarId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ClientCars",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "ClientCars",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCars_Cars_CarId",
                table: "ClientCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCars_Clients_ClientId",
                table: "ClientCars",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ClientCars_ClientCarId",
                table: "Orders",
                column: "ClientCarId",
                principalTable: "ClientCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
