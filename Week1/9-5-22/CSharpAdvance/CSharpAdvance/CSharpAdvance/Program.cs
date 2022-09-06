 c# program to illustrate the use of delegates
using System;
using System.Collections.Generic;
namespace geeksforgeeks
{
    //Delegates

    class testDelegate
    {
        public delegate void testdel(double x, double y);

        public void area(double height, double width)
        {
            Console.WriteLine("Area is: {0}", (width * height));
        }

        // "perimeter" method
        public void perimeter(double height, double width)
        {
            Console.WriteLine("Perimeter is: {0} ", 2 * (width + height));
        }

        public static void Main(String[] args)
        {
            testDelegate tt = new testDelegate();
            testdel td = new testdel(tt.perimeter);
            testdel td1 = new testdel(tt.area);
            td(1.2, 2.4);
            td1(1.2, 2.4);
        }
    }

    //Events

    public class Program
    {
        public static void Main()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
            bl.StartProcess();
        }

        // event handler
        public static void bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }
    }

    public class ProcessBusinessLogic
    {
        public event EventHandler ProcessCompleted; // event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted(EventArgs.Empty);
        }


        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }


    // Lamda expression

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() {36, 71, 12,
                        15, 29, 18, 27, 17, 9, 34};

            Console.Write("The list : ");
            foreach (var value in numbers)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            var square = numbers.Select(x => x * x);
            Console.Write("Squares : ");
            foreach (var value in square)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();
            List<int> divBy3 = numbers.FindAll(x => (x % 3) == 0);

            Console.Write("Numbers Divisible by 3 : ");
            foreach (var value in divBy3)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();
        }
    }

    //LINQ

    public class Program
    {
        public static void Main()
        {
            // string collection
            IList<string> stringList = new List<string>() {
            "C# Tutorials",
            "VB.NET Tutorials",
            "Learn C++",
            "MVC Tutorials" ,
            "Java",
            "Python",
            "Danjo Tutorials"
        };

            // LINQ Query Syntax
            var result = from s in stringList
                         where s.Contains("Tutorials")
                         select s;

            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
        }
    }
}



namespace testofgenerics
{
    class gen
    {
        public static void Showarray<T>(T[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        public static void Main()
        {
            int[] a = { 1, 2, 3 };
            string[] names = { "Ali", "Junaid", "hamza" };
            Showarray<int>(a);
            Showarray<string>(names);
        }
    }
}


