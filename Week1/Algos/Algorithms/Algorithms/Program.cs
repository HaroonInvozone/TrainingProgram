using System;

namespace Algorithms
{
    class Algo
    {
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
