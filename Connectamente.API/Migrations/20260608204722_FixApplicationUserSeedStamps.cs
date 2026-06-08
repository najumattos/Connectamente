using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connectamente.API.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationUserSeedStamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef7a1510-9177-4c44-b0cf-5b12da6bf121", "AQAAAAIAAYagAAAAEJcjde/0ssn6LhgG9MKJy9yzZ41ElyHCKIzuilcpALSUzTGcEj+8Vla+dZZVrDArww==", "ef7a1510-9177-4c44-b0cf-5b12da6bf121" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc3101aa-2831-4e44-88aa-cc1234567890", "AQAAAAIAAYagAAAAEM+XB1X3FEJT3JMrvhA/5n0xZya7ABnWjPtTx8mkK4EFLewzh/thUm6nhbCXlkElXA==", "bc3101aa-2831-4e44-88aa-cc1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18fbcde-1111-42b1-b4fa-4b8c0c45daaa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c741a86a-dcf9-4279-9a42-82e3747bfd93", "AQAAAAIAAYagAAAAEDoIXKfB9IJ4sohgbpJSkmvnEKE/0Q+iiBSiLlCIC+eTw+PxaqvRQisWf7ccQ1smtQ==", "55cb01dc-9dd6-4805-bcf3-151c1b07d459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b29fbcde-2222-53c2-c5fb-5c9d1d56ebbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "616b8143-a4fb-4a9b-8638-0513abef2347", "AQAAAAIAAYagAAAAEDJ/66LQ66Qmy3+qT69GE8FJ33GG+OCHk6qqumsYYj+U8tWZRvrXptpzJgnFmbqXtQ==", "148ee0b3-25c1-44fd-8056-3a955c5b9e99" });
        }
    }
}
