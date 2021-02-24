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
        //Given
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
        //When
            log = ReturnMessage;
            var result = log("Hello!");
        //Then
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
        //Given
        string name = "Liam";
        //When
        var upper = MakeUppercase(name);
        //Then
        Assert.Equal("LIAM", upper);
        Assert.Equal("Liam", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // act
            GetBookSetName(ref book1, "New Book");

            // assert
            Assert.Equal("New Book", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
                
        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // act
            GetBookSetName(book1, "New Book");

            // assert
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            
            // act
            SetName(book1, "New Book");

            // assert
            Assert.Equal("New Book", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            // act


            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }
        [Fact]
        public void TwoVarsCanReferenceTheSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // act


            // assert
            Assert.Same(book1,book2);

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
