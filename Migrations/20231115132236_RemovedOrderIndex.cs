using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalSectorManager.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOrderIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "Sectors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "Sectors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
