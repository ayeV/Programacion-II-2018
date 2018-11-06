using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Enumerado EClases
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };
        #endregion

        #region Atributos
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;
        #endregion

        #region Propidades
        /// <summary>
        /// Propiedad que obtiene y setea la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad que obtiene y setea la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Propiedad que obtiene y setea la lista de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// Indexador
        /// </summary>
        /// <param name="i">indice de la jornada</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.jornada.Count)
                    return this.jornada[i];
                else
                    return null;
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.jornada[i] = value;

            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor publico de instancia, inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
            this.alumnos = new List<Alumno>();
        }


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Retorna el primer profesor que da esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna el profesor que da la clase, caso contrario lanza una exception</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Devuelve el primer profesor que no da esa clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna el profesor que no da esa clase, caso contrario lanza una exception</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            if (g.profesores.Contains(i))
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en ella.
        /// </summary>
        /// <param name="g">universidad</param>
        /// <param name="a">alumno</param>
        /// <returns>Retorna true si el alumno esta inscripto, si no retorna false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            if (g.alumnos.Contains(a))
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Un Universidad será distinta a un Alumno si el mismo  no está inscripto en ella.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno no esta inscripto, si no retorna false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Agrega una jornada, asigna un profesor y los alumnos que cursen dicha clase
        ///
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clases</param>
        /// <returns>Retorna una universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    jornada.Alumnos.Add(item);

                }
            }
            g.Jornadas.Add(jornada);

            return g;
        }
        /// <summary>
        /// Agrega un alumno a la universidad comprobando que no este previamente cargado
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la universidad con el alumno agregado, si ya existia lanza una exception</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }
        /// <summary>
        /// Agrega un profesor a la Universidad comprobando que no este ya inscripto
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Retorna la universidad con el profesor añadido, caso contrario devuelve la universidad recibida como parametro</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
                return u;
            }
            return u;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos de la Universidad
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns>Retorna un string con dichos datos</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in gim.Jornadas)
            {
                sb.AppendLine("JORNADA:");
                sb.AppendLine(jornada.ToString() + Environment.NewLine);
                sb.AppendLine("< ------------------------------------------------------------------- >");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Retorna un string con los datos, llama a MostrarDatos(Universidad gim)
        /// </summary>
        /// <returns>Retorna un string con los datos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda la universidad en un archivo xml
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <returns>Retorna true si pudo guardaro, caso contrario retorna false</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            if (xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", uni))
            {
                retorno = true;

            }

            return retorno;
        }
        /// <summary>
        /// lee un archivo de tipo xml
        /// </summary>
        /// <returns>Retorna la universidad con los datos guardados</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out retorno);
            return retorno;
        }


        #endregion
    }
}
