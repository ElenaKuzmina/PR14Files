using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PR14Files
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"Input.txt");
            StreamWriter sw = new StreamWriter(@"Rezult.txt", false,
                Encoding.Default);
            string text = sr.ReadToEnd();
            Console.WriteLine(text);
            string[] textArray = text.Split(' ');
           //v4 
            int[] lengthArray = new int[textArray.Length];
            lengthArray = textArray.Select(x => DeletePunctuation(x).Length).ToArray();
            Console.WriteLine(lengthArray.Min());
            int count = textArray.Count(x => x.Length == lengthArray.Min());
            Console.WriteLine(count);
            sw.WriteLine("Вариант 4");
            sw.WriteLine($"количество самых коротких слов: {count}");

            //v8 Заменить в исходном тексте все
            //прописные буквы на строчные, и наоборот
            string newtext = "";
            foreach (char c in text)
            {
                if (Char.IsUpper(c))
                    newtext += c.ToString().ToLower();
                else
                    newtext += c.ToString().ToUpper();

            }
            sw.WriteLine("Вариант 8");
            Console.WriteLine(newtext);
            sw.WriteLine($"{newtext}");
        //

            //v1 Определить, входит ли заданное слово в текст, и если входит, то сколько раз
            Console.WriteLine("Вариант 1");
            Console.WriteLine("введите искомое слово:");
            string word = Console.ReadLine();
            Console.WriteLine($"Входит ли искомое слово в текст? {textArray.Contains(word)}");
            Console.WriteLine(textArray.Count(x => DeletePunctuation(x) == word));
            sw.WriteLine("Вариант 1");
            sw.WriteLine($"Входит ли искомое слово в текст? {textArray.Contains(word)}");
            sw.WriteLine(textArray.Count(x => DeletePunctuation(x) == word));

            //v3 Составить в алфавитном порядке список всех слов, встречающихся в тексте.
            sw.WriteLine("Вариант 3");
            foreach (string w in textArray.OrderBy(x => x).Distinct())
            {
                Console.WriteLine(DeletePunctuation(w));
                sw.WriteLine(DeletePunctuation(w));
            }
            //v6 Определить, каких букв в тексте больше – русских или английских.
            sw.WriteLine("Вариант 6");
           
            string rusalphabit = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string englishalphabit = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
           int ruscount =  text.Count(x => rusalphabit.Contains(x));
            int engcount = text.Count(x => englishalphabit.Contains(x));
            Console.WriteLine("Каких букв больше? ");
            if (ruscount > engcount) Console.WriteLine("Русских букв больше");
            else
                if (ruscount < engcount) Console.WriteLine("Английских букв больше");
            else
                Console.WriteLine("Одинаковое количесто русских и английских букв");
            sw.WriteLine("Каких букв больше? ");
            if (ruscount > engcount) sw.WriteLine("Русских букв больше");
            else
                if (ruscount < engcount) sw.WriteLine("Английских букв больше");
            else
                sw.WriteLine("Одинаковое количесто русских и английских букв");

            sw.Close();
            Console.WriteLine("Создан репозиторий на GIT!!!");
            Console.ReadKey();
        }
        /// <summary>
        /// удаление знаков препинания из слова
        /// </summary>
        /// <param name="inputword"></param>
        /// <returns></returns>
       private static string DeletePunctuation(string inputword)
        {
            string outword = "";
            string punctuation = ".,?!;:-\"\'()";
            foreach(char simbol in inputword)
                if (!punctuation.Contains(simbol)) outword += simbol;
            return outword;
        }

    }
}
