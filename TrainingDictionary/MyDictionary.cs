namespace TrainingDictionary
{
    public class MyDictionary
    {
        private List<int> keys = new List<int>();
        private List<List<KeyValuePair>> list = new();

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
                int compressedKey = i % _defaultValue;
                foreach (var element in list[compressedKey])
                {
                    if (i == element.Key)
                    {
                        element.Value = value;
                        return;
                    }
                }
                AddElement(i, value);                
            }
        }
        #endregion

        #region Count
        private int _count;
        public int Count => _count;
        #endregion

        public MyDictionary()
        {
            list.Capacity = _defaultValue;
            
            for(int i = 0; i < _defaultValue; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }

        public void Add(int key, string value)
        {
            if (EqualsKey(key))
            {
                throw new ArgumentException($"An item with the same key has already been added. Key:{key}");
            }
            else
            {
                AddElement(key, value);
            }
        }

        public bool Remove(int key)
        {
            KeyValuePair foundElement = FindElement(key);
            list[key%_defaultValue].Remove(foundElement);
            _count--;
            return foundElement!= null ? true : false;
        }

        public string Get(int key)
        {
            KeyValuePair foundElement = FindElement(key);
            return foundElement != null 
                ? foundElement.Value 
                : throw new KeyNotFoundException($"The given key {key} was not present in the dictionary.");
        }

        string GetOrDefault(int key, string defaultValue)
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
                        return true;
                }
            }
            return false;
        }

        #region Helpers
        public bool EqualsKey(int key) 
        {
            return keys.IndexOf(key) != -1 ? true : false;
        }

        private KeyValuePair FindElement(int key)
        {
            int compressedKey = key % _defaultValue;
            foreach (var element in list[compressedKey])
            {
                if (key != element.Key)
                    continue;

                return element;
            }
            return null;
        }

        private void AddElement(int key, string value)
        {
            int compressedKey = key % _defaultValue;
            list[compressedKey].Add(new(key, value));
            keys.Add(key);
            _count++;
        }
        #endregion
    }
}