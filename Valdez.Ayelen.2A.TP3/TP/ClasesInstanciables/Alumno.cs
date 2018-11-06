using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado EEstadoCuenta
        public enum EEstadoCuenta { AlDia, Deudor, Becado };
        #endregion
        #region Atributos
        Universidad.EClases clasesQueToma;
        EEstadoCuenta estadoCuenta;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="id">Id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacinalidad del alumno</param>
        /// <param name="clasesQueToma">Clases que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="id">Id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacinalidad del alumno</param>
        /// <param name="clasesQueToma">Clases que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si el alumno es igual a la clase, caso contrario retorna false</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.estadoCuenta != EEstadoCuenta.Deudor && a.clasesQueToma == clase)
            {
                retorno = true;
            }
            return retorno;

        }
        /// <summary>
        /// Un Alumno será distinto a un EClase si no toma esa clase y su estado de cuenta  es Deudor.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si el alumno es distinto a la clase, sino retorna false</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.clasesQueToma == clase);
        }


        #endregion
        #region Metodos Sobreescritos
        /// <summary>
        /// Devuelve un string con los datos del Alumno
        /// </summary>
        /// <returns>Retorna un string con dichos datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            if (this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine("ESTADO DE CUENTA: cuota al dia");
            }
            else
            {
                sb.AppendFormat("ESTADO DE CUENTA {0}\n", this.estadoCuenta);
            }
            sb.AppendFormat(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns>retorna un string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}\n\n", this.clasesQueToma);
        }
        /// <summary>
        /// Hace publico el metodo MostrarDatos()
        /// </summary>
        /// <returns>Retorna un string con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
