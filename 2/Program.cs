//Microsoft Visual Studio Professional 2013
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------Чтение слов из файла----------
            var sentence = File.ReadAllText("input.txt", Encoding.Default);
            sentence = Regex.Replace(sentence, @"[^А-я ]", String.Empty);
            var word = sentence.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            //----------------------------------------

            //----------Определение самого длинного палиндрома----------
            string[] palindrome = {String.Empty};
            foreach (var str in word.Where(str => IsPalindrome(str) && str.Length > palindrome[0].Length))
            {
                palindrome[0] = str;
            }
            //----------------------------------------------------------

            //----------Вывод самого длинного палиндромма, если имеется----------
            File.WriteAllText("output.txt", palindrome[0].Equals(String.Empty) ? "отсутствует" : palindrome[0]);
            //-------------------------------------------------------------------
        }

        /// <summary>
        /// Проверка на палиндромность
        /// </summary>
        /// <param name="str">Проверяемая строка</param>
        /// <returns></returns>
        static bool IsPalindrome(string str)
        {
            str = str.ToLower();
            if (str.Length < 2)
                return false;
            for (var i = 0; i < str.Length/2; i++)
                if (!str[i].Equals(str[str.Length - i - 1]))
                    return false;
            return true;
        }
    }
}
