using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
   public abstract class Universitario :Persona
    {
        #region Atributo
        int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor publico de instancia
        /// </summary>
        public Universitario() :base()
        {

        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="legajo">Legajo del universitario</param>
        /// <param name="nombre">Nombre del universitario</param>
        /// <param name="apellido">Apellido del universitario</param>
        /// <param name="dni">Dni del universitario</param>
        /// <param name="nacionalidad">Nacionalidad del universitario</param>
        public Universitario(int legajo,string nombre,string apellido,string dni, ENacionalidad nacionalidad) :base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True si son iguales, false si no</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (!ReferenceEquals(obj, null) && obj is Universitario)
            {
                Universitario objeto = (Universitario)obj;
                if (objeto.legajo == this.legajo && objeto.DNI == this.DNI)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Llama al equals para comparar los universitarios
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns>True si son iguales, false si no</returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
          return pg1.Equals(pg2);
        }
        /// <summary>
        /// Llama al equals para comparar los universitarios
        /// </summary>
        /// <param name="pg1">Universitario</param>
        /// <param name="pg2">Universitario</param>
        /// <returns>True si son distintos, false si no</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Metodos
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Muestra los datos del universitario
        /// </summary>
        /// <returns>Retorna un string con dichos datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("\nLEGAJO NUMERO: {0}\n", this.legajo);

            return sb.ToString();
        }

      
        #endregion

    }
}
