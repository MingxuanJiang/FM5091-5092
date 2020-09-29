using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TrinomialTree
{
    //in this class, get all option price values
    class GetValues
    {
        static double[] getvalues(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
        {
            //calculate some basic values
            //S0 means Underlying Price
            //K means Strike Price
            //vol means volatility
            //T means tenor
            //N means number of steps
            //r means risk-free rate
            //del means dividend
            //type means call(true) or put(flase)
            //optiontype means European(true) or American(false)
            double dt = T / N;//delta t
            double dx = vol * Math.Sqrt(3 * dt);//delta x
            double v = r - del - Math.Pow(vol, 2) / 2;
            double edx = Math.Pow(Math.E, dx);
            //using during the discount process
            double pu = ((Math.Pow(vol, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / Math.Pow(dx, 2) + v * dt / dx) / 2;
            double pm = 1 - (Math.Pow(vol, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / Math.Pow(dx, 2);
            double pd = ((Math.Pow(vol, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / Math.Pow(dx, 2) - v * dt / dx) / 2;
            double disc = Math.Pow(Math.E, -r * dt);
            double[] result = { dt, dx, v, edx, pu, pm, pd, disc };
            return result;
        }
        //generate a lattice of underlying values
        public class UnderlyingValues
        {
            public static double[,] underlyingvalues(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
            {
                double[,] underlyvalues = new double[N + 1, 2 * N + 1];
                double dt = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[0];//delta t
                double dx = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[1];//delta x
                double v = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[2];
                double edx = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[3];
                underlyvalues[0, N] = S0;//let the first row be the price S0
                //during the discount process
                for (int i = 1; i <= N; i++)
                {
                    for (int j = N - i; j <= N + i; j++)
                    {
                        underlyvalues[i, j] = S0 * Math.Pow(edx, j - N);
                    }
                }
                return underlyvalues;
            }
        }
        //calculate the intrinstic values
        public class IntriValues
        {
            public static double[,] intrinsicvalues(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
            {
                double[,] underlyvalues = GetValues.UnderlyingValues.underlyingvalues(S0, K, vol, T, N, r, del, type, optiontype);
                //the probabilities using during the discount process
                double pu = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[4];
                double pm = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[5];
                double pd = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[6];
                //assign intrinsic values
                double[,] intrinsic = new double[N + 1, 2 * N + 1];
                for (int j = 0; j < underlyvalues.GetLength(1); j++)
                {
                    int i = underlyvalues.GetLength(0) - 1;//let the last column same as the underlying price
                    if (type)//call
                    {
                        intrinsic[i, j] = Math.Max(underlyvalues[i, j] - K, 0);
                    }
                    else//put
                    {
                        intrinsic[i, j] = Math.Max(K - underlyvalues[i, j], 0);
                    }
                }
                double disc = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[7];
                //use the formula to calculate other intrinstic prices
                for (int i = underlyvalues.GetLength(0) - 2; i >= 0; i--)
                {
                    for (int j = N - i; j <= N + i; j++)
                    {
                        intrinsic[i, j] = disc * (pu * intrinsic[i + 1, j + 1] + pm * intrinsic[i + 1, j] + pd * intrinsic[i + 1, j - 1]);
                    }
                }
                return intrinsic;
            }
        }
        //American means calculating underlying values minus K
        public class American
        {
            public static double[,] amer(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
            {
                double[,] intrinsic = IntriValues.intrinsicvalues(S0, K, vol, T, N, r, del, type, optiontype);
                double[,] american = new double[N + 1, 2 * N + 1];
                //the probabilities using during the discount process
                double pu = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[4];
                double pm = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[5];
                double pd = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[6];
                double disc = GetValues.getvalues(S0, K, vol, T, N, r, del, type, optiontype)[7];
                //use the same price as intrinstic price in the last row
                for (int j = 0; j < intrinsic.GetLength(1); j++)
                {
                    int i = intrinsic.GetLength(0) - 1;
                    american[i, j] = intrinsic[i, j];
                }
                // Option price is the larger one of intrinstic prices and discounted prices
                double[,] underlyvalues = UnderlyingValues.underlyingvalues(S0, K, vol, T, N, r, del, type, optiontype);
                for (int i = intrinsic.GetLength(0) - 2; i >= 0; i--)
                {
                    for (int j = N - i; j <= N + i; j++)
                    {
                        american[i, j] = disc * (pu * american[i + 1, j + 1] + pm * american[i + 1, j] + pd * american[i + 1, j - 1]);
                        if (type)//call
                        {
                            american[i, j] = Math.Max(underlyvalues[i, j] - K, american[i, j]);
                        }
                        else//put
                        {
                            american[i, j] = Math.Max(K - underlyvalues[i, j], american[i, j]);
                        }
                    }
                }
                return american;
            }
        }
        //calculate the intrinstic values with European or American
        public class OptionPrice
        {
            public static double[,] optionprice(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
            {
                double[,] intrinsic = IntriValues.intrinsicvalues(S0, K, vol, T, N, r, del, type, optiontype);
                double[,] Option = new double[N + 1, 2 * N + 1];
                double[,] american = American.amer(S0, K, vol, T, N, r, del, type, optiontype);
                if (optiontype)//European: Option price is the same as intrinstic prices
                {
                    for (int i = 0; i < intrinsic.GetLength(0); i++)
                    {
                        for (int j = 0; j < intrinsic.GetLength(1); j++)
                        {
                            Option[i, j] = intrinsic[i, j];
                        }
                    }
                }
                else//American: Option price is the same as american prices
                {
                    for (int i = 0; i < intrinsic.GetLength(0); i++)
                    {
                        for (int j = 0; j < intrinsic.GetLength(1); j++)
                        {
                            Option[i, j] = american[i, j];
                        }
                    }
                }
                return Option;
            }
        }
    }
}
