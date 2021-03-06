using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            //log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;
            Assert.Equal(3,count);

            var result = log("Hello");
            //Assert.Equal("Hello", result);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }  

        string ReturnMessage(string message)
        {
            count++;
            return message.ToLower();
        }  

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            String name = "brayan";
            var upper = MakeUppercase(name);

            Assert.Equal("brayan", name);
            Assert.Equal("BRAYAN", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }   

        [Fact]
        public void test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }
        private void SetInt(ref int z)
        {
            z = 42;
        }

         private int GetInt()
        {
            return 3;
        }

        [Fact]
         public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
         public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
         public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1,book2);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
