using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClasesAbstractas;
using Archivos;
using Excepciones;
namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        List<Alumno> alumnos;
        Universidad.EClases clases;
        Profesor instructor;
        #endregion
        #region Propiedades
        /// <summary>
        /// Obtiene y setea la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Obtiene y setea las clases
        /// </summary>
        public Universidad.EClases Clases
        {
            get { return this.clases; }
            set { this.clases = value; }
        }
        /// <summary>
        /// Obtiene y setea un profesor
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor publico de instancia que crea la lista de Alumnos
        /// </summary>
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="clase">Clases de la jornada</param>
        /// <param name="instructor">Profesor de la jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.clases = clase;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno participa en la clase, caso contrario retorna false</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            if (j.alumnos.Contains(a))
            {
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Una Jornada será distinta a un Alumno si el mismo  no participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno no participa en la clase, caso contrario retorna false</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada validando que no este previamente cargado
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la jornada con el alumno cargado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos de la jornada
        /// </summary>
        /// <returns>Retorna un string con dichos datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.clases, this.instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();

        }
        /// <summary>
        /// Guarda la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>Retorna true si pudo guardar correctamente, si no retorna false</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto txt = new Texto();
            bool retorno = true;

            if (txt.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString()) == false)
            {
                retorno = false;
            }
            return retorno;

        }
        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <returns>retorna un string con los datos del archivo</returns>
        public static string Leer()
        {
            string buffer;
            Texto txt = new Texto();
            txt.Leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", out buffer);
            return buffer;


        }

        #endregion
    }
}
