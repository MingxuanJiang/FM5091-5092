using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TrinomialTree
{
    //output all option prices
    class OutputValues
    {
        public static double[,,] readdata(double[,] inputdata1, double[,] inputdata2, double[,] inputdata3, double[,] inputdata4, int a)
        //a means how many floors does OutputResults have
        {
            double[,,] OutputResults = new double[inputdata1.GetLength(0), inputdata1.GetLength(1), a];
            for (int i = 0; i < OutputResults.GetLength(0); i++)
            {
                for (int j = 0; j < OutputResults.GetLength(1); j++)
                {
                    OutputResults[i, j, 0] = inputdata1[i, j];//input underlying values
                    OutputResults[i, j, 1] = inputdata2[i, j];//input intrinsic values
                    OutputResults[i, j, 2] = inputdata3[i, j];//input American prices
                    OutputResults[i, j, 3] = inputdata4[i, j];//input Option Prices
                }
            }
            return OutputResults;
        }
        public double[,,] output(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
        {
            double[,] underlyvalues = GetValues.UnderlyingValues.underlyingvalues(S0, K, vol, T, N, r, del, type, optiontype);
            double[,] intrinsic = GetValues.IntriValues.intrinsicvalues(S0, K, vol, T, N, r, del, type, optiontype);
            double[,] American = GetValues.American.amer(S0, K, vol, T, N, r, del, type, optiontype);
            double[,] Option = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r, del, type, optiontype);
            double[,,] a = OutputValues.readdata(underlyvalues, intrinsic, American, Option, 4);
            return a;
        }
    }
}
