using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RepasoSql
{
    class Program
    {
        static void Main(string[] args)
        {
            //Listado Completo
            //Console.Write(Program.ObtenerListado());

            //Listado ordenado por nombre, solo muestra nombres
            //Console.Write(Program.Mostrar1());

          //  Console.WriteLine(Program.Mostrar2());

            Product p1 = new Product(78, "Durazno", 15, 1, "52 cajas", (decimal)14.00, 30, 78, 8, false);
           if( p1.AgregarProducto(p1))
            {
                Console.Write("Producto agregado con exito");
            }

            Console.ReadLine();

        }

        private static string ObtenerListado()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM dbo.Products";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;

            conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();
            var sb = new StringBuilder();
            sb.AppendLine("ProductID   ProductName    SupplierID    Quantity    UnitPrice    Stock    UnitsInOrder   ReorderLevel  Discontinued\n");
            while (lector.Read())
            {
                sb.AppendLine(string.Format("{0} || {1} || {2} || {3} || {4} || {5} || {6} || {7}\n", lector[0], lector[1], lector[2], lector[3], lector[4], lector[5], lector[6], lector[7]));
            }
            conexion.Close();

            return sb.ToString();




        }

        private static string Mostrar1()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ProductName FROM dbo.Products order by ProductName";
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conexion;

            conexion.Open();

            SqlDataReader lector = command.ExecuteReader();
            var sb = new StringBuilder();
            sb.AppendLine("ProductName\n");
            while (lector.Read())
            {
                sb.AppendLine(string.Format("{0}", lector[0]));
            }


           
                conexion.Close();


               
           

            return sb.ToString();

        }

        private static string Mostrar2()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT pro.ProductName, cat.CategoryName FROM Products pro INNER JOIN Categories cat ON (pro.CategoryID = cat.CategoryID)";
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conexion;

            conexion.Open();

            SqlDataReader lector = command.ExecuteReader();
            var sb = new StringBuilder();
         
            while (lector.Read())
            {
                sb.AppendLine(string.Format("Product Name: {0}\nCategoryName: {1}\n", lector[0],lector[1]));
            }



            conexion.Close();





            return sb.ToString();
        }
        
    }
}
