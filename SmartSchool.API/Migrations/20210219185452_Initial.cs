using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, new DateTime(2021, 2, 19, 15, 54, 52, 307, DateTimeKind.Local).AddTicks(9100), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5378), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5545), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5554), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5566), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5580), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataNascimento", "DataTermino", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(5586), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Informação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataTermino", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, new DateTime(2021, 2, 19, 15, 54, 52, 301, DateTimeKind.Local).AddTicks(9707), null, "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataTermino", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, new DateTime(2021, 2, 19, 15, 54, 52, 303, DateTimeKind.Local).AddTicks(976), null, "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataTermino", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, new DateTime(2021, 2, 19, 15, 54, 52, 303, DateTimeKind.Local).AddTicks(1087), null, "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataTermino", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, new DateTime(2021, 2, 19, 15, 54, 52, 303, DateTimeKind.Local).AddTicks(1092), null, "Rodrigo", 4, "Sampaio", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataInicio", "DataTermino", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, new DateTime(2021, 2, 19, 15, 54, 52, 303, DateTimeKind.Local).AddTicks(1093), null, "Alexandre", 5, "Noruega", null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 2, 1, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9038), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 4, 5, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9053), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 2, 5, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9043), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 1, 5, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9036), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 7, 4, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9069), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 6, 4, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9062), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 5, 4, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9054), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 4, 4, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9051), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 1, 4, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(8995), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 7, 3, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9067), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 5, 5, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9055), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 6, 3, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9059), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 7, 2, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9066), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 6, 2, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9058), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 3, 2, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9046), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 2, 2, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9039), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 1, 2, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(7906), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 7, 1, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9064), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 6, 1, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9057), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 4, 1, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9050), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 3, 1, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9045), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 3, 3, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9047), null, null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataInicio", "DataTermino", "Nota" },
                values: new object[] { 7, 5, new DateTime(2021, 2, 19, 15, 54, 52, 308, DateTimeKind.Local).AddTicks(9070), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
