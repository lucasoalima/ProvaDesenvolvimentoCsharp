using Microsoft.EntityFrameworkCore.Migrations;

namespace API_FOlhas.Migrations
{
    public partial class ModelsAlterada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_Folha",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "FolhaPagamento",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "Folha",
                table: "Folhas",
                newName: "FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "ValorHora",
                table: "Folhas",
                newName: "ValorHrs");

            migrationBuilder.RenameColumn(
                name: "QtdHoras",
                table: "Folhas",
                newName: "QtdHrs");

            migrationBuilder.RenameIndex(
                name: "IX_Folhas_Folha",
                table: "Folhas",
                newName: "IX_Folhas_FuncionarioId");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoFgts",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoInss",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ImpostoRenda",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SalarioLiquido",
                table: "Folhas",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoFgts",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoInss",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "ImpostoRenda",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "SalarioLiquido",
                table: "Folhas");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "Folhas",
                newName: "Folha");

            migrationBuilder.RenameColumn(
                name: "ValorHrs",
                table: "Folhas",
                newName: "ValorHora");

            migrationBuilder.RenameColumn(
                name: "QtdHrs",
                table: "Folhas",
                newName: "QtdHoras");

            migrationBuilder.RenameIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folhas",
                newName: "IX_Folhas_Folha");

            migrationBuilder.AddColumn<int>(
                name: "FolhaPagamento",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_Folha",
                table: "Folhas",
                column: "Folha",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
