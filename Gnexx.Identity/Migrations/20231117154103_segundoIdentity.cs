using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gnexx.Identity.Migrations
{
    /// <inheritdoc />
    public partial class segundoIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                schema: "Identity",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                schema: "Identity",
                table: "AspNetUsers");
        }
    }
}
