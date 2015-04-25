using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
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
                if (index < 0 || index > Count) throw new ArgumentOutOfRangeException();
                return list[index];
            }
            set
            {
                if (index < 0 || index > Count) throw new ArgumentOutOfRangeException();
                list[index] = value;
            } 
        }
            
        public void Add(T item)
        {
            list[index] = item;
            index++;
        }

        public void Clear()
        {
            list = default(T[]);
            index = 0;
        }

        public bool Contains(T item)
        {
            foreach(var t in list)
                if (t.Equals(item)) return true;
            return false;
        }

        public void RemoveAt(int index)
        {
            if(index<0 || index>Count) throw new ArgumentOutOfRangeException();
            for (int i = index; i < Count; i++)
                list[i] = list[i + 1];

            list[Count - 1] = default(T);
            this.index--;
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
