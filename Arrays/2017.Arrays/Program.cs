using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017.Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            Program.MostrarArrays();

        }

        #region Mostrar Array

        private static void MostrarArrays()
        {
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine("***********Arrays en CSharp******************");
            Console.WriteLine("*********************************************");
            Console.ReadLine();

            //DECLARO UN ARRAY DE ENTEROS
            int[] numeros;

            ushort num = 0;
            bool esValido = false;

            Console.Write("¿Cuántos números va a introducir? ");

            esValido = UInt16.TryParse(Console.ReadLine(), out num);

            while (esValido == false)
            {
                Console.WriteLine("Error, Reingrese un número positivo!!!");
                esValido = UInt16.TryParse(Console.ReadLine(), out num);
            }

            //INSTANCIO EL ARRAY DE ENTEROS
            numeros = new Int32[num];

            //CARGO EL ARRAY CON VALORES, UTILIZANDO UN FOR
            for (int i = 0; i < num; i++)
            {
                Console.Write("Ingrese el número para el elemento {0}: ", i);
                numeros[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("Pulse una tecla para ver el contenido del Array...");
            Console.WriteLine("Utilizando una estructura For Each...");
            Console.ReadLine();

            //MUESTRO EL CONTENIDO DEL ARRAY, UTILIZO UN FOREACH
            int index = 0;
            foreach (int i in numeros)
            {
                Console.WriteLine("Elemento {0}: {1}", index, i);
                index++;
            }

            Console.ReadLine();
            Console.Clear();

            int cantidad;

            //DECLARO E INSTANCIO OTRO ARRAY DE ENTEROS
            int[] n = new int[num];

            //COPIO EL CONTENIDO DEL PRIMER ARRAY EN EL SEGUNDO
            numeros.CopyTo(n, 0);

            Console.WriteLine("Copio el contenido del Array en un nuevo Array llamado 'n'.");
            Console.ReadLine();

            //MUESTRO EL CONTENIDO DEL SEGUNDO ARRAY, UTILIZO UN FOR
            //OBTENGO LA CANTIDAD DE ELEMENTOS UTILIZANDO GETLENGTH
            for (int i = 0; i < n.GetLength(0); i++)
            {
                Console.WriteLine("Elemento {0}: {1}", i, n[i]);
            }
            Console.ReadLine();

            //OBTENGO EL LIMITE INFERIOR DEL ARRAY
            cantidad = n.GetLowerBound(0);

            Console.WriteLine("n.GetLowerBound(0) = {0}", cantidad);
            Console.ReadLine();

            //OBTENGO EL LIMITE SUPERIOR DEL ARRAY
            cantidad = n.GetUpperBound(0);

            Console.WriteLine("n.GetUpperBound(0) = {0}", cantidad);
            Console.ReadLine();

            //OBTENGO EL VALOR DE UN ELEMENTO UTILIZANDO GETVALUE
            Console.WriteLine("n.GetValue(num-1) = {0}", n.GetValue(num - 1));
            Console.ReadLine();

            //ESTABLEZCO EL VALOR DE UN ELEMENTO UTILIZANDO SETVALUE 
            n.SetValue(99, num - 1);

            Console.WriteLine("n.SetValue(99, num - 1), --> {0}", n.GetValue(num - 1));
            Console.ReadLine();
            Console.Clear();

            UInt16 filas;
            UInt16 columnas;

            do
            {
                Console.WriteLine("Ingrese cantidad de filas para el Array.");

            } while (!UInt16.TryParse(Console.ReadLine(), out filas));


            do
            {
                Console.WriteLine("Ingrese cantidad de columnas para el Array.");

            } while (!UInt16.TryParse(Console.ReadLine(), out columnas));

            //DECLARO E INSTANCIO UN ARRAY MULTIDIMENCIONAL
            //DE DOS FILAS Y DOS COLUMNAS
            int[,] matriz = new int[filas, columnas];

            Console.Clear();
            Console.WriteLine("Creo un Array multidimensional.");
            Console.WriteLine("Muestro la cantidad de dimensiones del Array.");
            Console.ReadLine();

            Console.WriteLine("El Array posee {0} dimensiones.", matriz.Rank);
            Console.ReadLine();

            Console.WriteLine("Muestro la cantidad total de elementos del Array.");

            Console.WriteLine("El Array posee {0} elementos sumando todas sus dimensiones."
                                , matriz.Length);
            Console.ReadLine();

        }
        #endregion
    }
}
