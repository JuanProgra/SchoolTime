namespace SchoolTime.Migrations
{
    using SchoolTime.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolTime.Models.SchoolTimeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SchoolTime.Models.SchoolTimeDbContext context)
        {
            context.Rols.AddOrUpdate(r => r.Id,
                new Rol { Nombre = "Admin" },
                new Rol { Nombre = "Profesor" },
                new Rol { Nombre = "Alumno" });

            context.Usuarios.AddOrUpdate(u => u.Id,
                new Usuario { Nombre = "admin", Apellido = "admin", NombreUsuario = "admin", Password = "123", Correo = "admin@schooltime.com" });

            context.Categorias.AddOrUpdate(c => c.Id,
                new Categoria { Nombre = "Diversificado" },
                new Categoria { Nombre = "Basicos" });

            context.Cursos.AddOrUpdate(cu => cu.Id,
                new Curso { Nombre = "Informatica" },
                new Curso { Nombre = "Dibujo" });

            context.Grados.AddOrUpdate(gr => gr.Id,
                new Grado { Nombre = "Cuarto" },
                new Grado { Nombre = "Quinto" },
                new Grado { Nombre = "Sexto" });

            context.Jornadas.AddOrUpdate(j => j.Id,
                new Jornada { Nombre = "Matutina" },
                new Jornada { Nombre = "Vespertina" });

            context.Materia.AddOrUpdate(m => m.Id,
                new Materia { Nombre = "Lenguaje" },
                new Materia { Nombre = "Matematicas" },
                new Materia { Nombre = "Fisica Fundamental" },
                new Materia { Nombre = "Estadistica" });
        }
    }
}
