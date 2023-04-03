namespace TrainingDictionary.Tests
{
    [TestClass]
    public class MyDictionaryTests
    {
        MyDictionary Map { get; set; }
        Dictionary<int, string> Dictionary { get; set; }
        private static Random random = new Random();

        [TestMethod]
        public void Add_FillBothDictionary_AreEquals()
        {
            // Arrange
            bool expected = true;
            Map = new();
            Dictionary = new();

            // Act
            FillDictionary();

            // Assert
            bool actual = Equals();
            Assert.AreEqual(expected, actual, "Map and Dictionary has different results");
        }

        #region Helpers
        private void FillDictionary ()
        {
            int key = 0;
            string value;
            while (key < 999)
            {
                value = RandomString(3);
                Dictionary.Add(key, value);
                Map.Add(key, value);
                key++;
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool Equals()
        {
            if(Map.Count !=Dictionary.Count) 
                return false;

            if (Map != null && Dictionary != null)
            {
                for (int i = 0; i < Map.Count - 1; i++)
                {
                    if (Dictionary[i] != Map[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}