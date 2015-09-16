//Microsoft Visual Studio Professional 2013
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Чтение слов из файла

            var sentence = File.ReadAllText("input.txt", Encoding.Default);
            sentence = Regex.Replace(sentence, @"[^А-я ]", String.Empty);
            var word = sentence.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
            var m = word.Length;

            #endregion

            #region Определение самого длинного палиндрома

            var palindrome = String.Empty;
            for (var i = 0; i < m; i++)
                if (IsPalindrome(word[i]) && word[i].Length > palindrome.Length)
                        palindrome = word[i];

            #endregion

            #region Вывод самого длинного палиндромма, если имеется

            File.WriteAllText("output.txt", palindrome.Equals(String.Empty) ? "отсутствует" : palindrome);

            #endregion
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
