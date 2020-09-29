using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TrinomialTree
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputValues a = new OutputValues();
            Console.WriteLine("Enter S0: (double)");
            double S0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter K: (double)");
            double K = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter vol: (double)");
            double vol = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter T: (double)");
            double T = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter N: (int)");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter r: (double)");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter dividend: (double)");
            double dividend = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter type(call true, put false): (bool)");
            bool type = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter optiontype(Eur true, Ame false): (bool)");
            bool optiontype = Convert.ToBoolean(Console.ReadLine());
            //You can also choice to outprint all related data
            //Console.WriteLine("Underlying price:");
            //double[,,] c = a.output(S0, K, vol, T, N, r, dividend, type, optiontype);
            //PrintResults(c, 0);//underlying price
            //Console.WriteLine("Intrinsic price:");
            //PrintResults(c, 1);//Intrinsic price
            //Console.WriteLine("American price:");
            //PrintResults(c, 2);//American price
            //Console.WriteLine("Option price:");
            //PrintResults(c, 3);//all Option price
            Console.Write("Option price: ");
            double[,] op = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r, dividend, type, optiontype);
            Console.Write(op[0, N] + "\n");//option price
            double[] greek = GreekValues.output(S0, K, vol, T, N, r, dividend, type, optiontype, 0.001, 0.001);
            Console.WriteLine("Delta: " + greek[0]);//delta
            Console.WriteLine("Gamma: " + greek[1]);//gamma
            Console.WriteLine("Vega: " + greek[2]);//vega
            Console.WriteLine("Theta: " + greek[3]);//theta
            Console.WriteLine("Rho: " + greek[4]);//rho
            Console.ReadLine();
        }
        //print results
        public static double[,] PrintResults(double[,,] InputValues, int a)
        {
            double[,] OutputResults = new double[InputValues.GetLength(0), InputValues.GetLength(1)];
            //input InputValues into OutputResults
            for (int i = 0; i < OutputResults.GetLength(0); i++)
            {
                for (int j = 0; j < OutputResults.GetLength(1); j++)
                {
                    OutputResults[i, j] = InputValues[i, j, a];
                }
            }
            //print the result
            for (int m = 0; m < OutputResults.GetLength(0); m++)
            {
                for (int n = 0; n < OutputResults.GetLength(1); n++)
                {
                    Console.Write("\t" + Math.Round(OutputResults[m, n], 4));
                }
                Console.Write("\n");
            }
            return OutputResults;
        }
    }
}
