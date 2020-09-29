using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_TrinomialTree
{
    class GreekValues
    {
        //C is option prices
        //S is underlying values
        //delta
        public static double delta(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
        {
            double[,] underlyvalues = GetValues.UnderlyingValues.underlyingvalues(S0, K, vol, T, N, r, del, type, optiontype);
            double[,] optionprice = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r, del, type, optiontype);
            int i = 1;
            int j = N;//use the result of one step
            double delta = (optionprice[i, j + 1] - optionprice[i, j - 1]) / (underlyvalues[i, j + 1] - underlyvalues[i, j - 1]);
            return delta;
        }
        //gamma
        public static double gamma(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
        {
            double[,] underlyvalues = GetValues.UnderlyingValues.underlyingvalues(S0, K, vol, T, N, r, del, type, optiontype);
            double[,] optionprice = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r, del, type, optiontype);
            int i = 1;
            int j = N;//use the result of one step
            double gamma = ((optionprice[i, j + 1] - optionprice[i, j]) / (underlyvalues[i, j + 1] - underlyvalues[i, j]) - (optionprice[i, j] - optionprice[i, j - 1]) / (underlyvalues[i, j] - underlyvalues[i, j - 1])) / ((underlyvalues[i, j + 1] - underlyvalues[i, j - 1]) / 2);
            return gamma;
        }
        //vega
        public static double vega(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype, double dvol)
        {
            double[,] optionprice1 = GetValues.OptionPrice.optionprice(S0, K, vol + dvol, T, N, r, del, type, optiontype);
            double[,] optionprice2 = GetValues.OptionPrice.optionprice(S0, K, vol - dvol, T, N, r, del, type, optiontype);
            double vega = ((optionprice1[0, N] - optionprice2[0, N]) / (2 * dvol));//use the result of one step
            return vega;
        }
        //theta
        public static double theta(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype)
        {
            double[,] optionprice = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r, del, type, optiontype);
            int i = 1;//use the result of one step
            int j = N;
            double dt = T / N;//delta t
            double theta = (optionprice[i, j] - optionprice[i - 1, j]) / (dt);
            return theta;
        }
        //rho
        public static double rho(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype, double dr)
        {
            double[,] optionprice1 = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r + dr, del, type, optiontype);
            double[,] optionprice2 = GetValues.OptionPrice.optionprice(S0, K, vol, T, N, r - dr, del, type, optiontype);
            double rho = (optionprice1[0, N] - optionprice2[0, N]) / (2 * dr);//use the result of one step
            return rho;
        }
        //output all greek values
        public static double[] output(double S0, double K, double vol, double T, int N, double r, double del, bool type, bool optiontype, double dvol, double dr)
        {
            double delta = GreekValues.delta(S0, K, vol, T, N, r, del, type, optiontype);
            double gamma = GreekValues.gamma(S0, K, vol, T, N, r, del, type, optiontype);
            double vega = GreekValues.vega(S0, K, vol, T, N, r, del, type, optiontype, dvol);
            double theta = GreekValues.theta(S0, K, vol, T, N, r, del, type, optiontype);
            double rho = GreekValues.rho(S0, K, vol, T, N, r, del, type, optiontype, dr);
            double[] result = { delta, gamma, vega, theta, rho };
            return result;
        }
    }
}
