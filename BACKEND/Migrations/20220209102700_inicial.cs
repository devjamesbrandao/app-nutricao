using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACKEND.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INGREDIENTE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGREDIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CodBarra = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESTRICAO_ALIMENTAR",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTRICAO_ALIMENTAR", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_INGREDIENTE",
                columns: table => new
                {
                    FK_PRODUTO_ID = table.Column<int>(type: "int", nullable: true),
                    FK_INGREDIENTE_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PRODUTO_INGREDIENTE_1",
                        column: x => x.FK_PRODUTO_ID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PRODUTO_INGREDIENTE_2",
                        column: x => x.FK_INGREDIENTE_ID,
                        principalTable: "INGREDIENTE",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RESTRICAO_INGREDIENTE",
                columns: table => new
                {
                    FK_INGREDIENTE_ID = table.Column<int>(type: "int", nullable: false),
                    FK_RESTRICAO_ALIMENTAR_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RESTRICAO_INGREDIENTE_1",
                        column: x => x.FK_INGREDIENTE_ID,
                        principalTable: "INGREDIENTE",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_RESTRICAO_INGREDIENTE_2",
                        column: x => x.FK_RESTRICAO_ALIMENTAR_ID,
                        principalTable: "RESTRICAO_ALIMENTAR",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_RESTRICAO",
                columns: table => new
                {
                    FK_RESTRICAO_ALIMENTAR_ID = table.Column<int>(type: "int", nullable: false),
                    FK_USUARIO_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_USUARIO_RESTRICAO_1",
                        column: x => x.FK_RESTRICAO_ALIMENTAR_ID,
                        principalTable: "RESTRICAO_ALIMENTAR",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_USUARIO_RESTRICAO_2",
                        column: x => x.FK_USUARIO_ID,
                        principalTable: "USUARIO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_INGREDIENTE_FK_INGREDIENTE_ID",
                table: "PRODUTO_INGREDIENTE",
                column: "FK_INGREDIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_INGREDIENTE_FK_PRODUTO_ID",
                table: "PRODUTO_INGREDIENTE",
                column: "FK_PRODUTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESTRICAO_INGREDIENTE_FK_INGREDIENTE_ID",
                table: "RESTRICAO_INGREDIENTE",
                column: "FK_INGREDIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESTRICAO_INGREDIENTE_FK_RESTRICAO_ALIMENTAR_ID",
                table: "RESTRICAO_INGREDIENTE",
                column: "FK_RESTRICAO_ALIMENTAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_RESTRICAO_FK_RESTRICAO_ALIMENTAR_ID",
                table: "USUARIO_RESTRICAO",
                column: "FK_RESTRICAO_ALIMENTAR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_RESTRICAO_FK_USUARIO_ID",
                table: "USUARIO_RESTRICAO",
                column: "FK_USUARIO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO_INGREDIENTE");

            migrationBuilder.DropTable(
                name: "RESTRICAO_INGREDIENTE");

            migrationBuilder.DropTable(
                name: "USUARIO_RESTRICAO");

            migrationBuilder.DropTable(
                name: "PRODUTO");

            migrationBuilder.DropTable(
                name: "INGREDIENTE");

            migrationBuilder.DropTable(
                name: "RESTRICAO_ALIMENTAR");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
