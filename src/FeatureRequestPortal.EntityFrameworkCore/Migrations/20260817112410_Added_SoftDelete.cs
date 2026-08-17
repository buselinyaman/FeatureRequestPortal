using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeatureRequestPortal.Migrations
{
    /// <inheritdoc />
    public partial class Added_SoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppFeatureRequests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppFeatureRequests");
        }
    }
}
