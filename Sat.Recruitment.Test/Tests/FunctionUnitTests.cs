using Moq;
using Sat.Recruitment.Service.Interfaces;
using Sat.Recruitment.Service.Utils;
using Xunit;

namespace Sat.Recruitment.Test.Tests
{
    public class FunctionUnitTests
    {
        private readonly IFunctions _functions;

        public FunctionUnitTests()
        {
            _functions = new Functions();
        }


        [Fact]
        public void ShouldReturnDecimal()
        {
            var result = _functions.CalculateMoney(1, 100);
            Assert.True(result is decimal, "result is decimal");
            Assert.True(result == 180, "result should be 180");
        }
        
        [Fact]
        public void UserType_Normal_more_than_100()
        {
            var result = _functions.CalculateMoney(1, 120);
            Assert.True(result == (decimal)134.40, "result should be 134.40");
        }
        
        [Fact]
        public void UserType_Premium()
        {
            var result = _functions.CalculateMoney(2, 120);
            Assert.True(result == 360, "result should be 360");
        }
        
        [Fact]
        public void UserType_Premium_less_than_100()
        {
            var result = _functions.CalculateMoney(2, 50);
            Assert.True(result == 50, "result should be 50");
        }
        
        [Fact]
        public void UserType_SuperUser_more_than_100()
        {
            var result = _functions.CalculateMoney(3, 120);
            Assert.True(result == 144, "result should be 144");
        }
    }
}