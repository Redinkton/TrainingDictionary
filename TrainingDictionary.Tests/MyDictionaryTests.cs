namespace TrainingDictionary.Tests
{
    [TestClass]
    public class MyDictionaryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyDictionary dictionary = new MyDictionary(new List<MyTuple>()
            {
                new (1, "2"),
                new (2, "3")
            });
        }
    }
}