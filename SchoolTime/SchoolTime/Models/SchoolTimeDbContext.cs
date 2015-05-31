﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolTime.Models
{
    public class SchoolTimeDbContext : DbContext
    {
        public SchoolTimeDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
