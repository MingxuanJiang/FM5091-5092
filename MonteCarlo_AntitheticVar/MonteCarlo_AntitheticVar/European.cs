using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo_AntitheticVar
{
    class European : Option
    {
        //First, calculate the option price
        public override double[] OptionPrice(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool Type, double[,] Rn)
        {
            //sum1 and sum2 means the sum of the pair of optionprice
            double sum1 = 0;
            double sum2 = 0;
            double[] result = new double[2];
            if(Ant == true)
            {
                //allsims store the price of each step
                double[,] allsims = new double[2*Sims, Steps + 1];
                //calculate the option price step by step
                for (int i = 0; i < Sims; i++)
                {
                    //let the first column be S
                    allsims[i, 0] = S;
                    allsims[i+Sims,0] = S;
                    for (int j = 0; j < Steps; j++){
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                        allsims[i+Sims,j+1] = allsims[i+Sims, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) - Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                    }
                }
                double[] value = new double[2*Sims];
                if (Type == true)//call
                {
                    for (int i = 0; i < Sims; i++)
                        {
                        value[i] = Math.Max(allsims[i, Steps] - K, 0);
                        value[i+Sims] = Math.Max(allsims[i+Sims, Steps] - K, 0);
                        sum1 += value[i];
                        sum2 += value[i+Sims];
                        }
                }
                else//put
                {
                    for (int i = 0; i < Sims; i++)
                        {
                        value[i] = Math.Max(K - allsims[i, Steps], 0);
                        value[i+Sims] = Math.Max(K - allsims[i+Sims, Steps], 0);
                        sum1 += value[i];
                        sum2 += value[i+Sims];
                        }
                }
                //calculate option price
                double optionprice = sum1/Sims * Math.Exp(-Rate * Tenor);
                double[] C = new double[Sims];
                for (int i = 0; i < Sims; i++)
                    C[i] = (value[i] * Math.Exp(-Rate * Tenor)+value[i+Sims] * Math.Exp(-Rate * Tenor))/2;
                double stderror = Math.Sqrt(Option.deviation(C,Sims)/Sims);
                //store the result into matrix result
                result[0] = optionprice;
                result[1] = stderror;
            }
            else{
                //allsims store the price of each step
                double[,] allsims = new double[Sims, Steps + 1];
                //calculate the option price step by step
                for (int i = 0; i < Sims; i++)
                {
                    //let the first column be S
                    allsims[i, 0] = S;
                    for (int j = 0; j < Steps; j++)
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                }
                double[] C = new double[Sims];
                if (Type == true)//call
                {
                    for (int i = 0; i < Sims; i++)
                        C[i] = Math.Max(allsims[i, Steps] - K, 0)* Math.Exp(-Rate * Tenor);
                }
                else//put
                {
                    for (int i = 0; i < Sims; i++)
                        C[i] = Math.Max(K - allsims[i, Steps], 0)* Math.Exp(-Rate * Tenor);
                }
                //calculate option price
                double optionprice = C.Average();
                double stderror = Math.Sqrt(Option.deviation(C, Sims) / Sims);
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
            double delta = (OptionPrice(1.001 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - OptionPrice(0.999 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.002 * S);
            return delta;
        }
        //Gamma
        public override double Gamma(double[,] Rn)
        {
            double gamma = (OptionPrice(1.001 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - 2 * OptionPrice(S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] + OptionPrice(0.999 * S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (Math.Pow((0.001 * S), 2));
            return gamma;
        }
        //Vega
        public override double Vega(double[,] Rn)
        {
            double vega = (OptionPrice(S, K, Rate, 1.1 * Sigma, Tenor, Sims, Steps, Type, Rn)[0] - OptionPrice(S, K, Rate, 0.9 * Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.2 * Sigma);
            return vega;
        }
        //Theta
        public override double Theta(double[,] Rn)
        {
            double theta = (-1)*(OptionPrice(S, K, Rate, Sigma, 1.1 * Tenor, Sims, Steps, Type, Rn)[0] - OptionPrice(S, K, Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.1 * Tenor);
            return theta;
        }
        //Rho
        public override double Rho(double[,] Rn)
        {
            double rho = (OptionPrice(S, K, 1.1 * Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0] - OptionPrice(S, K, 0.9 * Rate, Sigma, Tenor, Sims, Steps, Type, Rn)[0]) / (0.2 * Rate);
            return rho;
        }
    }
}
