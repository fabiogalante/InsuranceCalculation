using Application.Insurances;
using Application.Interfaces;
using Xunit;

namespace DomainTests
{
    public class InsuranceTest
    {

        private readonly IInsuranceData _data = new InsuranceData();


        [Theory]
        [InlineData(10000, 270.38)]
        [InlineData(20000, 540.75)]
        [InlineData(30000, 811.12)]
        [InlineData(40000, 1081.50)]

        public void Test3(decimal valueOfTheVehicle, decimal expectedInsurancePrice)
        {
            _data.ValueOfTheVehicle = valueOfTheVehicle;
            var insurancePrice = _data.CalculateInsurancePrice();
            Assert.Equal(expectedInsurancePrice, insurancePrice);
        }


    }
}