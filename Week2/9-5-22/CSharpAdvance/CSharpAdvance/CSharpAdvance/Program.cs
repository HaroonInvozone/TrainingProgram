 c# program to illustrate the use of delegates
using ExtentionMethods;
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



//extention method
namespace ExtentionMethods
{

    public static class Extensions
    {
        public static int WordCount(this string s)
        {
            return s.Split(new char[] { ' ', '.', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;
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
            //Showarray<int>(a);
            //Showarray<string>(names);
            int z = Extensions.WordCount("This is c# from index");
            Console.WriteLine(z);
        }
    }
}


namespace PracOfAbstractClass
{

    public sealed class SealedClass
    {
        public void SFunc()
        {
            Console.WriteLine("hay i am sealed");
        }
    }
    public abstract class AbstractClass
    {
        public abstract void gfg();
    }

    public class class1 : AbstractClass
    {
        public override void gfg()
        {
            Console.WriteLine("Hy i am class1");
        }
    }

    public class class2 : AbstractClass
    {
        public override void gfg()
        {
            Console.WriteLine("hy i am class2");
        }
        public virtual void VirtualFunc()
        {
            Console.WriteLine("Virtual function base class");
        }
    }

    class xyz : class2
    {
        public override void VirtualFunc()
        {
            Console.WriteLine("Virtual function derived class");
        }
        public static void Main()
        {
            class1 class1 = new class1();
            class2 class2 = new class2();
            xyz xyz = new xyz();
            xyz.VirtualFunc();
            class1.gfg();
            class2.gfg();
            class2.VirtualFunc();
            SealedClass sealedClass = new SealedClass();
            sealedClass.SFunc();
        }
    }
}