using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SchoolTime.Models;

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
        private SchoolTimeDbContext db = new SchoolTimeDbContext();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public String Login(string user, string password)
        {
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
        public List<AsigSalon> Get_horario(string codigo,string time)
        {
            DateTime timeD = Convert.ToDateTime(time);

            AsigancionSalon asig = db.AsigancionSalons.FirstOrDefault(asi => asi.Grupo.Codigo == codigo && asi.Dia == timeD);

            List<AsigSalon> asigancion = new List<AsigSalon>();
            AsigSalon obj;
            var culture = new System.Globalization.CultureInfo("es-ES");

            if (asig != null)
            {
                obj = new AsigSalon();
                obj.Codigo = asig.Grupo.Codigo;
                obj.Hora = Convert.ToString(asig.Hora.TimeOfDay);
                obj.Materia = asig.Materia.Nombre;
                obj.Dia = culture.DateTimeFormat.GetDayName(asig.Dia.DayOfWeek);

                asigancion.Add(obj);
            }
            return asigancion;
        }
        [WebMethod]
        public String Get_Grupo(string usuairo)
        {
            String codigo = "";
            AsignacionGrupo asGru = db.AsignacionGrupoes.FirstOrDefault(ast => ast.Usuario.NombreUsuario == usuairo);

            if (asGru != null)
            {
                codigo = asGru.Grupo.Codigo;
            }
            return codigo;
        }
    }
}
