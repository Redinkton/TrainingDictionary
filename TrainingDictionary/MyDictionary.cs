using System;

namespace TrainingDictionary
{
    public class MyDictionary
    {
        MyTuple tuple;
        List<MyTuple> tupleList;

        #region Indexer
        private int this[MyTuple i]
        {
            get { return  }
            set { }
        }
        #endregion

        #region Count
        private int _count;
        public int Count => _count;
        #endregion

        public MyDictionary(List<MyTuple> list)
        {
            tupleList= list;
            _count = tupleList.Count;
        }

        public MyDictionary()
        {

        }

        public void Add(int key, string value)
        {

        }

        public bool Remove(int key)
        {

        }

        string Get(int key)
        {

        }

        string GetOrDefault(int key, string defaultValue)
        {

        }

        public bool ContainsKey(int key)
        {

        }
    }
}