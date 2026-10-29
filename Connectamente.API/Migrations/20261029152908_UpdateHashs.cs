using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHashs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a489f241-4fad-4031-b458-6f6ce664f13d",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJloWmlKfbRt9FF0Vy9gsowjNEV/ex7MuElmj3hIm4Zst97B621qkGzt2HuZjEs+ZA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a489f241-4fad-4031-b458-6f6ce664f13d",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBaLWoe8u2D3VTbHYh5Puil95h2FDKPyVzQ6nCEtjK6IsOR7xd8SUKsCgQoLWjKeTA==");
        }
    }
}
