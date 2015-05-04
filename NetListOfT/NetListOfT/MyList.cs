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
        private T[] list;
        private int index;
       

        public MyList()
        {
            index = 0;
            list = new T[index];
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
            T[] cpylist = new T[index];
            cpylist = list;
            
            
            list=new T[index+1];

            for (int it = 0; it < index; it++)
            {
                list[it] = cpylist[it];
            }

            list[index] = item;
            index++;
        }

        public void Clear()
        {

            index = 0;
            list = new T[index];

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
            
            T[] cpylist = new T[index];
            cpylist = list;
            list = new T[index - 1];

            for (int it = 0; it < index-1; it++)
            {
                
                list[it] = cpylist[it];

            }
            for (int it = position; it < index-1; it++)
            {

                list[it] = cpylist[it + 1];

            }
            index--;

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
