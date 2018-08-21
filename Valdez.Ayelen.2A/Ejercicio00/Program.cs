using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio00
{
    class Program
    {
        static void Main(string[] args)
        {

            string name;
            int age;
            

            Console.WriteLine("Ingrese nombre: ");
            name = Console.ReadLine();
            Console.WriteLine("Ingrese edad: ");
            age = int.Parse(Console.ReadLine());




            // Console.WriteLine(nombre);
            Console.WriteLine("Su nombre es: {0}", name);
            Console.WriteLine("Edad es: {0}", age);




            Console.ReadLine();
        }
    }
}
