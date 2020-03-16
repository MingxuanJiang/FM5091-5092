using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSim_CV
{
    class Option
    {
        //set some variables
        private double s, k, r, sigma, T;
        private int trials, steps; private bool type, ant,cv;
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
        //TYPE includes call and put
        public bool TYPE { get { return type; } set { type = value; } }
        //Rn means the matrix to store random number
        public double[,] Rn { get { return rn; } set { rn = value; } }
        //ant means whether use Ant Var reduction or not
        public bool Ant { get { return ant; } set { ant = value; } }
        //ant means whether us Control Var or not
        public bool CV {get{return cv;}set{cv = value;}}
        public Option(double s, double k,double r,double sigma, double T, int trials, int steps,bool type, bool ant, bool cv)
        {
            S = s;
            K = k;
            Rate = r;
            Sigma = sigma;
            Tenor = T;
            Sims = trials;
            Steps = steps;
            TYPE = type;
            Ant = ant;
            CV = cv;
        }
        //First, calculate the option price
        public virtual double[] OptionPrice(double[,] Rn)
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
        public static double BSDelta(double S, double K, double Rate, double Sigma, double dt,bool TYPE)
        {
            double d1 = (Math.Log(S / K) + (Rate + Math.Pow(Sigma, 2)) * dt) / (Sigma * Math.Sqrt(dt));
            if (TYPE == true)
                return cdf(d1);
            else
                return cdf(d1) - 1;
        }
        public static double cdf(double x)
        {
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            double sign = 1;
            if(x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * y);
        }
    }
}
