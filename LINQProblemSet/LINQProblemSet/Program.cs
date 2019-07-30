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
            //GetSubstrings(); // done
            //RemoveDuplicates(); // done
            //AverageGrades(); // done
            //GetLetterFrequency();

            Console.ReadKey();
        }

        static void GetSubstrings()
        {
            // 1. Using LINQ, write a function that returns all words that contain the substring “th” from a list.
            List<string> words = new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" };
            IEnumerable<string> results = words.Where(w => w.Contains("th"));
            foreach(string word in results)
            {
                Console.WriteLine(word);
            }
        }

        static void RemoveDuplicates()
        {
            // 2.Using LINQ, write a function that takes in a list of strings and returns a copy of the list without duplicates.
            List<string> names = new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" };
            IEnumerable<string> results = names.Distinct();
            foreach (string word in results)
            {
                Console.WriteLine(word);
            }
        }

        static void AverageGrades()
        {
            // 3.Using LINQ, write a function that calculates the class grade average after dropping the lowest grade for each student.The function should take in a list of strings of grades (e.g., one string might be "90,100,82,89,55"), drops the lowest grade from each string, averages the rest of the grades from that string, then averages the averages.
            List<string> classGrades = new List<string>()
            {
                "80,100,92,89,65",
                "93,81,78,84,69",
                "73,88,83,99,64",
                "98,100,66,74,55"
            };
            List<double> individualAverages = new List<double>();
            foreach (string initialValue in classGrades)
            {
                var values = initialValue.Split(',').OrderBy(s => s).Select(s => Convert.ToDouble(s)).ToList();
                var updated = values.Where(d => d > values.Min()).Average();
                individualAverages.Add(updated);
            }
            var totalAverage = individualAverages.Average();
            Console.WriteLine(totalAverage);
            // Expected output: 86.125
        }

        static void GetLetterFrequency()
        {
            // 4.Write a function that takes in a string of letters(i.e. “Terrill”) and returns an alphabetically ordered string corresponding to the letter frequency(i.e. "E1I1L2R2T1")
        }
    }
}
