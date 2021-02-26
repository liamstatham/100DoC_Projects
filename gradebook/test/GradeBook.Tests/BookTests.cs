using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // Arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6,result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }

        [Fact]
        public void TestName()
        {
        //Given
        var book = new InMemoryBook("Grade book");
       // var actual = book.AddGrade(105.0);        
        //When
        //var expected = "Invalid value";
        //Then
        //Assert.Equal(expected, actual);
        }
    }
}
