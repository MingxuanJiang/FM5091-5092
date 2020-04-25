using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonteCarloSim_ExoticOptions
{
    class Barrier : Option
    {
        public Barrier(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool TYPE, bool Ant, bool CV, bool Multithreading, double Rebate, double Barrier, int BarrierType)
            : base(S, K, Rate, Sigma, Tenor, Sims, Steps, TYPE, Ant, CV, Multithreading, Rebate, Barrier, BarrierType)
        {

        }
        //First, calculate the option price
        public override double[] OptionPrice()
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
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Rate, Sigma, Tenor, Sims, Steps, TYPE, Ant, CV, Multithreading, Rn);
                //Barrier types
                double[] barrier_payoff = new double[2 * Sims];
                for(int i = 0; i < 2 * Sims; i++)
                {
                    //Down and out
                    if (BarrierType == 0)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Up and out 
                    if (BarrierType == 1)                       
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Down and in
                    if (BarrierType == 2)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                    //Up and in
                    if (BarrierType == 3)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
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
                            double delta = BSDelta(allsims[i, j], K, Rate, Sigma, Tenor - j * Tenor / Steps, TYPE);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Rate * (Tenor / Steps)));
                        }
                        if (TYPE == true)
                        {
                            CT[i] = barrier_payoff[i] * (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Rate * Tenor);
                        }
                        else
                        {
                            CT[i] = barrier_payoff[i] * (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Rate * Tenor);
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
                            value[i] = barrier_payoff[i] * Math.Max(allsims[i, Steps] - K, 0);
                            value[i + Sims] = barrier_payoff[i] * Math.Max(allsims[i + Sims, Steps] - K, 0);
                            sum1 += value[i];
                        }
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                        {
                            value[i] = barrier_payoff[i] * Math.Max(K - allsims[i, Steps], 0);
                            value[i + Sims] = barrier_payoff[i] * Math.Max(K - allsims[i + Sims, Steps], 0);
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
                Allsims all = new Allsims();
                double[,] allsims;
                allsims = all.allsims_calculate(S, K, Rate, Sigma, Tenor, Sims, Steps, TYPE, Ant, CV, Multithreading, Rn);
                //Barrier types
                double[] barrier_payoff = new double[Sims];
                for (int i = 0; i < Sims; i++)
                {
                    //Down and out
                    if (BarrierType == 0)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Up and out 
                    if (BarrierType == 1)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 0;
                        else
                            barrier_payoff[i] = 1;
                    }
                    //Down and in
                    if (BarrierType == 2)
                    {
                        if (minnumber(allsims, i) <= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                    //Up and in
                    if (BarrierType == 3)
                    {
                        if (maxnumber(allsims, i) >= Barrier)
                            barrier_payoff[i] = 1;
                        else
                            barrier_payoff[i] = 0;
                    }
                }
                if (CV == true)//choose CV
                {
                    double[] CT = new double[Sims];
                    for (int i = 0; i < Sims; i++)
                    {
                        double cv = 0;
                        for (int j = 0; j < Steps; j++)
                        {
                            double delta = BSDelta(allsims[i, j], K, Rate, Sigma, Tenor - j * Tenor / Steps, TYPE);
                            cv += delta * (allsims[i, j + 1] - allsims[i, j] * Math.Exp(Rate * (Tenor / Steps)));
                        }
                        if (TYPE == true)
                            CT[i] = barrier_payoff[i] * (Math.Max(allsims[i, Steps] - K, 0) - cv) * Math.Exp(-Rate * Tenor);
                        else
                            CT[i] = barrier_payoff[i] * (Math.Max(K - allsims[i, Steps], 0) - cv) * Math.Exp(-Rate * Tenor);
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
                            value[i] = barrier_payoff[i] * Math.Max(allsims[i, Steps] - K, 0) * Math.Exp(-Rate * Tenor);
                    }
                    else//put
                    {
                        for (int i = 0; i < Sims; i++)
                            value[i] = barrier_payoff[i] * Math.Max(K - allsims[i, Steps], 0) * Math.Exp(-Rate * Tenor);
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
        //Getting the max number in each row
        static double maxnumber(double[,] matrix, int row_num)
        {
            double maximum = matrix[row_num, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
                maximum = Math.Max(maximum, matrix[row_num, j]);
            return maximum;
        }
        //Getting the min number in each row
        static double minnumber(double[,] matrix, int row_num)
        {
            double minimum = matrix[row_num, 0];
            for (int j = 0; j < matrix.GetLength(1); j++)
                minimum = Math.Min(minimum, matrix[row_num, j]);
            return minimum;
        }
    }
}
