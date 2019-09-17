using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaritimeSolution
{
    /**
     * Name Program.cs
     * Created by Calum Macaskill
     * Date 13/9/2019
     * Purpose:
     * This is a command line executable which provides the following
     * 1) reviews the provided method reversestring
     * 2) Reads a CSV file contents into memory
     *  Avoiding built in methods like .Sum, .Average etc, implements algorithms to 
     * 3) Calculates the arithmetic mean 
     * 4) Calculates the standard deviation
     * 5) Computes the frequencies of numbers in bins of 10 (0 to < 10, 10 to <20 and so on.)
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Test reversestring
            string target = "abc";
            string s = reversestring(target);
            Console.WriteLine("reverse of abc is " + s);

            // create an instance of the solution
            clsMathsHelper myMathsHelper = new clsMathsHelper();

            // Test non library squareRoot function
            double num = 14.67;
            Console.WriteLine("library implementation square root of 14.67 = " + Math.Sqrt(num));  // library function
            Console.WriteLine("bespoke implementation square root of 14.67 = " + myMathsHelper.squareRoot(num));  // bespoke implementation

            // Get the data from file and path.
            string sampleCSV = string.Empty;
            sampleCSV = @"..\..\SampleDataMaritime.csv";
            string[] result = loadCSV(sampleCSV);

            // write out file contents
            // showFileContents(result);


            Console.WriteLine("Arithmetic mean = " + myMathsHelper.getArithmeticMean(result));
            Console.WriteLine("Standard Deviation = " + myMathsHelper.calculateStdDev(result));

            var list = myMathsHelper.calculateFrequenciesOfNumbers(result);

            foreach (var element in list)
            {
                // write out the bin results
                Console.WriteLine(element);
            }

            Console.WriteLine("Done");
        }

        public static string test()
        {

            return "hello";
        }


        /*
         * Name: showFileContents
         * Write an array of strings to the console
         */
        static void showFileContents(string[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("item number " + (i + 1) + "  " + result[i]);
            }
        }

        /*
         * Name: loadCSV
         * Loads a CSV file into an array of strings 
         */
        private static string[] loadCSV(string filename)
        {
            // Get the file's text.
            string[] line_r = null;
            try
            {

                string whole_file = System.IO.File.ReadAllText(filename);

                // Split into lines.
                whole_file = whole_file.Replace('\n', '\r');
                string[] lines = whole_file.Split(new char[] { '\r' },
                    StringSplitOptions.RemoveEmptyEntries);

                // See how many rows and columns there are.
                int num_rows = lines.Length;
                int num_cols = lines[0].Split(',').Length;

                line_r = lines[0].Split(',');

                // Allocate the data array.
                string[,] values = new string[num_rows, num_cols];
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return line_r;
        }


        /*
         * Name: reversestring
         * A given function for comment
        */
        public static string reversestring(string sz)
        {
            string result = string.Empty;
            for (int i = sz.Length - 1; i >= 0; i--)
            {
                result += sz[i];
            }
            return result;
        }
    }
}
