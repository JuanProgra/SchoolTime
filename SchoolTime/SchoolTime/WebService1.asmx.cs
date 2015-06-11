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
    }
}
