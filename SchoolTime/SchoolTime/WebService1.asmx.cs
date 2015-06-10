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
        public int Login(string user,string password)
        {
            int ok = 0;
            Usuario usuario = db.Usuarios.Find(user);
            AsignacionRol asignacionRol = db.AsignacionRols.Find();
            var students = from s in db.Usuarios select s;
            if(usuario != null)
            {
                if (usuario.Password == password)
                {
                    ok = 1;
                }
                else
                {
                    ok = 0;
                }
            }
            else
            {
                ok = 0;
            }
            return ok;
        }
    }
}
