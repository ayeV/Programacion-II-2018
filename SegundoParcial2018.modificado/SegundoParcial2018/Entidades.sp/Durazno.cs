using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public string Nombre
        {
            get { return "Durazno"; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
        }

        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            this._cantPelusa = cantPelusa;
        }

        public Durazno(int id, string nombre, double peso, double precio) : base(id, nombre, peso, precio)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}--" + base.FrutaToString() + "Tiene carozo: true--Cant pelusa:{1}--", this.Nombre, this._cantPelusa);
        }
    }
}
