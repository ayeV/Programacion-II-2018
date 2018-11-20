using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Entidades.sp
{
    public abstract class Fruta 
    {
        protected string _color;
        protected double _peso;
        protected int _id;
        protected string _nombre;
        protected double _precio;


        public abstract bool TieneCarozo { get; }

        //propiedades para XML
        public string Color
        {
            get { return this._color; }
            set { this._color = value; }
        }
        public double Peso
        {
            get { return this._peso; }
            set { this._peso = value; }
        }

        public Fruta()
        {

        }


        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }

        public Fruta(int id,string nombre, double peso,double precio)
        {
            this._id = id;
            this._nombre = nombre;
            this._peso = peso;
            this._precio = precio;
        }


        protected virtual string FrutaToString()
        {
            return string.Format("Color {0}- Peso {1} ", this._color, this._peso);
        }

      


    }
}
