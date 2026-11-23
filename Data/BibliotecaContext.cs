using Microsoft.EntityFrameworkCore;
using tarea_semana_4.Models;

namespace tarea_semana_4.Data;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; } = default!;
    public DbSet<Categoria> Categorias { get; set; } = default!;
    public DbSet<Libro> Libros { get; set; } = default!;
    public DbSet<Estudiante> Estudiantes { get; set; } = default!;
    public DbSet<Prestamo> Prestamos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>().ToTable("autores");
        modelBuilder.Entity<Categoria>().ToTable("categorias");
        modelBuilder.Entity<Libro>().ToTable("libros");
        modelBuilder.Entity<Estudiante>().ToTable("estudiantes");
        modelBuilder.Entity<Prestamo>().ToTable("prestamos");

        modelBuilder.Entity<Estudiante>().HasIndex(e => e.Cedula).IsUnique();

        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Autor)
            .WithMany(a => a.Libros)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Categoria)
            .WithMany(c => c.Libros)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Prestamo>()
            .HasOne(p => p.Libro)
            .WithMany(l => l.Prestamos)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Prestamo>()
            .HasOne(p => p.Estudiante)
            .WithMany(e => e.Prestamos)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Autor>().HasData(
            new Autor { IdAutor = 1, Nombres = "Gabriel", Apellidos = "García Márquez", Nacionalidad = "Colombiana", FechaNacimiento = new DateTime(1927, 3, 6) },
            new Autor { IdAutor = 2, Nombres = "Jorge", Apellidos = "Icaza", Nacionalidad = "Ecuatoriana", FechaNacimiento = new DateTime(1906, 7, 10) },
            new Autor { IdAutor = 3, Nombres = "Isabel", Apellidos = "Allende", Nacionalidad = "Chilena", FechaNacimiento = new DateTime(1942, 8, 2) });

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { IdCategoria = 1, Nombre = "Novela", Descripcion = "Obras narrativas extensas", Pasillo = "A-1", Activa = true },
            new Categoria { IdCategoria = 2, Nombre = "Cuento", Descripcion = "Narraciones breves", Pasillo = "A-2", Activa = true },
            new Categoria { IdCategoria = 3, Nombre = "Realismo social", Descripcion = "Literatura de denuncia social", Pasillo = "B-1", Activa = true });

        modelBuilder.Entity<Libro>().HasData(
            new Libro { IdLibro = 1, Titulo = "Cien años de soledad", Stock = 4, IdAutor = 1, IdCategoria = 1 },
            new Libro { IdLibro = 2, Titulo = "El coronel no tiene quien le escriba", Stock = 3, IdAutor = 1, IdCategoria = 1 },
            new Libro { IdLibro = 3, Titulo = "Huasipungo", Stock = 5, IdAutor = 2, IdCategoria = 3 },
            new Libro { IdLibro = 4, Titulo = "La casa de los espíritus", Stock = 2, IdAutor = 3, IdCategoria = 1 },
            new Libro { IdLibro = 5, Titulo = "Cuentos de Eva Luna", Stock = 3, IdAutor = 3, IdCategoria = 2 });

        modelBuilder.Entity<Estudiante>().HasData(
            new Estudiante { IdEstudiante = 1, Cedula = "1710034065", Nombres = "María José", Apellidos = "Pérez Loor", Curso = "Sexto A" },
            new Estudiante { IdEstudiante = 2, Cedula = "0912345675", Nombres = "Carlos Andrés", Apellidos = "Mendoza Ruiz", Curso = "Sexto B" },
            new Estudiante { IdEstudiante = 3, Cedula = "1307654321", Nombres = "Ana Lucía", Apellidos = "Zambrano Vera", Curso = "Quinto A" });

        modelBuilder.Entity<Prestamo>().HasData(
            new Prestamo { IdPrestamo = 1, FechaPrestamo = new DateTime(2026, 11, 10), FechaDevolucion = new DateTime(2026, 11, 17), IdLibro = 1, IdEstudiante = 1 },
            new Prestamo { IdPrestamo = 2, FechaPrestamo = new DateTime(2026, 11, 18), FechaDevolucion = null, IdLibro = 3, IdEstudiante = 2 });
    }
}
