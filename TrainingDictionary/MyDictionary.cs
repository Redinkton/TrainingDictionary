namespace TrainingDictionary
{
    public class MyDictionary
    {
        private List<int> keys { get; set; }
        private List<List<KeyValuePair>> list { get; set; }

        private readonly int _defaultValue = 128;

        #region Indexer
        public string this[int i]
        {
            get
            {
                return Get(i);
            }
            set 
            {
                Add(i, value);;    
            }
        }
        #endregion

        #region Count
        private int _count;
        public int Count => _count;
        #endregion

        public MyDictionary()
        {
            list = new();
            keys = new(_defaultValue);
            
            for(int i = 0; i < _defaultValue; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }

        public void Add(int key, string value)
        {
            int compressedKey = key % _defaultValue;
            foreach (var element in list[compressedKey])
            {
                if (key == element.Key)
                {
                    element.Value = value;
                    return;
                }
            }
            list[compressedKey].Add(new(key, value));
            keys.Add(key);
            _count++;
        }

        public bool Remove(int key)
        {
            KeyValuePair foundElement = FindElement(key);
            if (foundElement != null)
            {
                list[key % _defaultValue].Remove(foundElement);
                _count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Get(int key)
        {
            KeyValuePair foundElement = FindElement(key);
            return foundElement != null 
                ? foundElement.Value 
                : throw new KeyNotFoundException($"The given key {key} was not present in the dictionary.");
        }

        public string GetOrDefault(int key, string defaultValue)
        {
            KeyValuePair foundElement = FindElement(key);
            return foundElement != null
                ? foundElement.Value
                : defaultValue;
        }

        public bool ContainsKey(int key)
        {
            return FindElement(key) != null ? true : false;
        }

        public bool ContainsValue(string value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                foreach(var element in list[i])
                {
                    if (value == element.Value)
                    {
                        return true;
                    }  
                }
            }
            return false;
        }

        #region Helpers
        private KeyValuePair FindElement(int key)
        {
            int compressedKey = key % _defaultValue;
            foreach (var element in list[compressedKey])
            {
                if (key == element.Key)
                {
                    return element;
                }
            }
            return null;
        }
        #endregion
    }
}