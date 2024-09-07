using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empresa.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos_PX",
                columns: table => new
                {
                    IdDepartament = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NameDepartament = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos_PX", x => x.IdDepartament);
                });

            migrationBuilder.CreateTable(
                name: "Empregados_PX",
                columns: table => new
                {
                    EmpregadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Genero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdDepartament = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregados_PX", x => x.EmpregadoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos_PX");

            migrationBuilder.DropTable(
                name: "Empregados_PX");
        }
    }
}
