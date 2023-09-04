using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 94, 137, 39, 18, 169, 49, 72, 145, 68, 129, 45, 223, 242, 55, 241, 168, 137, 84, 157, 242, 214, 175, 35, 9, 29, 214, 77, 126, 10, 202, 93, 108, 178, 243, 210, 36, 111, 16, 170, 134, 229, 113, 53, 199, 145, 60, 224, 192, 208, 147, 228, 216, 49, 47, 246, 225, 91, 123, 98, 168, 104, 15, 223 }, new byte[] { 123, 245, 229, 129, 55, 16, 0, 212, 89, 156, 145, 5, 96, 91, 206, 14, 125, 50, 173, 171, 193, 90, 55, 147, 100, 75, 164, 148, 47, 135, 186, 250, 111, 166, 120, 218, 223, 54, 238, 247, 202, 134, 196, 167, 133, 203, 190, 160, 134, 111, 160, 93, 30, 217, 82, 105, 102, 111, 137, 53, 60, 3, 211, 206, 116, 188, 32, 101, 129, 160, 94, 43, 27, 188, 96, 40, 69, 202, 69, 57, 67, 106, 198, 18, 135, 239, 73, 193, 173, 200, 159, 143, 216, 209, 110, 36, 98, 49, 172, 139, 0, 193, 154, 210, 7, 234, 219, 69, 176, 55, 61, 145, 210, 69, 204, 244, 25, 172, 57, 115, 16, 216, 61, 64, 227, 41, 16, 113 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 172, 2, 235, 222, 102, 183, 222, 58, 17, 221, 119, 84, 83, 150, 42, 195, 236, 52, 251, 254, 147, 110, 215, 11, 55, 3, 50, 21, 223, 10, 12, 93, 169, 241, 160, 186, 160, 243, 205, 32, 184, 104, 114, 211, 95, 18, 253, 158, 27, 82, 23, 81, 70, 30, 91, 26, 162, 226, 207, 156, 224, 209, 20, 60 }, new byte[] { 187, 46, 67, 19, 121, 11, 120, 83, 59, 176, 78, 96, 15, 163, 78, 54, 102, 51, 30, 21, 125, 181, 79, 105, 150, 129, 11, 76, 40, 219, 77, 91, 24, 61, 235, 46, 55, 107, 140, 202, 40, 186, 88, 148, 195, 164, 236, 24, 151, 147, 197, 180, 215, 202, 87, 220, 78, 245, 159, 253, 190, 132, 232, 135, 35, 78, 39, 67, 248, 14, 134, 112, 163, 229, 208, 170, 179, 2, 126, 30, 244, 60, 151, 80, 225, 48, 180, 82, 187, 228, 181, 170, 122, 92, 226, 83, 48, 40, 139, 101, 42, 164, 142, 212, 97, 69, 75, 61, 94, 220, 83, 231, 162, 35, 191, 188, 173, 61, 20, 228, 74, 205, 182, 235, 176, 198, 95, 84 } });
        }
    }
}
