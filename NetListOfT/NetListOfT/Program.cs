using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NetListOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> evenNumbers = new MyList<int>();
            Func<int, bool> match = x => x % 3 == 0;
            MyList<int> result = new MyList<int>();

            evenNumbers.Add(2);
            evenNumbers.Add(4);
            evenNumbers.Add(6);

            foreach(var num in evenNumbers)
                Console.WriteLine(num);

            Console.WriteLine(evenNumbers.Count);
            
            //Exception
            //Console.Write(evenNumbers[4]);

           // evenNumbers.Clear();
           //Console.WriteLine(evenNumbers.Count);

            Console.WriteLine(evenNumbers.Contains(7));

            evenNumbers.RemoveAt(1);

            foreach (var num in evenNumbers)
                Console.WriteLine(num);

            result=evenNumbers.FindAll(match);
            Console.WriteLine("Match");

            foreach (var num in result)
            {
                Console.WriteLine(num);
            }
        }
    }
}
