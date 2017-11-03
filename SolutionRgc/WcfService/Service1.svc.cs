using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : MiServicio
    {
        //XmlTextReader reader = new XmlTextReader("App_Data/books.xml");
        //XmlReader reader = XmlReader.Create(new StringReader("App_Data/books.xml"));


        

        public string GetData(DateTime fechaIni, DateTime fechaFin)
        {

            XDocument doc = XDocument.Load(Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "books.xml"));

            var query = from y in doc.Descendants("usuario")
                        where Convert.ToDateTime(y.Element("fecha")?.Value) >= fechaIni && Convert.ToDateTime(y.Element("fecha")?.Value) <= fechaFin
                        select new Usuario {
                            fecha = y.Element("fecha").Value,
                            cedula = y.Element("cedula").Value,
                            nombre = y.Element("nombre").Value,
                            apellido1 = y.Element("apellido1").Value,
                            apellido2 = y.Element("apellido2").Value,
                            escliente = (y.Element("escliente").Value == "1")? "SI":"NO",
                        };

                     string json = JsonConvert.SerializeObject(query);

            return json;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    public class Usuario
    {
        public string fecha;
        public string cedula;
        public string nombre;
        public string apellido1;
        public string apellido2;
        public string escliente;
    }
}
