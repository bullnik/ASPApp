using ASPApp.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            AIModelAPI api = new();
            var jopa = api.GetDirections("jiba");
            Assert.Pass();
        }
    }
}