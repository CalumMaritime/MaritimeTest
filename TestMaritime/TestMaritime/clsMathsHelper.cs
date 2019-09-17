using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaritimeSolution
{
    /**
     * Name clsMathsHelper.cs
     * Created by Calum Macaskill
     * Date 13/9/2019
     * Purpose:
     * Avoiding built in methods like .Sum, .Average etc, implements algorithms to 
     * 1) Calculates the arithmetic mean 
     * 2) Calculates the standard deviation
     * 3) Computes the frequencies of numbers in bins of 10 (0 to < 10, 10 to <20 and so on.)
     */
    class clsMathsHelper
    {
        private double[] doubles = null;
        private double mean = 0.0;
        private int zeroToTen = 0;
        private int tenToTwenty = 0;
        private int twentyToThirty = 0;
        private int thirtyToForty = 0;
        private int fortyToFifty = 0;
        private int fiftyToSixty = 0;
        private int sixtyToSeventy = 0;
        private int seventyToEighty = 0;
        private int eightyToNinety = 0;
        private int ninetyToOneHundred = 0;
        private int Unclassified = 0;
        private int total = 0;

        /*
        * Name: loadDoubles
        * Description: Write an array of strings to the console
        * Version: 1.0
        * Params: string[] 
        * Returns: void
        * Exception: NullReferenceException
        */
        private void loadDoubles(string[] ar)
        {
            try
            {
                doubles = new double[ar.Length];
                for (int i = 0; i < ar.Length; i++)
                {
                    doubles[i] = double.Parse(ar[i], System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Data + " " + e.Message);
            }
        }

        /*
        * Name: loadDoubles
        * Description: Calcultes the arithmetic mean 
        * Version: 1.0
        * Params: string[] 
        * Returns: double the mean
        */
        public double getArithmeticMean(string[] ar)
        {
            // Is the data extrtacted, tramsformed and loaded
            if (doubles == null)
                loadDoubles(ar);

            double result = 0.0;
            double sum = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                sum += doubles[i];
            }
            result = sum / ar.Length;   // result now has the average of those numbers.
            return result;
        }

        /*
        * Name: calculateStdDev
        * Description: Calcultes the standard deviation of a array
        * Version: 1.0
        * Params: string[] 
        * Returns: double the standard deviation
        */
        public double calculateStdDev(string[] ar)
        {
            // Is the data extrtacted, tramsformed and loaded
            if (doubles == null)
                loadDoubles(ar);

            // Get the mean.
            if (mean == 0.0)
                mean = getArithmeticMean(ar);

            // Get the sum of the squares of the differences
            // between the values and the mean.
            var squares_query =
                from double value in doubles
                select (value - mean) * (value - mean);

            double sum_of_squares = squares_query.Sum();
            double result = (sum_of_squares / ar.Count());

            return squareRoot(result);
        }


        /*
        * Name: calculateFrequenciesOfNumbers
        * Description: Computes the frequencies of numbers in bins of 10 (0 to < 10, 10 to <20 and so on.)
        * Version: 1.0
        * Params: string[] 
        * Returns: a list of bins and frequency of each
        */
        public List<KeyValuePair<string, int>> calculateFrequenciesOfNumbers(string[] ar)
        {
            // Is the data extrtacted, tramsformed and loaded
            if (doubles == null)
                loadDoubles(ar);

            var list = new List<KeyValuePair<string, int>>();

            // test the data
            for (int i = 0; i < doubles.Length; i++)
                getBinByLabel(doubles[i]);

            // load the reults
            list.Add(new KeyValuePair<string, int>("zeroToTen = ", zeroToTen));
            list.Add(new KeyValuePair<string, int>("tenToTwenty = ", tenToTwenty));
            list.Add(new KeyValuePair<string, int>("twentyToThirty = ", twentyToThirty));
            list.Add(new KeyValuePair<string, int>("thirtyToForty = ", thirtyToForty));
            list.Add(new KeyValuePair<string, int>("fortyToFifty = ", fortyToFifty));

            list.Add(new KeyValuePair<string, int>("fiftyToSixty = ", fiftyToSixty));
            list.Add(new KeyValuePair<string, int>("sixtyToSeventy = ", sixtyToSeventy));
            list.Add(new KeyValuePair<string, int>("seventyToEighty = ", seventyToEighty));
            list.Add(new KeyValuePair<string, int>("eightyToNinety = ", eightyToNinety));
            list.Add(new KeyValuePair<string, int>("ninetyToOneHundred = ", ninetyToOneHundred));
            list.Add(new KeyValuePair<string, int>("Unclassified = ", Unclassified));
            list.Add(new KeyValuePair<string, int>("total = ", total));

            return list;
        }

        /*
        * Name: squareRoot
        * Description: Returns the square root of n. 
        * Version: 1.0
        * Params: double n
        * Returns: the square root of n. 
        */
        public double squareRoot(double n)
        {

            // We are using n itself as initial approximation 
            double x = n;
            double y = 1;

            // e decides the accuracy level 
            double e = 0.0000001;
            while (x - y > e)
            {
                x = (x + y) / 2;
                y = n / x;
            }
            return x;
        }

        /*
        * Name: getBinByLabel
        * Description: Checks the value and increments count for that bin.  Maintains a running total for a check
        * Version: 1.0
        * Params: double value
        * Returns: The Label for the value or a message if the value falls outside the range. 
        */
        string getBinByLabel(double value)
        {
            if (value >= 0 && value < 10) { zeroToTen++; total++; return ("0 to < 10"); };
            if (value >= 10 && value < 20) { tenToTwenty++; total++; return ("10 to <20"); };
            if (value >= 20 && value < 30) { twentyToThirty++; total++; return ("20 to <30"); };
            if (value >= 30 && value < 40) { thirtyToForty++; total++; return ("30 to <40"); };
            if (value >= 40 && value < 50) { fortyToFifty++; total++; return ("40 to <50"); };
            if (value >= 50 && value < 60) { fiftyToSixty++; total++; return ("50 to <60"); };
            if (value >= 60 && value < 70) { sixtyToSeventy++; total++; return ("60 to <70"); };
            if (value >= 70 && value < 80) { seventyToEighty++; total++; return ("70 to <80"); };
            if (value >= 80 && value < 90) { eightyToNinety++; total++; return ("80 to <90"); };
            if (value >= 90 && value < 100) { ninetyToOneHundred++; total++; return ("90 to <100"); }
            else return ("Unclassified");
        }
    }
}



/* public double getLargestValue(string[] ar)
{
    double result = 0.0;
    double tmp = 0;

    for (int i = 0; i < ar.Length; i++)
    {
        tmp = double.Parse(ar[i], System.Globalization.CultureInfo.InvariantCulture);
        if (tmp > result)
        {
            result = tmp;
        }
    }

    return result;
}
*/
