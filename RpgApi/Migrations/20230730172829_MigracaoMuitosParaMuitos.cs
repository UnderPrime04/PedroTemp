using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 202, 218, 134, 21, 45, 38, 108, 13, 245, 240, 118, 2, 62, 45, 25, 43, 147, 199, 137, 184, 82, 224, 105, 103, 17, 112, 240, 157, 133, 93, 227, 182, 151, 232, 195, 232, 212, 226, 173, 63, 118, 174, 174, 233, 159, 33, 102, 40, 57, 56, 190, 138, 77, 196, 111, 0, 218, 35, 199, 138, 124, 218, 100 }, new byte[] { 175, 57, 240, 242, 101, 127, 125, 65, 120, 62, 191, 53, 227, 255, 147, 188, 25, 161, 32, 105, 8, 87, 14, 112, 128, 216, 27, 205, 170, 20, 226, 29, 247, 154, 88, 254, 121, 38, 21, 139, 89, 2, 18, 110, 118, 201, 218, 97, 46, 110, 198, 173, 215, 64, 70, 222, 15, 97, 95, 178, 50, 0, 129, 212, 131, 106, 100, 99, 37, 31, 114, 63, 184, 205, 242, 143, 117, 34, 142, 184, 253, 62, 65, 4, 159, 208, 200, 159, 0, 84, 16, 109, 124, 128, 76, 92, 0, 240, 51, 19, 186, 98, 203, 192, 236, 252, 51, 181, 156, 232, 149, 42, 161, 97, 152, 2, 36, 193, 150, 44, 114, 159, 56, 75, 183, 183, 13, 130 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 94, 137, 39, 18, 169, 49, 72, 145, 68, 129, 45, 223, 242, 55, 241, 168, 137, 84, 157, 242, 214, 175, 35, 9, 29, 214, 77, 126, 10, 202, 93, 108, 178, 243, 210, 36, 111, 16, 170, 134, 229, 113, 53, 199, 145, 60, 224, 192, 208, 147, 228, 216, 49, 47, 246, 225, 91, 123, 98, 168, 104, 15, 223 }, new byte[] { 123, 245, 229, 129, 55, 16, 0, 212, 89, 156, 145, 5, 96, 91, 206, 14, 125, 50, 173, 171, 193, 90, 55, 147, 100, 75, 164, 148, 47, 135, 186, 250, 111, 166, 120, 218, 223, 54, 238, 247, 202, 134, 196, 167, 133, 203, 190, 160, 134, 111, 160, 93, 30, 217, 82, 105, 102, 111, 137, 53, 60, 3, 211, 206, 116, 188, 32, 101, 129, 160, 94, 43, 27, 188, 96, 40, 69, 202, 69, 57, 67, 106, 198, 18, 135, 239, 73, 193, 173, 200, 159, 143, 216, 209, 110, 36, 98, 49, 172, 139, 0, 193, 154, 210, 7, 234, 219, 69, 176, 55, 61, 145, 210, 69, 204, 244, 25, 172, 57, 115, 16, 216, 61, 64, 227, 41, 16, 113 } });
        }
    }
}
