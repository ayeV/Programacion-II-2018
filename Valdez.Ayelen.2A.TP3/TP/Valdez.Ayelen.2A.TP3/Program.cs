using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using ClasesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace Valdez.Ayelen._2A.TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            gim += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
                ClasesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
                Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
                ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
                Alumno.EEstadoCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            ClasesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            gim += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
            ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            gim += a5;
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
            ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            gim += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
            ClasesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.AlDia);
            gim += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
            ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            gim += a8;
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456",
            ClasesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i1;
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
            ClasesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i2;
            try
            {
                gim += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(gim.ToString());
            Console.ReadKey();
            Console.Clear();
            try
            {
                Universidad.Guardar(gim);
                Console.WriteLine("Archivo de Universidad guardado.");
               
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int jornada = 0;
                Jornada.Guardar(gim[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
               //Console.WriteLine(Jornada.Leer());
                //Console.WriteLine(Universidad.Leer().ToString());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();

        }
    }
}
