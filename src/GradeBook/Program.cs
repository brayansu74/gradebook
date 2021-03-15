using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    { 
        static void Main(string[] args)
        {

            // LLamando al metodo list<double> de la clase Book
            // var book = new InMemoryBook("Libro de calificaciones");
            IBook book = new DiskBook("Libro de calificaciones");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            // Console.WriteLine("La suma es: {0}", stats);
            // Console.WriteLine(InMemoryBook.CATEGORY);
            Console.WriteLine($"Para el libro nombrado {book.Name}");
            Console.WriteLine($"El promedio es: {stats.Average:N2}");
            Console.WriteLine("Nota mas alta: {0}", stats.High);
            Console.WriteLine("Nota mas baja: {0}", stats.Low);
            Console.WriteLine("Su rango es: {0}", stats.Letter);

        }

        private static void EnterGrades(IBook book)
        {
            // Console.WriteLine("Por favor ingrese la cantidad de calificaciones");
            // var input2 = Console.ReadLine();
            // var grade2 = int.Parse(input2);

            while (true)
            {
                Console.WriteLine("Por favor ingrese una calificación o ingrese 'q' para salir");
                var input = Console.ReadLine();

                if (input == "q" || input == "Q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }

            // for (int i = 1; i <= grade2; i++)
            // {
            //     try
            //     {
            //         Console.WriteLine("Por favor ingrese una calificación");
            //         var input = Console.ReadLine();
            //         var grade = double.Parse(input);
            //         book.AddGrade(grade);
            //     }
            //     catch(Exception ex)
            //     {
            //         Console.WriteLine(ex.Message); 
            //     }                       
            // }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Se agrego una calificación");    
        }
    } 
}
