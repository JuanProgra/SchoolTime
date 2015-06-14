using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SchoolTime.Models;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace SchoolTime
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public String Login(string user, string password)
        {
            SchoolTimeDbContext db = new SchoolTimeDbContext();
            Usuario u = db.Usuarios.FirstOrDefault(c => c.NombreUsuario == user);
            String nombre = "";
            if (u != null)
            {
                if (u.Password == password)
                {
                    nombre = u.Nombre + " " + u.Apellido;
                }
                else
                {
                    nombre = "0";
                }

            }
            else
            {
                nombre = "0";
            }
            return nombre;
        }
        [WebMethod]
        public String Get_Grupo(string usuairo)
        {
            SchoolTimeDbContext db = new SchoolTimeDbContext();
            String codigo = "";
            AsignacionGrupo asGru = db.AsignacionGrupoes.FirstOrDefault(ast => ast.Usuario.NombreUsuario == usuairo);

            if (asGru != null)
            {
                codigo = asGru.Grupo.Codigo;
            }
            return codigo;
        }
        [WebMethod]
        public List<AsigSalon> Get_horario(string codigo)
        {
            SchoolTimeDbContext db = new SchoolTimeDbContext();

            IQueryable<AsigancionSalon> asig = db.AsigancionSalons
                .Where(asi => asi.Grupo.Codigo == codigo);

            var culture = new System.Globalization.CultureInfo("es-ES");

            var list = new List<AsigSalon>();
            AsigSalon obj;
            foreach (var item in asig.ToList())
            {
                obj = new AsigSalon();
                obj.Salon = item.Salon.Nombre;
                obj.Hora = Convert.ToString(item.Hora.TimeOfDay);
                obj.Materia = item.Materia.Nombre;
                obj.Dia = culture.DateTimeFormat.GetDayName(item.Dia.DayOfWeek);

                list.Add(obj);
            }
            return list;
        }
        [WebMethod]
        public List<AsigSalon> Get_materia(string codigo)
        {
            SchoolTimeDbContext db = new SchoolTimeDbContext();

            IQueryable<AsigancionSalon> asig = db.AsigancionSalons
                .Where(asi => asi.Grupo.Codigo == codigo);

            var culture = new System.Globalization.CultureInfo("es-ES");

            var list = new List<AsigSalon>();
            AsigSalon obj;
            foreach (var item in asig.ToList())
            {
                obj = new AsigSalon();
                obj.Materia = item.Materia.Nombre;

                list.Add(obj);
            }
            return list;
        }
        
        [WebMethod]
        public List<AsigTarea> Get_tareas(string materia)
        {
            SchoolTimeDbContext db = new SchoolTimeDbContext();

            IQueryable<AsigancionTarea> asigancionTarea = db.AsigancionTareas
                .Where(c => c.Materia.Nombre == materia);

            var list = new List<AsigTarea>();
            AsigTarea obj;
            foreach (var item in asigancionTarea.ToList())
            {
                obj = new AsigTarea();
                obj.NombreTare = item.Materia.Nombre;
                obj.Nombre = item.Tarea.Nombre;
                obj.Detalle = item.Tarea.Detalle;
                obj.Fecha = item.Tarea.FechaEntrega;
                obj.Punteo = item.Tarea.Punteo;

                list.Add(obj);
            }
            return list;
        }

    }
}
