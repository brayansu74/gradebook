using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        // [Fact]
        // public void Test1()
        // {
        
        // var note = new Book("libro prueba");
        // var x = note.AddGrade(80.1);

        // Assert.Equal(true, x);
        // }

        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // primera seccion = arreglos
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);    

            // segunda seccion = acto
            var result = book.GetStatistics(); 

            // tercera seccion = assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}

