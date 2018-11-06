using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el archivo en formato xml
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>true si se pudo guardar, false si no.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = true;
            XmlSerializer xSerializer = new XmlSerializer(typeof(T));
            try
            {
                using (XmlTextWriter xml = new XmlTextWriter(archivo, null))
                {
                    xSerializer.Serialize(xml, datos);

                }
            }
            catch (Exception)
            {

                retorno = false;
            }
            return retorno;
        }
        /// <summary>
        /// Lee un archivo con formato xml
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Datos a leer</param>
        /// <returns>true si se pudo leer correctamente, false si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = true;
            XmlSerializer xSerializer = new XmlSerializer(typeof(T));

            try
            {
                using (XmlTextReader xml = new XmlTextReader(archivo))
                {
                    datos = (T)xSerializer.Deserialize(xml);

                }

            }
            catch (Exception)
            {

                datos = default(T);
                retorno = false;
            }

            return retorno;

        }


    }
}
