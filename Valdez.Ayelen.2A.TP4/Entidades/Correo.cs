using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Entidades
{
    public class Correo :IMostrar<List<Paquete>>
    {
        #region Atributos

        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        #endregion
        #region Propiedad
        /// <summary>
        /// Propiedad que setea y obtiene la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor publico de instancia
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();

        }
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Controla si el paquete ya está en la lista. En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        /// De no estar repetido, agrega el paquete a la lista de paquetes
        /// </summary>
        /// <param name="c">Correo </param>
        /// <param name="p">Paquete</param>
        /// <returns>Retorna un correo con el paquete añadido</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if(item == p)
                {
                    throw  new TrackingIdRepetidoException("El paquete ya esta en la lista");
                }

            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            hilo.Start();
            c.mockPaquetes.Add(hilo);

            return c;


        }
        #endregion

        #region Metodos
        /// <summary>
        /// Cerrara todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item.IsAlive)
                {
                    item.Abort();
                }
            }
        }
        /// <summary>
        /// Muestra los datos 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>Retorna un string con dichos datos</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> list = ((Correo)elementos).paquetes;
            string retorno = "";

            foreach (Paquete p in list )
            {
                retorno = string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno;
             
        }

        #endregion
    }
}
