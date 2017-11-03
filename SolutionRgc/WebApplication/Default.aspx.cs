using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string buscarDatos(string fechaIni, string fechaFin)
        {
            DateTime Ini = Convert.ToDateTime(fechaIni);
            DateTime Fin = Convert.ToDateTime(fechaFin);
            Fin = Fin.AddDays(1);
            var servicio = new ReferenciaServicio.MiServicioClient();
            servicio.ClientCredentials.UserName.UserName = "Victor";
            servicio.ClientCredentials.UserName.Password = "12345";
            String rta = "";
            try
            {
                rta = servicio.GetData(Ini, Fin);
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
            return rta;
        }
    }
}