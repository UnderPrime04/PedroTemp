using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dt_Disputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Tx_Narracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FotoPersonagem", "UsuarioId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 172, 2, 235, 222, 102, 183, 222, 58, 17, 221, 119, 84, 83, 150, 42, 195, 236, 52, 251, 254, 147, 110, 215, 11, 55, 3, 50, 21, 223, 10, 12, 93, 169, 241, 160, 186, 160, 243, 205, 32, 184, 104, 114, 211, 95, 18, 253, 158, 27, 82, 23, 81, 70, 30, 91, 26, 162, 226, 207, 156, 224, 209, 20, 60 }, new byte[] { 187, 46, 67, 19, 121, 11, 120, 83, 59, 176, 78, 96, 15, 163, 78, 54, 102, 51, 30, 21, 125, 181, 79, 105, 150, 129, 11, 76, 40, 219, 77, 91, 24, 61, 235, 46, 55, 107, 140, 202, 40, 186, 88, 148, 195, 164, 236, 24, 151, 147, 197, 180, 215, 202, 87, 220, 78, 245, 159, 253, 190, 132, 232, 135, 35, 78, 39, 67, 248, 14, 134, 112, 163, 229, 208, 170, 179, 2, 126, 30, 244, 60, 151, 80, 225, 48, 180, 82, 187, 228, 181, 170, 122, 92, 226, 83, 48, 40, 139, 101, 42, 164, 142, 212, 97, 69, 75, 61, 94, 220, 83, 231, 162, 35, 191, 188, 173, 61, 20, 228, 74, 205, 182, 235, 176, 198, 95, 84 } });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuarios_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "TB_Disputas");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { null, null });
        }
    }
}
