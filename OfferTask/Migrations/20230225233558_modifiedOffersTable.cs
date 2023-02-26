using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferTask.Migrations
{
    /// <inheritdoc />
    public partial class modifiedOffersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Offers",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Offers",
                newName: "Type");
        }
    }
}
