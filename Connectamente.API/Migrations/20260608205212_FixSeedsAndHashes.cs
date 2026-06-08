using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedsAndHashes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIeHlzWfJt5o6qNf4kZ0B9vLmR6w7qN1mXyPzR9WvB5tQw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEG6W2m1Hk8zN3qXyR8vLmR6w7qN1mXyPzR9WvB5tQw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJcjde/0ssn6LhgG9MKJy9yzZ41ElyHCKIzuilcpALSUzTGcEj+8Vla+dZZVrDArww==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM+XB1X3FEJT3JMrvhA/5n0xZya7ABnWjPtTx8mkK4EFLewzh/thUm6nhbCXlkElXA==");
        }
    }
}
