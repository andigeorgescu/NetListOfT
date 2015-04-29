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
using System.Xml.Schema;

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
       

        public T this[int position] 
        {   
            
            get
            {
                if (position < 0 || position >= index) throw new ArgumentOutOfRangeException();
                
                return list[position];
            }
            set
            {
                if (position < 0 || position >= index) throw new ArgumentOutOfRangeException();
                
                list[position] = value;
            } 
        }
            
        public void Add(T item)
        {
            list[index] = item;
            index++;
        }

        public void Clear()
        {

            list=new T[50];
            index = 0;

        }

        public bool Contains(T item)
        {
            foreach(var t in list)
                if (t.Equals(item)) return true;

            return false;
        }

        public void RemoveAt(int position)
        {
            if(position<0 || position> index) throw new ArgumentOutOfRangeException();
            for (int i = position; i < index; i++)
                list[i] = list[i + 1];
            this.index--;
        }

        public MyList<T> FindAll(Func<T, bool> match)
        {
            MyList<T> newList = new MyList<T>();

            foreach (var item in list)
            {
                if (match(item))
                {
                    newList.Add(item);
                }
            }

            return newList;
        }


        public IEnumerator<T> GetEnumerator()
        {
            int counter = 0;
            for (int it = 0 ;it<index;it++)
            {
                if (counter < index)
                {
                    yield return list[it];
                    counter++;
                }
                else break;
                
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
