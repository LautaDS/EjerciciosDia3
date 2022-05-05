using System;
using System.IO;
using System.Collections.Generic;

namespace EjerciciosDia3
{
    class Program
    {
        static void Main(string[] args)
        {

            int paraSumar = 0;
            int paraSumar2 = 0;
            int resultado = 0;
           

            Sumar nuevaSuma = new Sumar();

            Program program = new Program();


            int ej;
            do
            {
                Console.WriteLine("Por favor elija que ejercicio quiere ver:");
                Console.WriteLine("(1) Ejercicio 1");
                Console.WriteLine("(2) Demostracion Clases/Objetos");
                Console.WriteLine("(3) ");
                Console.WriteLine("(4) ");
                Console.WriteLine("(0) Salir");

                try
                {
                    ej = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("No hay un ejercicio cargado con ese input, recuerde ponerlo con numeros.");
                    ej = 99999;
                }
                switch (ej)
                {
                    case (1):
                        program.Ejercicio1();
                        break;



                    case (2):
                        paraSumar = program.TryAndCatchInt();
                        paraSumar2 = program.TryAndCatchInt();
                        resultado = nuevaSuma.Operar(paraSumar, paraSumar2);
                        Console.WriteLine("El resultado de la suma entre:" +paraSumar + " y " + paraSumar2 + " es " +resultado);
                        Console.ReadLine();
                        break;

                    case (0):
                        break;
                    case (99999):
                        break;

                    default:
                        break;
                }

            } while (ej != 0);

            Console.WriteLine("Gracias por revisar mis ejercicios");
            Console.ReadLine();
        }
        #region Ejercicios
        public void Ejercicio1()
        {
            Alumno[] notasAlumnos = new Alumno[30];
            int idAlumnoBusqueda = 0;
            Alumno AlumnoBuscado = new Alumno();
            bool flagBusquedaAlumno = true;

            for (int i = 0; i < notasAlumnos.Length; i++)
            {
                notasAlumnos[i] = CargarAlumnos();

                
            }

            

            BubbleSortData(notasAlumnos);
            for (int i = 0; i < notasAlumnos.Length; i++)
            {
                Console.WriteLine("Alumno ID: " + notasAlumnos[i].alumnoID);
            }


            do
            {
                Console.WriteLine("Por favor ingrese el ID del alumno que quiere buscar (1-12000)");
                try
                {
                    idAlumnoBusqueda = int.Parse(Console.ReadLine());
                    flagBusquedaAlumno = true;
                }
                catch
                {
                    idAlumnoBusqueda = 0;
                    flagBusquedaAlumno = false;

                }
            } while (!flagBusquedaAlumno);

            AlumnoBuscado = DicotomicSearchAlumno(notasAlumnos, idAlumnoBusqueda);

            PrintDatosAlumno(AlumnoBuscado);

            Console.ReadLine();
        }

        public void Ejercicio2()
        {
            int[] arreglo1 = new int[10];
            int[] arreglo2 = new int[13];
        }

        #endregion


        #region Metodos

        public Alumno CargarAlumnos()
        {
            Random rand = new Random();
            Alumno alumno = new Alumno();

           
            alumno.alumnoID = rand.Next(1, 12000);

            alumno.nota1 = rand.Next(1, 10);

            alumno.nota2 = rand.Next(1, 10);

            alumno.nota3 = rand.Next(1, 10);

            alumno.nota4 = rand.Next(1, 10);

            return alumno;
        }

        public void BubbleSortData(Alumno[] arrayNotas)
        {
            Alumno temp;
            for (int j = 0; j <= arrayNotas.Length - 2; j++)
            {
                for (int i = 0; i <= arrayNotas.Length - 2; i++)
                {
                    if (arrayNotas[i].alumnoID > arrayNotas[i + 1].alumnoID)
                    {
                        temp = arrayNotas[i + 1];
                        arrayNotas[i + 1] = arrayNotas[i];
                        arrayNotas[i] = temp;
                    }
                }
            }
        }

        public Alumno DicotomicSearchAlumno(Alumno[] arrayNotas, int IDSearch)
        {

            int min = 0;
            int max = arrayNotas.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (IDSearch == arrayNotas[mid].alumnoID)
                {
                    return arrayNotas[mid];
                }
                else if (IDSearch < arrayNotas[mid].alumnoID)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return null;
        }

        public void PrintDatosAlumno(Alumno alumno)
        {
            if (alumno != null)
            { 
            Console.WriteLine(alumno.alumnoID);
            Console.WriteLine(alumno.nota1);
            Console.WriteLine(alumno.nota2);
            Console.WriteLine(alumno.nota3);
            Console.WriteLine(alumno.nota4);
            } else
            {
                Console.WriteLine("No hay un alumno con ese id");
            }

        }

        public int TryAndCatchInt()
        {
            bool flagError = false;
            int paraSumarVar = 0;
            do
            {
                Console.Write("Por favor ingrese un numero para sumar:");
                try
                {
                    paraSumarVar = int.Parse(Console.ReadLine());
                    flagError = true;
                }
                catch
                {
                    Console.WriteLine("Hubo un error, intente de vuelta");
                    flagError = false;
                }
            }
            while (flagError == false);

            return paraSumarVar;

        }


        #endregion

      

    }
    #region Classes
  
    class Alumno
    {
        public int alumnoID;
        public int nota1;
        public int nota2;
        public int nota3;
        public int nota4;

    }

    interface ICuentas
    {
        int Operar(int valor1, int valor2);
    }

    class Sumar : ICuentas
    {
        protected int valor1
        {   
            set;
            get;
        }
        
        protected int valor2 { set; get; }
        protected int resultado { set; get; }

        public int Operar(int valor1, int valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;

            int resultado = valor1 + valor2;

            return resultado;
        }

    }

    class Resta : ICuentas

    {
        protected int valor1 { set; get; }
        protected int valor2 { set; get; }
        protected int resultado { set; get; }
        public int Operar(int valor1, int valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;

            int resultado = valor1 - valor2;

            return resultado;
        }

    }

    #endregion

}