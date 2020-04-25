using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MonteCarloSim_ExoticOptions
{
    abstract class Option
    {
        //set some variables
        private double s, k, r, sigma, T, rebate, barrier;
        private int trials, steps, barrierType; private bool type, ant, cv, multithreading;
        private double[,] rn;
        //S means underlying
        protected double S { get { return s; } set { s = value; } }
        //K means strike price
        protected double K { get { return k; } set { k = value; } }
        //Rate means interest rate
        protected double Rate { get { return r; } set { r = value; } }
        //Sigma means volatility
        protected double Sigma { get { return sigma; } set { sigma = value; } }
        //Tenor means the time to hold
        protected double Tenor { get { return T; } set { T = value; } }
        //Sims means the trials of Matro Carlo Simulations
        protected int Sims { get { return trials; } set { trials = value; } }
        //Steps means the steps to calculate the option
        protected int Steps { get { return steps; } set { steps = value; } }
        //TYPE includes call and put
        protected bool TYPE { get { return type; } set { type = value; } }
        //Rn means the matrix to store random number
        protected double[,] Rn { get { return rn; } set { rn = value; } }
        //ant means whether use Ant Var reduction or not
        protected bool Ant { get { return ant; } set { ant = value; } }
        //CV means whether use Control Var or not
        protected bool CV { get { return cv; } set { cv = value; } }
        //Multithreading means whether use multithreading or not
        protected bool Multithreading { get { return multithreading; } set { multithreading = value; } }
        //Rabate
        protected double Rebate { get { return rebate; } set { rebate = value; } }
        //Barrier
        protected double Barrier { get { return barrier; } set { barrier = value; } }
        //Barrier Type
        protected int BarrierType { get { return barrierType; } set { barrierType = value; } }
        public Option(double s, double k, double r, double sigma, double T, int trials, int steps, bool type, bool ant, bool cv, bool multithreading, double rebate, double barrier, int barrierType)
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
            Multithreading = multithreading;
            RandomNumber random = new RandomNumber();
            random.Sims = Sims;
            random.Steps = Steps;
            if (Multithreading)
                Rn = random.RNMT();
            else
                Rn = random.RN();
            Rebate = rebate;
            Barrier = barrier;
            BarrierType = barrierType;
        }
        //First, calculate the option price
        public abstract double[] OptionPrice();
        //Then, calculate the Greek values
        //Delta
        public double Delta()
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice()[0];
            S = 0.999 * ori;
            double op2 = OptionPrice()[0];
            S = ori;
            double delta = (op1 - op2) / (0.002 * S);
            return delta;
        }
        //Gamma
        public double Gamma()
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice()[0];
            S = ori;
            double op2 = OptionPrice()[0];
            S = 0.999 * ori;
            double op3 = OptionPrice()[0];
            S = ori;
            double gamma = (op1 - 2 * op2 + op3) / (Math.Pow((0.001 * ori), 2));
            return gamma;
        }
        //Vega
        public double Vega()
        {
            double ori = Sigma;
            Sigma = 1.1 * ori;
            double op1 = OptionPrice()[0];
            Sigma = 0.9 * ori;
            double op2 = OptionPrice()[0];
            Sigma = ori;
            double vega = (op1 - op2) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public double Theta()
        {
            double ori = Tenor;
            Tenor = 1.1 * ori;
            double op1 = OptionPrice()[0];
            Tenor = ori;
            double op2 = OptionPrice()[0];
            double theta = (-1) * (op1 - op2) / (0.1 * Tenor);
            return theta;
        }
        //Rho
        public double Rho()
        {
            double ori = Rate;
            Rate = 1.1 * ori;
            double op1 = OptionPrice()[0];
            Rate = 0.9 * ori;
            double op2 = OptionPrice()[0];
            Rate = ori;
            double rho = (op1 - op2) / (0.2 * Rate);
            return rho;
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
        public static double BSDelta(double S, double K, double Rate, double Sigma, double dt, bool TYPE)
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
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * y);
        }
        public int core_num()
        {
            int core;
            if (multithreading)
                core = System.Environment.ProcessorCount;
            else
                core = 1;
            return core;
        }
    }
}
