using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.sp
{
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string Nombre
        {
            get { return "Manzana"; }
        }


        public override bool TieneCarozo
        {
            get { return true; }
        }

        public string Provincia
        {
            get { return this._provinciaOrigen; }
            set { this._provinciaOrigen = value; }
        }

        public Manzana()
        {

        }

        public Manzana(string color, double peso, string provincia) : base(color, peso)
        {
            this._provinciaOrigen = provincia;
        }

        public Manzana(int id, string nombre, double peso, double precio) : base(id, nombre, peso, precio)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}--" + base.FrutaToString() + "--Tiene carozo: true, Provincia {1}--", this.Nombre, this._provinciaOrigen);
        }

        public bool Xml(string archivo)
        {
            bool retorno = true;
            XmlSerializer xSerializer = new XmlSerializer(typeof(Manzana));

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






        bool IDeserializar.Xml(string archivo, out Fruta f)
        {
            bool retorno = true;
            XmlSerializer xSerializer = new XmlSerializer(typeof(Manzana));

            try
            {
                using (XmlTextReader xml = new XmlTextReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + archivo))
                {
                    f = (Manzana)xSerializer.Deserialize(xml);

                }

            }
            catch (Exception e)
            {

                f = default(Manzana);
                retorno = false;
            }

            return retorno;
        }


    }
}
