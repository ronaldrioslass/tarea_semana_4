using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814

namespace tarea_semana_4.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Nacionalidad = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.IdAutor);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Pasillo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Activa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.IdCategoria);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Curso = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiantes", x => x.IdEstudiante);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_libros_autores_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_libros_categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaPrestamo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdLibro = table.Column<int>(type: "int", nullable: false),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_prestamos_estudiantes_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_prestamos_libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "autores",
                columns: new[] { "IdAutor", "Apellidos", "FechaNacimiento", "Nacionalidad", "Nombres" },
                values: new object[,]
                {
                    { 1, "García Márquez", new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombiana", "Gabriel" },
                    { 2, "Icaza", new DateTime(1906, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ecuatoriana", "Jorge" },
                    { 3, "Allende", new DateTime(1942, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chilena", "Isabel" }
                });

            migrationBuilder.InsertData(
                table: "categorias",
                columns: new[] { "IdCategoria", "Activa", "Descripcion", "Nombre", "Pasillo" },
                values: new object[,]
                {
                    { 1, true, "Obras narrativas extensas", "Novela", "A-1" },
                    { 2, true, "Narraciones breves", "Cuento", "A-2" },
                    { 3, true, "Literatura de denuncia social", "Realismo social", "B-1" }
                });

            migrationBuilder.InsertData(
                table: "estudiantes",
                columns: new[] { "IdEstudiante", "Apellidos", "Cedula", "Curso", "Nombres" },
                values: new object[,]
                {
                    { 1, "Pérez Loor", "1710034065", "Sexto A", "María José" },
                    { 2, "Mendoza Ruiz", "0912345675", "Sexto B", "Carlos Andrés" },
                    { 3, "Zambrano Vera", "1307654321", "Quinto A", "Ana Lucía" }
                });

            migrationBuilder.InsertData(
                table: "libros",
                columns: new[] { "IdLibro", "IdAutor", "IdCategoria", "Stock", "Titulo" },
                values: new object[,]
                {
                    { 1, 1, 1, 4, "Cien años de soledad" },
                    { 2, 1, 1, 3, "El coronel no tiene quien le escriba" },
                    { 3, 2, 3, 5, "Huasipungo" },
                    { 4, 3, 1, 2, "La casa de los espíritus" },
                    { 5, 3, 2, 3, "Cuentos de Eva Luna" }
                });

            migrationBuilder.InsertData(
                table: "prestamos",
                columns: new[] { "IdPrestamo", "FechaDevolucion", "FechaPrestamo", "IdEstudiante", "IdLibro" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, null, new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_estudiantes_Cedula",
                table: "estudiantes",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_libros_IdAutor",
                table: "libros",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_libros_IdCategoria",
                table: "libros",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_IdEstudiante",
                table: "prestamos",
                column: "IdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_IdLibro",
                table: "prestamos",
                column: "IdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "estudiantes");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
