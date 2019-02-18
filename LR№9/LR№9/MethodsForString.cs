using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    public static class MethodsForString
    {
        static string GetString(ref string str, Func<string, string> func)
        {
            string result = "";
            if (!String.IsNullOrEmpty(str))
                result = func(str);
            return result;
        }

        public static string DeleteCommas(string str) => str.Replace(",", String.Empty);                                                    // возвращает строку без запятых

        public static int WordCount(string str) => str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;   // возвращает количество слов в строке

        public static string Reverse(string str)                                                                                            // возвращает инверсию строки
        {
            if (!string.IsNullOrEmpty(str))
            {
                char[] chars = str.ToCharArray();
                Array.Reverse(chars);
                str = new string(chars);
            }
            return str;
        }

        public static string RemoveExtraSpaces(string str)                                                                                  // возвращает указанную строку без лишних пробелов
        {
            var sb = new StringBuilder();
            var prevIsWhitespace = false;
            foreach (var ch in str)
            {
                var isWhitespace = char.IsWhiteSpace(ch);
                if (prevIsWhitespace && isWhitespace)
                {
                    continue;
                }
                sb.Append(ch);
                prevIsWhitespace = isWhitespace;
            }
            return sb.ToString();
        }

        public static string FindNumbers(string str)                                                                                        // возвращает новую строку, состоящую из цифр, входящих в строку
        {
            char[] symbols = str.ToCharArray();
            string newString = "";
            foreach (char symbol in symbols)
            {
                if (char.IsDigit(symbol))
                    newString += symbol;
            }
            return newString;
        }
    }
}
