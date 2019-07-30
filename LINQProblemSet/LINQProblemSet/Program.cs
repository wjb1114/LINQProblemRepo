using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQProblemSet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> classGrades = new List<string>()
            {
                "80,100,92,89,65",
                "93,81,78,84,69",
                "73,88,83,99,64",
                "98,100,66,74,55"
            };

            Console.WriteLine(GetSubstrings(new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" }, "th"));
            Console.WriteLine(RemoveDuplicates(new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" }));
            Console.WriteLine(AverageGrades(classGrades));
            Console.WriteLine(GetLetterFrequency("Terrill"));
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static string GetSubstrings(List<string> words, string delimiter)
        {
            // 1. Using LINQ, write a function that returns all words that contain the substring “th” from a list.
            IEnumerable<string> results = words.Where(w => w.Contains(delimiter));
            string result = "";
            foreach(string word in results)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }
                result += word;
            }
            return result;
        }

        static string RemoveDuplicates(List<string> names)
        {
            // 2.Using LINQ, write a function that takes in a list of strings and returns a copy of the list without duplicates.
            IEnumerable<string> results = names.Distinct();
            string result = "";
            foreach (string word in results)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }
                result += word;
            }
            return result;
        }

        static double AverageGrades(List<string> classGrades)
        {
            // 3.Using LINQ, write a function that calculates the class grade average after dropping the lowest grade for each student.The function should take in a list of strings of grades (e.g., one string might be "90,100,82,89,55"), drops the lowest grade from each string, averages the rest of the grades from that string, then averages the averages.
            List<double> individualAverages = new List<double>();
            foreach (string initialValue in classGrades)
            {
                var values = initialValue.Split(',').OrderBy(s => s).Select(s => Convert.ToDouble(s)).ToList();
                var updated = values.Where(d => d > values.Min()).Average();
                individualAverages.Add(updated);
            }
            var totalAverage = individualAverages.Average();
            return totalAverage;
            // Expected output: 86.125
        }

        static string GetLetterFrequency(string word)
        {
            // 4.Write a function that takes in a string of letters(i.e. “Terrill”) and returns an alphabetically ordered string corresponding to the letter frequency(i.e. "E1I1L2R2T1")
            var characters = word.ToUpper().ToCharArray().OrderBy(c => c).GroupBy(c => c);
            string result = "";
            foreach (var c in characters)
            {
                result += c.Key;
                result += c.Count();
            }
            return result;
        }
    }
}
