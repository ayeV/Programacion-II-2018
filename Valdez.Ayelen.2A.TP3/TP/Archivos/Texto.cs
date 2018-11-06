using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de texto
        /// </summary>
        /// <param name="archivo">Path donde se guardara el archivo</param>
        /// <param name="datos">Datos que se escribiran en el archivo</param>
        /// <returns>Retorna true si pudo guardarlo, false si no</returns>
        public bool Guardar(string archivo, string datos)
        {

            bool retorno;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine(datos);
                    retorno = true;
                }

            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;

        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <param name="archivo">Path donde se encuentra el archivo</param>
        /// <param name="datos">Datos que contiene el archivo</param>
        /// <returns>Retorna true si pudo leer, false si no</returns>
        public bool Leer(string archivo, out string datos)
        {

            StreamReader sr = null;
            bool retorno = true;
            try
            {
                sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
            }
            catch (Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                sr.Close();
            }
            return retorno;
        }

    }
}
