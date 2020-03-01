using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo_AntitheticVar
{
    class Option
    {
        //set some variables
        private double s, k, r, sigma, T;
        private int trials, steps; private bool type, ant;
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
        //ant means whether use Ant Var reduction or not
        public bool Ant { get { return ant; } set { ant = value; } }
        //First, calculate the option price
        public virtual double[] OptionPrice(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            double[] result = new double[2];
            return result;
        }
        //Then, calculate the Greek values
        //Delta
        public virtual double Delta(double[,] Rn)
        {
            return 0;
        }
        //Gamma
        public virtual double Gamma(double[,] Rn)
        {
            return 0;
        }
        //Vega
        public virtual double Vega(double[,] Rn)
        {
            return 0;
        }
        //Theta
        public virtual double Theta(double[,] Rn)
        {
            return 0;
        }
        //Rho
        public virtual double Rho(double[,] Rn)
        {
            return 0;
        }
        //the function to calculate deviation
        public static double deviation(double[] C, int Sims)
        {
            //the average of matrix C
            double C0 = C.Average();
            double[] sum = new double[Sims];
            for (int i = 0; i < Sims; i++)
                sum[i] = (C[i] - C0) * (C[i] - C0);
            //calculate deviation
            double d = (sum.Sum()) / (Sims - 1);
            return d;
        }
    }
}
