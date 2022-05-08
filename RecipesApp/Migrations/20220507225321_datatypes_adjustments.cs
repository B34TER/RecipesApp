using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesApp.Migrations
{
    public partial class datatypes_adjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Products",
                type: "float(10)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "FoodGroupId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Protein",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(10)");

            migrationBuilder.AlterColumn<int>(
                name: "FoodGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
