using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;
namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Enumerado ENacionalidad
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion
        #region Atributos
        string apellido;
        int dni;
        ENacionalidad nacionalidad;
        string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Setea y retorna el apellido de la persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Setea y retorna la nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Setea y retorna el dni de la persona
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Setea y retorna el nombre de la persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Setea el dni de la persona
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDNI(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Sobrecarga de contrusctor publico de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        /// <summary>
        /// Sobrecarga de constructor publico de instancia
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        #endregion

        #region Sobrecarga
        /// <summary>
        /// Retorna los datos de la persona
        /// </summary>
        /// <returns>Nombre y nacionalidad</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("NOMBRE COMPLETO: {0} {1}", this.apellido, this.nombre));
            sb.AppendLine(string.Format("NACIONALIDAD: {0}", this.nacionalidad));
            return sb.ToString();
        }

        #endregion


        #region Metodos
        /// <summary>
        /// Valida que el DNI este dentro de los rangos correspondientes segun la nacionalidad.
        /// Rango dni argentino: 1-89999999. Rango dni extranjero: 90000000-99999999.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>Retorna el dni valido o la exception segun sea el caso</returns>
        static int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI fuera del rango valido");
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if ( dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato< 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;

            }

            return dato;
        }
        /// <summary>
        /// Valida que la cadena pasada como parametro corresponda con el formato de un DNI (solo numeros)
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de la persona pasado como string</param>
        /// <returns>Retorna el dni valido o la exception segun corresponda</returns>
        static int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (Regex.IsMatch(dato, @"^[0-9]+[0-9\.]*$")) //Chequeo si contiene al menos un numero y despues si tiene numeros o puntos
            {
                dato = dato.Replace(".", ""); //Remuevo los puntos
                Int32.TryParse(dato, out dni);
            }
            else
            {
                throw new DniInvalidoException("DNI ingresado tiene un formato inválido.");
            }

            return ValidarDNI(nacionalidad, dni);
        }
        /// <summary>
        /// Valida que el nombre o apellido contenga solo letras
        /// </summary>
        /// <param name="dato">Nombre/Apellido de la persona</param>
        /// <returns>Retorna el dato o cadena vacia segun corresponda</returns>
        static string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$"))//Chequeo que solo contenga letras
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

    }
}
