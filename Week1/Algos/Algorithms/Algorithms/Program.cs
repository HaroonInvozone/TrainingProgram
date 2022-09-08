using System;

namespace Algorithms
{
    class Algo
    {

        //public static Tuple<List<string>, List<int>> frequencyofcharacters(string str)
        //{
        //    char[] list1 = new char[str.Length];
        //    List<int> list2 = new List<int>();
        //    char[] ch = new char[str.Length];
        //    for (int i = 0; i < str.Length; i++)
        //    {
        //        ch[i] = str[i];
        //    }

        //    for (int i = 0; i <= str.Length; i++)
        //    {
        //        char x = ch[i];
        //        if (!list1.Contains(x))
        //        {
        //            list1[i] += x;
        //        }
        //    }


        //    return Tuple.Create(list1, list2);
        //}
        public string ReverseAString(string str)
        {
            char[] reversed = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                reversed[i] = str[j];
                reversed[j] = str[i];
            }
            return new string(reversed);
        }
        public string[] ReverseAStringArray(string[] str)
        {
            string[] reversed = new string[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                reversed[i] = str[j];
                reversed[j] = str[i];
            }
            return reversed;
        }
        public Dictionary<char,int> frequencyOfCharacter(string str) 
        {
            Dictionary<char,int> frequency = new Dictionary<char,int>();
            char[] Strarr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                Strarr[i] = str[i];
            }
            for (int i = 0; i < Strarr.Length;i++) {
                char c = Strarr[i]; 
                if (frequency.ContainsKey(c))
                    frequency[c] = frequency[c] + 1;
                else
                    frequency.Add(c, 1);
            }
            return frequency;
        }
        static void Main(string[] args)
        {
            Algo algo = new Algo();
            string[] ArrayS = { "hy", "by" ,"tyty"};
            string result = algo.ReverseAString("invozone");
            Dictionary<char,int> keyValuePairs = algo.frequencyOfCharacter(result);
            string[] stringsarry = algo.ReverseAStringArray(ArrayS);
            Console.WriteLine(result);
            foreach (var item in keyValuePairs)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stringsarry)
            {
                Console.WriteLine(item);
            }
        }
    }
}
