using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioConcrete.Migrations
{
    public partial class inicializacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<string>(nullable: true),
                    ddd = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CreateLogins",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    contatoid = table.Column<int>(nullable: true),
                    data_criacao = table.Column<DateTime>(nullable: false),
                    data_atualizacao = table.Column<DateTime>(nullable: false),
                    ultimo_login = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateLogins", x => x.id);
                    table.ForeignKey(
                        name: "FK_CreateLogins_Telefone_contatoid",
                        column: x => x.contatoid,
                        principalTable: "Telefone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreateLogins_contatoid",
                table: "CreateLogins",
                column: "contatoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateLogins");

            migrationBuilder.DropTable(
                name: "Telefone");
        }
    }
}
