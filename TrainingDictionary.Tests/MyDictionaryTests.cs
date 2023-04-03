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

        [TestMethod]
        public void Remove_FirstElement_True()
        {
            // Arrange
            bool expected = true;
            Map = new();

            // Act
            Map.Add(0, "hell");
            Map.Add(1, "welcome");
            Map.Add(2, "phone");
            Map.Add(3, "book");
            bool actual = Map.Remove(0);

            // Assert
            Assert.AreEqual(expected, actual, "An error occurred while deleting last element");
        }

        [TestMethod]
        public void Remove_AnyElement_False()
        {
            // Arrange
            bool expected = false;
            Map = new();

            // Act
            Map.Add(0, "hell");
            Map.Add(1, "welcome");
            Map.Add(2, "phone");
            Map.Add(3, "book");
            Map.Remove(Map.Count-1);
            bool actual = Map.Remove(999);

            // Assert
            Assert.AreEqual(expected, actual, "An error occurred while deleting a random element");
        }

        [TestMethod]
        public void Remove_LastElement_True()
        {
            // Arrange
            bool expected = true;
            Map = new();

            // Act
            Map.Add(0, "hell");
            Map.Add(1, "welcome");
            Map.Add(2, "phone");
            Map.Add(3, "book");
            bool actual = Map.Remove(Map.Count-1);

            // Assert
            Assert.AreEqual(expected, actual, "An error occurred while deleting last element");
        }

        [TestMethod]
        public void Get_FirsElement_Value()
        {
            // Arrange
            Map = new();
            Dictionary = new();

            // Act
            FillDictionary();

            // Assert
            Assert.AreEqual(Map[0], Dictionary[0], "Map and Dictionary has different results");
        }

        [TestMethod]
        public void Get_23Element_Error()
        {
            // Arrange
            Map = new();

            // Act
            Map.Add(0, "hell");
            Map.Add(1, "welcome");
            Map.Add(2, "phone");
            Map.Add(3, "book");
            var ex = Assert.ThrowsException<KeyNotFoundException>(() => Map.Get(23));

            // Assert
            Assert.AreEqual("The given key 23 was not present in the dictionary.", ex.Message);
        }

        [TestMethod]
        public void GetOrDefault_FillMap_DefaultValue()
        {
            // Arrange
            string expected = "DEFAULT1";
            Map = new();

            // Act
            Map.Add(0, "hell");
            Map.Add(1, "welcome");
            Map.Add(2, "phone");
            Map.Add(3, "book");
            string actual = Map.GetOrDefault(44, "DEFAULT1");

            // Assert
            Assert.AreEqual(expected, actual, "The default value was not returned.");
        }

        [TestMethod]
        public void ContainsKey_FirstElement_True()
        {
            // Arrange
            bool expected = true;
            Map = new();
            Dictionary = new();

            // Act
            FillDictionary();
            bool actual = Map.ContainsKey(0);

            // Assert
            Assert.AreEqual(expected, actual, "This key does not contains.");
        }

        [TestMethod]
        public void ContainsKey_AnyElement_False()
        {
            // Arrange
            bool expected = false;
            Map = new();
            Dictionary = new();

            // Act
            FillDictionary();
            bool actual = Map.ContainsKey(Map.Count);

            // Assert
            Assert.AreEqual(expected, actual, "This key does not contains.");
        }

        #region Helpers
        private void FillDictionary()
        {
            int key = 0;
            string value;
            while (key < 5)
            {
                value = RandomString(3);
                Dictionary.Add(key, value);
                Map.Add(key, value);
                ++key;
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