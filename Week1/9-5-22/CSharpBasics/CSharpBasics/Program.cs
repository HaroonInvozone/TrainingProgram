using System;
using System.Text.RegularExpressions;

namespace RectangularApplication
{
    class Rectangular
    {
        double length;
        double width;

        public void AcceptDetails()
        {
            length = 3.4;
            width = 4.4;
        }
        public double getArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length : {0}", length);
            Console.WriteLine("Width : {0}", width);
            Console.WriteLine("Area : {0}", getArea());
        }
    }

    class ExecuteRectangular
    {
        static void Main(string[] args)
        {
            Rectangular r = new Rectangular();
            r.AcceptDetails();
            r.getArea();
            r.Display();
            Console.ReadLine();
        }
    }
}

//pass by value and refrence
namespace test {
    public class Test {

        //value type

        static void Increment(int i)
        {

            i = i + 1;

        }

        static void Main()
        {

            int x = 1;

            Increment(x);

            Console.WriteLine("The value of x is: " + x);

            Console.Read();

        }

        //reference type
        static void Increment(ref int i)

        {

            i = i + 1;

        }

        static void Main()

        {

            int x = 1;

            Increment(ref x);

            Console.WriteLine("The value of x is: " + x);

            Console.Read();

        }

        //Turnary operator
        public static void Main(string[] args)
        {
            bool x = true;
            bool y = false;
            bool z = y == x ? true : false;
            Console.WriteLine(z);
        }
        class Program
        {
            static void Main(string[] args)
            {
                int a = 10;

                while (a < 20)
                {
                    Console.WriteLine("value of a: {0}", a);
                    a++;

                    if (a > 15)
                    {
                        break;
                    }
                }
                Console.ReadLine();
            }
        }

        //continue key word

        class Program
        {
            static void Main(string[] args)
            {
                int a = 10;
                do
                {
                    if (a == 15)
                    {
                        a = a + 1;
                        continue;
                    }
                    Console.WriteLine("value of a: {0}", a);
                    a++;
                }
                while (a < 20);
                Console.ReadLine();
            }
        }

        //private access modifier
        class Rectangle
        {
            //member variables
            private double length;
            private double width;

            public void Acceptdetails()
            {
                Console.WriteLine("Enter Length: ");
                length = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Width: ");
                width = Convert.ToDouble(Console.ReadLine());
            }
            public double GetArea()
            {
                return length * width;
            }
            public void Display()
            {
                Console.WriteLine("Length: {0}", length);
                Console.WriteLine("Width: {0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }
        }//end class Rectangle

        class ExecuteRectangle
        {
            static void Main(string[] args)
            {
                Rectangle r = new Rectangle();
                r.Acceptdetails();
                r.Display();
                Console.ReadLine();
            }
        }

        //internal access modifier

        class Rectangle
        {
            internal double length;
            internal double width;

            double GetArea()
            {
                return length * width;
            }
            public void Display()
            {
                Console.WriteLine("Length: {0}", length);
                Console.WriteLine("Width: {0}", width);
                Console.WriteLine("Area: {0}", GetArea());
            }
        }
        class ExecuteRectangle
        {
            static void Main(string[] args)
            {
                Rectangle r = new Rectangle();
                r.length = 4.5;
                r.width = 3.5;
                r.Display();
                Console.ReadLine();
            }
        }

        //recursive function

        class NumberManipulator
        {
            public int factorial(int num)
            {
                /* local variable declaration */
                int result;
                if (num == 1)
                {
                    return 1;
                }
                else
                {
                    result = factorial(num - 1) * num;
                    return result;
                }
            }
            static void Main(string[] args)
            {
                NumberManipulator n = new NumberManipulator();
                //calling the factorial method {0}", n.factorial(6));
                Console.WriteLine("Factorial of 7 is : {0}", n.factorial(7));
                Console.WriteLine("Factorial of 8 is : {0}", n.factorial(8));
                Console.ReadLine();
            }
        }

        //Null Coalescing Operator

        class NullablesAtShow
        {
            static void Main(string[] args)
            {
                double? num1 = null;
                double? num2 = 3.14157;
                double num3;

                num3 = num1 ?? 5.34;
                Console.WriteLine(" Value of num3: {0}", num3);

                num3 = num2 ?? 5.34;
                Console.WriteLine(" Value of num3: {0}", num3);
                Console.ReadLine();
            }
        }

        //compare strings

        class StringProg
        {

            static void Main(string[] args)
            {
                string str1 = "I am c#";
                string str2 = "This file is for test purpose";

                if (String.Compare(str1, str2) == 0)
                {
                    Console.WriteLine(str1 + " and " + str2 + " are equal.");
                }
                else
                {
                    Console.WriteLine(str1 + " and " + str2 + " are not equal.");
                }
                Console.ReadKey();
            }
        }

        //joining strings

        class StringProg
        {

            static void Main(string[] args)
            {
                string[] starray = new string[]{
                    "Down the way nights are dark",
                    "And the sun shines daily on the mountain top",
                    "I took a trip on a sailing ship",
                    "And when I reached Jamaica",
                    "I made a stop"
                };
                //Console.WriteLine(starray);
                string str = String.Join("\n", starray);
                Console.WriteLine(str);
            }
        }


        //use of struct
        struct Books
        {
            private string title;
            private string author;
            private string subject;
            private int book_id;

            public void getValues(string t, string a, string s, int id)
            {
                title = t;
                author = a;
                subject = s;
                book_id = id;
            }

            public void display()
            {
                Console.WriteLine("Title : {0}", title);
                Console.WriteLine("Author : {0}", author);
                Console.WriteLine("Subject : {0}", subject);
                Console.WriteLine("Book_id :{0}", book_id);
            }
        };

        public class testStructure
        {

            public static void Main(string[] args)
            {
                Books Book1 = new Books();
                Books Book2 = new Books();

                /* book 1 specification */
                Book1.getValues("C Programming",
                "xyz", "C Programming Tutorial", 6495407);

                /* book 2 specification */
                Book2.getValues("Telecom Billing",
                "abc", "Telecom Billing Tutorial", 6495700);

                /* print Book1 info */
                Book1.display();

                /* print Book2 info */
                Book2.display();

                Console.ReadKey();
            }
        }

        //enums

        class EnumProgram
        {
            enum Days
            {
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
            }

            static void Main(string[] args)
            {
                int WeekdayStart = (int)Days.Sunday;
                int WeekdayEnd = (int)Days.Friday;

                Console.WriteLine("Monday: {0}", WeekdayStart);
                Console.WriteLine("Friday: {0}", WeekdayEnd);
                Console.ReadKey();
            }
        }

        //multiple inheritance using interface

        class Shape
        {
            public void setWidth(int w)
            {
                width = w;
            }
            public void setHeight(int h)
            {
                height = h;
            }
            protected int width;
            protected int height;
        }

        // Base class PaintCost
        public interface PaintCost
        {
            int getCost(int area);
        }

        public interface xyz
        {
            int getX(int x);
        }
        // Derived class
        class Rectangle : Shape, PaintCost, xyz
        {
            public int getArea()
            {
                return (width * height);
            }
            public int getCost(int area)
            {
                return area * 70;
            }
            public int getX(int x)
            {
                return x * width;
            }
        }
        class RectangleTester
        {
            static void Main(string[] args)
            {
                Rectangle Rect = new Rectangle();
                int area;

                Rect.setWidth(5);
                Rect.setHeight(7);
                area = Rect.getArea();

                // Print the area of the object.
                Console.WriteLine("Total area: {0}", Rect.getArea());
                Console.WriteLine("Total paint cost: ${0}", Rect.getCost(area));
                Console.WriteLine("Test purpose: {0}", Rect.getX(10));
                Console.ReadKey();
            }
        }


        //Regular expression

        class Program
        {
            private static void showMatch(string text, string expr)
            {
                Console.WriteLine("The Expression: " + expr);
                MatchCollection mc = Regex.Matches(text, expr);

                foreach (Match m in mc)
                {
                    Console.WriteLine(m);
                }
            }
            static void Main(string[] args)
            {
                string str = "hay  i am ali ";

                Console.WriteLine("Matching words that start with 'a': ");
                showMatch(str, @"\ba\a*");
                Console.ReadKey();
            }
        }

        //I/O stream
        class Program
        {
            static void Main(string[] args)
            {
                FileStream F = new FileStream("test.dat", FileMode.OpenOrCreate,
                   FileAccess.ReadWrite);

                for (int i = 1; i <= 20; i++)
                {
                    F.WriteByte((byte)i);
                }
                F.Position = 0;
                for (int i = 0; i <= 20; i++)
                {
                    Console.Write(F.ReadByte() + " ");
                }
                F.Close();
                Console.ReadKey();
            }
        }



    }

}


