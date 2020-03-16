using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloSim_CV
{
    class European : Option
    {
        public European(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool TYPE, bool Ant, bool CV)
            : base(S, K, Rate, Sigma, Tenor, Sims, Steps, TYPE, Ant, CV)
        {

        }


        //First, calculate the option price
        public override double[] OptionPrice(double[,] Rn)
        {
            //sum1 means the sum of the pair of optionprice
            double sum1 = 0;
            double optionprice = 0;// means option price
            double stderror = 0;
            double[] result = new double[2];
            //allsims store the price of each step
            if (Ant == true)//choose Ant Var
            {
                //allsims store the price of each step
                double[,] allsims = new double[2 * Sims, Steps + 1];
                //calculate the option price step by step
                for (int i = 0; i < Sims; i++)
                {
                    //let the first column be S
                    allsims[i, 0] = S;
                    allsims[i + Sims, 0] = S;
                    for (int j = 0; j < Steps; j++)
                    {
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                        allsims[i + Sims, j + 1] = allsims[i + Sims, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) - Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                    }
                }
                if (CV == true)//choose CV
                {
                    double[] CT = new double[2 * Sims];
                    for (int i = 0; i < 2 * Sims; i++)
                    {
                        double cv = 0;
                        for (int j = 0; j < Steps; j++)
                        {
                            double delta = BSDelta(allsims[i,j], K, Rate, Sigma, Tenor-j*Tenor/Steps, TYPE);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Rate * (Tenor / Steps)));
                        }
                        if (TYPE == true)
                        {
                            CT[i] = (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Rate * Tenor);
                        }
                        else
                        {
                            CT[i] = (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Rate * Tenor);
                        }
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(Option.deviation(CT, 2 * Sims) / (2 * Sims));
                }
                else//not choose CV
                {
                    double[] value = new double[2 * Sims];
                    if (TYPE == true)//call
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = Math.Max(allsims[i, Steps] - K, 0);
                            value[i + Sims] = Math.Max(allsims[i + Sims, Steps] - K, 0);
                            sum1 += value[i];
                        }
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = Math.Max(K - allsims[i, Steps], 0);
                            value[i + Sims] = Math.Max(K - allsims[i + Sims, Steps], 0);
                            sum1 += value[i];
                        }
                    }
                    //calculate option price
                    optionprice = sum1 / Sims * Math.Exp(-Rate * Tenor);
                    double[] C = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                        C[i] = (value[i] * Math.Exp(-Rate * Tenor) + value[i + Sims] * Math.Exp(-Rate * Tenor)) / 2;
                    stderror = Math.Sqrt(Option.deviation(C, Sims) / Sims);
                }
                //store the result into matrix result
                result[0] = optionprice;
                result[1] = stderror;
            }
            else//not choosing Ant Var
            {
                double[,] allsims = new double[Sims, Steps + 1];
                //calculate the option price step by step
                for (int i = 0; i < Sims; i++)
                {
                    //let the first column be S
                    allsims[i, 0] = S;
                    for (int j = 0; j < Steps; j++)
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                }
                if (CV == true)//choose CV
                {
                    double[] CT = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                    {
                        double cv = 0;
                        for (int j = 0; j < Steps; j++)
                        {
                            double delta = BSDelta(allsims[i, j], K, Rate, Sigma, Tenor-j*Tenor/Steps, TYPE);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Rate * (Tenor / Steps)));
                        }
                        if (TYPE == true)
                            CT[i] = (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Rate * Tenor);
                        else
                            CT[i] = (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Rate * Tenor);
                    }
                    optionprice = CT.Average();
                    stderror = Math.Sqrt(Option.deviation(CT, Sims) / Sims);
                }
                else//not choose CV
                {
                    double[] value = new double[Sims];
                    if (TYPE == true)//call
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = Math.Max(allsims[i, Steps] - K, 0) * Math.Exp(-Rate * Tenor);
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = Math.Max(K - allsims[i, Steps], 0) * Math.Exp(-Rate * Tenor);
                    }
                    //calculate option price
                    optionprice = value.Average();
                    stderror = Math.Sqrt(Option.deviation(value, Sims) / Sims);
                }
                //store the result into matrix result
                result[0] = optionprice;
                result[1] = stderror;
            }
            return result;
        }
        //Then, calculate the Greek values
        //Delta
        public override double Delta(double[,] Rn)
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice(Rn)[0];
            S = 0.999 * ori;
            double op2 = OptionPrice(Rn)[0];
            S = ori;
            double delta = (op1 - op2) / (0.002 * S);
            return delta;
        }
        //Gamma
        public override double Gamma(double[,] Rn)
        {
            double ori = S;
            S = 1.001 * ori;
            double op1 = OptionPrice(Rn)[0];
            S = ori;
            double op2 = OptionPrice(Rn)[0];
            S = 0.999 * ori;
            double op3 = OptionPrice(Rn)[0];
            S = ori;
            double gamma = (op1 - 2 * op2 + op3) / (Math.Pow((0.001 * ori), 2));
            return gamma;
        }
        //Vega
        public override double Vega(double[,] Rn)
        {
            double ori = Sigma;
            Sigma = 1.1 * ori;
            double op1 = OptionPrice(Rn)[0];
            Sigma = 0.9 * ori;
            double op2 = OptionPrice(Rn)[0];
            Sigma = ori;
            double vega = (op1 - op2) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public override double Theta(double[,] Rn)
        {
            double ori = Tenor;
            Tenor = 1.1 * ori;
            double op1 = OptionPrice(Rn)[0];
            Tenor = ori;
            double op2 = OptionPrice(Rn)[0];
            double theta = (-1) * (op1 - op2) / (0.1 * Tenor);
            return theta;
        }
        //Rho
        public override double Rho(double[,] Rn)
        {
            double ori = Rate;
            Rate = 1.1 * ori;
            double op1 = OptionPrice(Rn)[0];
            Rate = 0.9 * ori;
            double op2 = OptionPrice(Rn)[0];
            Rate = ori;
            double rho = (op1 - op2) / (0.2 * Rate);
            return rho;
        }
    }
}
