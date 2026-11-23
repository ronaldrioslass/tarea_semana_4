
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tarea_semana_4.Data;

#nullable disable

namespace tarea_semana_4.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    partial class BibliotecaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("tarea_semana_4.Models.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("IdAutor");

                    b.ToTable("autores", (string)null);

                    b.HasData(
                        new
                        {
                            IdAutor = 1,
                            Apellidos = "García Márquez",
                            FechaNacimiento = new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "Colombiana",
                            Nombres = "Gabriel"
                        },
                        new
                        {
                            IdAutor = 2,
                            Apellidos = "Icaza",
                            FechaNacimiento = new DateTime(1906, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "Ecuatoriana",
                            Nombres = "Jorge"
                        },
                        new
                        {
                            IdAutor = 3,
                            Apellidos = "Allende",
                            FechaNacimiento = new DateTime(1942, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidad = "Chilena",
                            Nombres = "Isabel"
                        });
                });

            modelBuilder.Entity("tarea_semana_4.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Activa")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Pasillo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("IdCategoria");

                    b.ToTable("categorias", (string)null);

                    b.HasData(
                        new
                        {
                            IdCategoria = 1,
                            Activa = true,
                            Descripcion = "Obras narrativas extensas",
                            Nombre = "Novela",
                            Pasillo = "A-1"
                        },
                        new
                        {
                            IdCategoria = 2,
                            Activa = true,
                            Descripcion = "Narraciones breves",
                            Nombre = "Cuento",
                            Pasillo = "A-2"
                        },
                        new
                        {
                            IdCategoria = 3,
                            Activa = true,
                            Descripcion = "Literatura de denuncia social",
                            Nombre = "Realismo social",
                            Pasillo = "B-1"
                        });
                });

            modelBuilder.Entity("tarea_semana_4.Models.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("IdEstudiante");

                    b.HasIndex("Cedula")
                        .IsUnique();

                    b.ToTable("estudiantes", (string)null);

                    b.HasData(
                        new
                        {
                            IdEstudiante = 1,
                            Apellidos = "Pérez Loor",
                            Cedula = "1710034065",
                            Curso = "Sexto A",
                            Nombres = "María José"
                        },
                        new
                        {
                            IdEstudiante = 2,
                            Apellidos = "Mendoza Ruiz",
                            Cedula = "0912345675",
                            Curso = "Sexto B",
                            Nombres = "Carlos Andrés"
                        },
                        new
                        {
                            IdEstudiante = 3,
                            Apellidos = "Zambrano Vera",
                            Cedula = "1307654321",
                            Curso = "Quinto A",
                            Nombres = "Ana Lucía"
                        });
                });

            modelBuilder.Entity("tarea_semana_4.Models.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdAutor")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("IdLibro");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdCategoria");

                    b.ToTable("libros", (string)null);

                    b.HasData(
                        new
                        {
                            IdLibro = 1,
                            IdAutor = 1,
                            IdCategoria = 1,
                            Stock = 4,
                            Titulo = "Cien años de soledad"
                        },
                        new
                        {
                            IdLibro = 2,
                            IdAutor = 1,
                            IdCategoria = 1,
                            Stock = 3,
                            Titulo = "El coronel no tiene quien le escriba"
                        },
                        new
                        {
                            IdLibro = 3,
                            IdAutor = 2,
                            IdCategoria = 3,
                            Stock = 5,
                            Titulo = "Huasipungo"
                        },
                        new
                        {
                            IdLibro = 4,
                            IdAutor = 3,
                            IdCategoria = 1,
                            Stock = 2,
                            Titulo = "La casa de los espíritus"
                        },
                        new
                        {
                            IdLibro = 5,
                            IdAutor = 3,
                            IdCategoria = 2,
                            Stock = 3,
                            Titulo = "Cuentos de Eva Luna"
                        });
                });

            modelBuilder.Entity("tarea_semana_4.Models.Prestamo", b =>
                {
                    b.Property<int>("IdPrestamo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IdLibro")
                        .HasColumnType("int");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("IdEstudiante");

                    b.HasIndex("IdLibro");

                    b.ToTable("prestamos", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrestamo = 1,
                            FechaDevolucion = new DateTime(2026, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaPrestamo = new DateTime(2026, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdEstudiante = 1,
                            IdLibro = 1
                        },
                        new
                        {
                            IdPrestamo = 2,
                            FechaPrestamo = new DateTime(2026, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdEstudiante = 2,
                            IdLibro = 3
                        });
                });

            modelBuilder.Entity("tarea_semana_4.Models.Libro", b =>
                {
                    b.HasOne("tarea_semana_4.Models.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("tarea_semana_4.Models.Categoria", "Categoria")
                        .WithMany("Libros")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("tarea_semana_4.Models.Prestamo", b =>
                {
                    b.HasOne("tarea_semana_4.Models.Estudiante", "Estudiante")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdEstudiante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("tarea_semana_4.Models.Libro", "Libro")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("tarea_semana_4.Models.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("tarea_semana_4.Models.Categoria", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("tarea_semana_4.Models.Estudiante", b =>
                {
                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("tarea_semana_4.Models.Libro", b =>
                {
                    b.Navigation("Prestamos");
                });
#pragma warning restore 612, 618
        }
    }
}
