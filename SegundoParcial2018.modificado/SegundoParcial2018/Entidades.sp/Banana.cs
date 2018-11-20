using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public string Nombre
        {
            get { return "Banana"; }
        }

        public override bool TieneCarozo
        {
            get { return false; }
        }

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }

        public Banana(int id, string nombre, double peso, double precio) : base(id, nombre, peso, precio)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}--" + base.FrutaToString() + "--Tiene carozo: false--Pais {1}--", this.Nombre, this._paisOrigen);
        }



    }
}
