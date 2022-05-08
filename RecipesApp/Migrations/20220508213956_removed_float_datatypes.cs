using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class removed_float_datatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Shortcut",
                table: "Units",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<float>(
                name: "Fat",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(10)");

            migrationBuilder.AlterColumn<float>(
                name: "Carbohydrates",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(10)");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(10)");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Ingredients",
                type: "real",
                nullable: false,
                defaultValue: 1f,
                oldClrType: typeof(float),
                oldType: "float(10)",
                oldDefaultValue: 1f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Shortcut",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Products",
                type: "float(10)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<float>(
                name: "Fat",
                table: "Products",
                type: "float(10)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Carbohydrates",
                table: "Products",
                type: "float(10)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Products",
                type: "float(10)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "Ingredients",
                type: "float(10)",
                nullable: false,
                defaultValue: 1f,
                oldClrType: typeof(float),
                oldType: "real",
                oldDefaultValue: 1f);
        }
    }
}
