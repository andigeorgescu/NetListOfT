using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetListOfT
{
    class MyList<T> :IEnumerable<T>
    {
        private T[] list =null;
        private int index=0;

        public MyList()
        {
            list = new T[50];
        }
       

        public int Count
        {
            get
            {
                return index;
            }
        }

        public T this[int index] 
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            } 
        }
            
        public void Add(T item)
        {
            list[index] = item;
            index++;
        }

       

        public IEnumerator<T> GetEnumerator()
        {
            int counter=0;
            foreach (var item in list)
            {
                if (counter < index)
                {
                    yield return item;
                    counter++;
                }
        }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
