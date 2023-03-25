using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Cuenta = "walas";
            estudiante.Password = "password";
            estudiante.Nombre = "Pedro";
            estudiante.Matricula = "123wil";

            estudiante.login("wals","password");
            estudiante.login();


            //listas en vez de arrays en .Net C#
            List<Docente> listadocentes = new List<Docente>();
            listadocentes.Add(new Docente()
            {
                Cuenta = "smamani",
                Password = "12354",
                Nombre = "Saul",
                Sueldo = 1234
            });
            listadocentes.Add(new Docente()
            {
                Cuenta = "warroyo",
                Password = "6545",
                Nombre = "Wily",
                Sueldo = 3000
            });
            listadocentes.Add(new Docente()
            {
                Cuenta = "jmiguel",
                Password = "765321",
                Nombre = "Juan",
                Sueldo = 5400
            });
            Mostrarlista(listadocentes);

            Double promedio = getPromedio(listadocentes);
            Console.WriteLine("\n---- promedio: {0}", promedio.ToString("##.##"));

            double promedio2 = getPromediodos(listadocentes);
            Console.WriteLine("\n---- promedio 2: {0}", promedio2.ToString("##.##"));

            double promedio3 = getPromedio3(listadocentes);
            Console.WriteLine("\n---- promedio 3: {0}", promedio3.ToString("##.##"));

            double promedio4 = getPromedio4(listadocentes);
            Console.WriteLine("\n----<- promedio 4: {0}", promedio4.ToString("##.##"));
            Console.ReadKey();
        }

        private static double getPromedio4(List<Docente> listadocentes)
        {
            //consultas LINQ
            var prom = (
                from item in listadocentes
                where item.Sueldo < 200
                select item.Sueldo).Average();
            return (double)prom;
        }

        private static double getPromedio3(List<Docente> listadocentes)
        {
            //funciones lambda
            decimal sum = listadocentes.Sum(x => x.Sueldo);

            int Total = listadocentes.Count;
            return (double)(sum/Total);
        }

        private static double getPromediodos(List<Docente> listadocentes)
        {
            //funciones lamda
            decimal promedio = listadocentes.Average(x=> x.Sueldo);

            return (double)promedio;
        }

        private static double getPromedio(List<Docente> listadocentes)
        {
            Decimal sum = 0;
            foreach(Docente item in listadocentes)
            {
                sum += item.Sueldo;
            }

            return (Double)(sum / listadocentes.Count());//cast
        }

        private static void Mostrarlista(List<Docente> listadocentes)
        {
            Console.WriteLine("------Lista de Docentes-------");
            foreach (Docente item in listadocentes)
            {
                Console.WriteLine(item.ToString());   
            }
        }
    }
}
