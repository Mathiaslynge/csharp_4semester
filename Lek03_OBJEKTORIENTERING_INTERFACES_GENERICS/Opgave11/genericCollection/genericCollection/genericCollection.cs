using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genericCollection
{
    class GeneriskCollection<T>
    {
        Dictionary<T, T> Elements;

        public GeneriskCollection()
        {
            Elements = new Dictionary<T, T>();

        }

        public bool AddElement(T k, T e)
        {
            if (Elements.ContainsKey(k))
            {
                return false;
            } else
            {
                Elements.Add(k, e);
                return true;
            }
        }

        public T GetElement(T k)
        {
            return Elements[k]; 
        }

        public int size()
        {
            return Elements.Count;
        }
    }
}
