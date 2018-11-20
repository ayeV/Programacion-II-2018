using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.sp
{
 public interface IDeserializar
  {
    bool Xml(string archivo, out Fruta f);
  }
}
