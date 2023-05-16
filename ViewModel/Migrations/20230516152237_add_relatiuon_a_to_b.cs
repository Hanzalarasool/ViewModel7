using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViewModel.Migrations
{
    /// <inheritdoc />
    public partial class add_relatiuon_a_to_b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AId",
                table: "B",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_B_AId",
                table: "B",
                column: "AId");

            migrationBuilder.AddForeignKey(
                name: "FK_B_A_AId",
                table: "B",
                column: "AId",
                principalTable: "A",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_B_A_AId",
                table: "B");

            migrationBuilder.DropIndex(
                name: "IX_B_AId",
                table: "B");

            migrationBuilder.DropColumn(
                name: "AId",
                table: "B");
        }
    }
}
