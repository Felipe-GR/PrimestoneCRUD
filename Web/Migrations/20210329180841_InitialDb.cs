using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
    name: "Curso",
    columns: table => new
    {
        ID = table.Column<int>(type: "int", nullable: false),
        Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
        FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
        FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Curso", x => x.ID);
    });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDireccion = table.Column<int>(type: "int", nullable: false),
                    EstudianteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Direccion_Estudiante_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteCurso",
                columns: table => new
                {
                    EstudianteCursoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteCurso", x => x.EstudianteCursoID);
                    table.ForeignKey(
                        name: "FK_EstudianteCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudianteCurso_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_EstudianteID",
                table: "Direccion",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCurso_CursoId",
                table: "EstudianteCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteCurso_EstudianteId",
                table: "EstudianteCurso",
                column: "EstudianteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
    name: "Direccion");

            migrationBuilder.DropTable(
                name: "EstudianteCurso");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}
