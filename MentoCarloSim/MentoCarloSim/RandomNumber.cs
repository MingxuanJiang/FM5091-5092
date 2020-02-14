using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoCarloSim
{
    class RandomNumber
    {
        //Set random numbers
        static int GetRandomSeed()//Let random numbers don't match with each other
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        static double BoxMuller()//Box-Muller transform
        {
            //randn1 and randn2 are 2 uniform random values
            //they between 0 and 1
            double randn1, randn2;
            Random rnd1 = new Random(GetRandomSeed());
            Random rnd2 = new Random(GetRandomSeed());
            randn1 = rnd1.NextDouble();
            randn2 = rnd2.NextDouble();
            //use the two equations
            double z1 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Cos(2 * Math.PI * randn2);
            //double z2 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Sin(2 * Math.PI * randn2);
            return z1;
        }
        //RN store the random numbers
        public double[,] RN(int Sims, int Steps)
        {
            double[,] randomnumber = new double[Sims, Steps];
            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    randomnumber[i, j] = BoxMuller();
                }
            }
            return randomnumber;
        }
    }
}
