using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand _comando;
        static SqlConnection _conexion;

        static PaqueteDAO()
        {
            _conexion = new SqlConnection(@"Data Source=HOMEDESKTOP\SQLEXPRESS; Initial Catalog = correo-sp-2017;Integrated Security = True");
        }

      public  static bool Insertar(Paquete p)
        {
            bool retorno = false;
            try
            {
                _comando = new SqlCommand("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Ayelen Valdez 2A')", _conexion);
                _conexion.Open();
                _comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_conexion != null)
                {
                    _conexion.Close();
                }
                if (_comando != null)
                {
                    _comando.Dispose();
                }
            }

            return retorno;


        }

    }
}
