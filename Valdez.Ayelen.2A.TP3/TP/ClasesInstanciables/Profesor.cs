using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor estatico que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();

        }
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Constructor publico de instancia asigna dos clases al azar
        /// </summary>
        /// <param name="id">Id del profesor</param>
        /// <param name="nombre">Nombre del profesor</param>
        /// <param name="apellido">Apellido del profesor</param>
        /// <param name="dni">Dni del profesor</param>
        /// <param name="nacionalidad">Nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sera igual si el profesor da la clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sera distinto si el profesor no da la clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Asigna dos clases al azar
        /// </summary>
        void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }
        /// <summary>
        /// Muestra los datos
        /// </summary>
        /// <returns>Retorna un string con dichos datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Muestra los datos
        /// </summary>
        /// <returns>Retorna un string con dichos datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Muestra las clases que da el profesor
        /// </summary>
        /// <returns>Retorna un string con las clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clases = new StringBuilder();
            clases.AppendLine("CLASES DEL DÍA:");

            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                clases.AppendFormat("{0}\n", c);
            }

            return clases.ToString();
        }
        #endregion
    }
}
