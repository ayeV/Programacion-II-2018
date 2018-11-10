using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #region Atributos
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region Constructor
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;
            
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.direccionEntrega, this.trackingID);
        }

        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }
        #endregion

    }
}
