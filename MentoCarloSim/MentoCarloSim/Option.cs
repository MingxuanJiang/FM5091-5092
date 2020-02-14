using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoCarloSim
{
    class Option
    {
        //set some variables
        private double s, k, r, sigma, T;
        private int trials, steps; private bool type;
        private double[,] rn;
        //S means underlying
        public double S { get { return s; } set { s = value; } }
        //K means strike price
        public double K { get { return k; } set { k = value; } }
        //Rate means interest rate
        public double Rate { get { return r; } set { r = value; } }
        //Sigma means volatility
        public double Sigma { get { return sigma; } set { sigma = value; } }
        //Tenor means the time to hold
        public double Tenor { get { return T; } set { T = value; } }
        //Sims means the trials of Matro Carlo Simulations
        public int Sims { get { return trials; } set { trials = value; } }
        //Steps means the steps to calculate the option
        public int Steps { get { return steps; } set { steps = value; } }
        //Type includes call and put
        public bool Type { get { return type; } set { type = value; } }
        //Rn means the matrix to store random number
        public double[,] Rn { get { return rn; } set { rn = value; } }
        //First, calculate the option price

        public static double[] OptionPrice(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            //allsims store the price of each step
            double[,] allsims = new double[Sims, Steps + 1];
            //let the first column be S
            for (int i = 0; i < Sims; i++)
            {
                allsims[i, 0] = S;
            }
            //calculate the option price step by step
            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                }
            }
            double[] value = new double[Sims];
            if (Type == true)//call
            {
                for (int i = 0; i < Sims; i++)
                {
                    value[i] = Math.Max(allsims[i, Steps] - K, 0);
                }
            }
            else//put
            {
                for (int i = 0; i < Sims; i++)
                {
                    value[i] = Math.Max(K - allsims[i, Steps], 0);
                }
            }
            //calculate option price
            double optionprice = value.Average() * Math.Exp(-Rate * Tenor);
            //calculate std
            double[] C = new double[Sims];
            for (int i = 0; i < Sims; i++)
                C[i] = value[i] * Math.Exp(-Rate * Tenor);
            double sd = Option.std(C, Sims);
            //store the result into matrix result
            double[] result = new double[2];
            result[0] = optionprice;
            result[1] = sd;
            return result;
        }
        //Then, calculate the Greek values
        //Delta
        public static double Delta(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double delta = (Option.OptionPrice(1.001 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - Option.OptionPrice(0.999 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.002 * S);
            return delta;
        }
        //Gamma
        public static double Gamma(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double gamma = (Option.OptionPrice(1.001 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - 2 * Option.OptionPrice(S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] + Option.OptionPrice(0.999 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (Math.Pow((0.001 * S), 2));
            return gamma;
        }
        //Vega
        public static double Vega(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double vega = (Option.OptionPrice(S, K, Rate, 1.1 * Sigma, Tenor, Sims, Steps, Type, Rn)[0] - Option.OptionPrice(S, K, Rate, 0.9 * Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public static double Theta(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double theta = (Option.OptionPrice(S, K, Rate, Sigma, 1.1 * Tenor, Sims, Steps, Type, Rn)[0] - Option.OptionPrice(S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.1 * Tenor);
            return theta;
        }
        //Rho
        public static double Rho(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double rho = (Option.OptionPrice(S, K, 1.1 * Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - Option.OptionPrice(S, K, 0.9 * Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.2 * Rate);
            return rho;
        }
        //the function to calculate std
        public static double std(double[] C, int Sims)
        {
            //the average of matrix C
            double C0 = C.Average();
            double[] sum = new double[Sims];
            for (int i = 0; i < Sims; i++)
                sum[i] = (C[i] - C0) * (C[i] - C0);
            //calculate std
            double sd = Math.Sqrt((sum.Sum()) / (Sims - 1));
            return sd;
        }
    }
}
