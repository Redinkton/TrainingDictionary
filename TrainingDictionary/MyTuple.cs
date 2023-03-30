using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDictionary
{
    public class MyTuple
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public MyTuple(int key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
