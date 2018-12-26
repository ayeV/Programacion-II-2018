using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RepasoSql
{
    public class Product
    {
        public int productID;
        public string productName;
        public int supplierID;
        public int categoryID;
        public string quantityPerUnit;
        public decimal unitPrice;
        public int stock;
        public int unitsInOrder;
        public int reorderLevel;
        public bool discontinued;


        public Product(int prodID, string prodName, int suppID, int catID, string quantity, decimal price, int stock, int unitsOrder, int reorder, bool discontinued)
        {
            this.productID = prodID;
            this.productName = prodName;
            this.supplierID = suppID;
            this.categoryID = catID;
            this.quantityPerUnit = quantity;
            this.unitPrice = price;
            this.stock = stock;
            this.unitsInOrder = unitsOrder;
            this.discontinued = discontinued;
        }


        public bool AgregarProducto(Product p)
        {
            bool retorno = false;
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand command = new SqlCommand();
            
            command.CommandText = string.Format("INSERT INTO Products values ({0}, '{1}', {2}, {3}, '{4}', {5}, {6}, {7}, {8}, {9})", p.productID, p.productName, p.supplierID, p.categoryID, p.quantityPerUnit, p.unitPrice, p.stock, p.unitsInOrder, p.reorderLevel, p.discontinued);
            command.CommandText = "SET IDENTITY_INSERT Products  ON";
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                //throw e;
                retorno = false;
            }

            return retorno;
        }

    }
}
