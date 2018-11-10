using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
   public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension que guardara un archivo de texto en el escritorio de la maquina
        /// </summary>
        /// <param name="texto">Informacion a ser escrita</param>
        /// <param name="archivo">Nombre del archivo</param>
        /// <returns>Retorna true si pudo guardar, caso contrario retorna false</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool retorno;
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + archivo, true, Encoding.UTF8))
                {
                    sw.WriteLine(archivo);
                    retorno = true;
                }

            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
