using AspNetCore.Courses.Section15;
using Xunit;
using Xunit.Abstractions;


namespace AspNetCore.Courses.Section15.XUnits.OthersXUnits
{

    public class UnitTest1
    {
        private readonly ITestOutputHelper _outputHelper;

        public UnitTest1(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        [Fact]
        public void GetCalculator_NullArguments()
        {
            int a = 2;
            int b = 3;
            int expected = 5;

            var unixDefault = new XunitDefault(a, b);
            var response = unixDefault.GetCalculator();


            _outputHelper.WriteLine("the expected is" + "" + expected.ToString());
            _outputHelper.WriteLine("the response is" + "" + response.ToString());

            Assert.Equal(expected, response);

        }
    }
}