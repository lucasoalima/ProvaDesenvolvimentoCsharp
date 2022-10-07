using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FOlhas.Migrations
{
    public partial class FolhasLucas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FolhaPagamento",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Folha",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdHoras",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValorHora",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_Folha",
                table: "Folhas",
                column: "Folha");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_Folha",
                table: "Folhas",
                column: "Folha",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_Folha",
                table: "Folhas");

            migrationBuilder.DropIndex(
                name: "IX_Folhas_Folha",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "FolhaPagamento",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Folha",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "QtdHoras",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ValorHora",
                table: "Folhas");
        }
    }
}
