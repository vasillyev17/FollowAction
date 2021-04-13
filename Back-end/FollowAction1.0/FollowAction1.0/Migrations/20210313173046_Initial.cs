using Microsoft.EntityFrameworkCore.Migrations;

namespace FollowAction1._0.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    idBuyer = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Priority = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.idBuyer);
                });

            migrationBuilder.CreateTable(
                name: "BuyerAction",
                columns: table => new
                {
                    idAction = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idBuyer = table.Column<int>(nullable: false),
                    ActionType = table.Column<string>(nullable: true),
                    ActionTarget = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerAction", x => x.idAction);
                });

            migrationBuilder.CreateTable(
                name: "BuyerMovement",
                columns: table => new
                {
                    idMovement = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idBuyer = table.Column<int>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    StartPoint = table.Column<string>(nullable: true),
                    EndPoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerMovement", x => x.idMovement);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    idDepartment = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.idDepartment);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    idProduct = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idDepartment = table.Column<int>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.idProduct);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    idPurchase = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idBuyer = table.Column<int>(nullable: false),
                    idProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.idPurchase);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "BuyerAction");

            migrationBuilder.DropTable(
                name: "BuyerMovement");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
