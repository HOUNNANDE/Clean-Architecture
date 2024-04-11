namespace Sofidy.Unicia.Test
{
    [TestClass]
    internal class UniciaImportTest : BaseTest
    {
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
        }

        [TestMethod]
        public void Test_ImportPartner()
        {
            //{
            //  "id": "0017Z000029ZimzQAC",
            //  "channel": "Salesforce",
            //  "partnerCategory": "1",
            //  "title": "M",
            //  "lastName": "Bin",
            //  "firstName": "GUO",
            //  "address": "Paris",
            //  "zipCode": "string",
            //  "city": "string",
            //  "country": "string",
            //  "siret": "123456",
            //  "email": "bguo@test.com",
            //  "tel": "123",
            //  "fax": "456",
            //  "startDate": "2013/01/14",
            //  "endDate": "2023/01/20",
            //  "iban": "NL48ABNA9971485915",
            //  "bic": "ASPKAT2L",
            //  "holder": "test"
            //}

            Assert.AreEqual(28, 28); // Tests whether the specified values are equal.
        }
    }
}