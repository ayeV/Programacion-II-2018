using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace Entidades.sp
{
    public delegate void DelegadoPrecio();
    public class Cajon<T> : ISerializar
    {
        public event DelegadoPrecio  EventoPrecio;

        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;


        public List<T> Elementos
        {
            get { return this._elementos; }
            set { this._elementos = value; }

        }

        public double PrecioTotal
        {
            get
            {

                return this.CalcularPrecioTotal();
               
            }
        }

        public int Capacidad
        {
            get { return this._capacidad; }
            set { this._capacidad = value; }
        }

        public double PrecioUnitario
        {
            get { return this._precioUnitario; }
            set { this._precioUnitario = value; }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
            this.EventoPrecio += new DelegadoPrecio(Imprimir_Cajon);
        }

        private void Imprimir_Cajon()
        {
            try
            {
                using (var sw = new StreamWriter(String.Format("{0}/cajon_{1}.txt", Environment.CurrentDirectory, typeof(T).Name)))
                {
                    sw.Write(string.Format("Precio Total {0} Fecha y hora: {1}", this.PrecioTotal, DateTime.Now.ToString("G")));
                }

            }
            catch (Exception e)
            {
            }


        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precio, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precio;
        }


        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
           
            foreach (T item in cajon._elementos)
            {
                if (item.Equals(elemento))
                {
                    
                    break;
                }

            }

            if (cajon._elementos.Count < cajon._capacidad)
            {
                cajon._elementos.Add(elemento);
            }

            return cajon;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += string.Format("Capacidad {0}- Cantidad de elementos {1}- Precio total {2}\n", this._capacidad, this._elementos.Count, this.PrecioTotal);
            foreach (T item in this._elementos)
            {
                retorno += item.ToString() + "\n";


            }

            return retorno;

        }

        public bool Xml(string archivo)
        {
            bool retorno = true;
            XmlSerializer xSerializer = new XmlSerializer(typeof(Cajon<T>));
            try
            {
                using (XmlTextWriter xml = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + archivo, null))
                {
                    xSerializer.Serialize(xml, this);

                }
            }
            catch (Exception)
            {

                retorno = false;
            }
            return retorno;
        }

        public double CalcularPrecioTotal()
        {
            double retorno = 0;
            retorno =  this._precioUnitario * this._elementos.Count;
             if(retorno > 55)
            {
                EventoPrecio();
            }
            return retorno;
        }

    }
}
