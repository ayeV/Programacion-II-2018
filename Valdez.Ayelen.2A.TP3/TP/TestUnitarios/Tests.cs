using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using ClasesInstanciables;
using Archivos;
using Excepciones;
namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Testea que se lance la exception DniInvalidoException cuando se ingresa un dni con formato invalido
        /// </summary>
        [TestMethod]
        public void TestDniInvalidoException()
        {
            //Dni con letras
            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "s233805a", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Dni con comas
            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "12,445,888", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Sin dni

            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Dni fuera del rango segun nacionalidad
            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }


            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "100000000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (DniInvalidoException e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }


        }
        /// <summary>
        /// Testea que se lance la exception NacionalidadInvalidaException cuando se ingresa un dni con rango incorrecto
        /// </summary>
        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            //Argentino con dni en rango correcto
            try
            {
                Random rn = new Random();
                int dni = rn.Next(1, 90000000);
                Alumno a = new Alumno(1, "Juan", "Perez", dni.ToString(), Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            }
            catch (NacionalidadInvalidaException e)
            {

                Assert.Fail();
            }

            //Argentino con dni fuera del rango correcto

            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "90000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (NacionalidadInvalidaException e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //Extranjero con dni dentro del rango

            try
            {
                Random rn = new Random();
                int dni = rn.Next(90000000, 99999999);
                Alumno a = new Alumno(1, "Juan", "Perez", dni.ToString(), Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            }
            catch (NacionalidadInvalidaException e)
            {

                Assert.Fail();
            }

            //Extranjero con dni fuera de rango
            try
            {
                Alumno a = new Alumno(1, "Juan", "Perez", "89999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
                Assert.Fail();
            }
            catch (NacionalidadInvalidaException e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }
        /// <summary>
        /// Testea que se lance la exception SinProfesorException cuando no hay profesor
        /// </summary>
        [TestMethod]
        public void TestSinProfesorException()
        {

            Universidad u = new Universidad();


            try
            {
                u += Universidad.EClases.Programacion;

            }
            catch (SinProfesorException e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        /// <summary>
        /// Testea que alumnos de jornada no sea null
        /// </summary>
        [TestMethod]
        public void TestJornadaAlumnosNoEsNull()
        {
            Jornada j = new Jornada();

            Assert.IsNotNull(j.Alumnos);
        }
        /// <summary>
        /// Testea que los dni se carguen correctamente
        /// </summary>
        [TestMethod]
        public void TestDNI()
        {
            Alumno a = new Alumno(1, "Juan", "Perez", "12.448.655", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsTrue(12448655 == a.DNI);

            Alumno b = new Alumno(2, "Juana", "Peres", "13556221", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Assert.IsTrue(13556221 == b.DNI);

            Profesor p = new Profesor(1, "Juanito", "Perezt", "90.459.321", Persona.ENacionalidad.Extranjero);
            Assert.IsTrue(90459321 == p.DNI);
        }
    }
}
