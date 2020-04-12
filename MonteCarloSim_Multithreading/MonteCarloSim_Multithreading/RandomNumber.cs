using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonteCarloSim_Multithreading
{
    class RandomNumber
    {
        private int trials, steps; private bool ant;
        //Sims means the trials of Matro Carlo Simulations
        public int Sims { get { return trials; } set { trials = value; } }
        //Steps means the steps to calculate the option
        public int Steps { get { return steps; } set { steps = value; } }
        //ant means whether use Ant Var reduction or not
        public bool Ant { get { return ant; } set { ant = value; } }
        //Set random numbers
        static int GetRandomSeed()//Let random numbers don't match with each other
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        //RN store the random numbers
        public double[,] RN()//Polar Rejection
        {
            //randn1 and randn2 are 2 uniform random values
            //they between 0 and 1
            double randn1, randn2;
            Random rnd1 = new Random(GetRandomSeed());
            Random rnd2 = new Random(GetRandomSeed());
            double w;
            double[,] result = new double[Sims, Steps];
            for (int i = 0; i < Sims; i++)
            {
                for (int j = 0; j < Steps; j++)
                {
                    //repeat until w > 1
                    do
                    {
                        randn1 = 2 * rnd1.NextDouble() - 1;
                        randn2 = 2 * rnd2.NextDouble() - 1;
                        w = randn1 * randn1 + randn2 * randn2;
                    } while (w > 1);
                    //use the equations to calculate z1 and z2
                    double c = Math.Sqrt(-2 * Math.Log(w) / w);
                    result[i, j] = c * randn1;
                }
            }
            return result;
        }
        public double[,] RNMT()
        {
            double[,] result = new double[Sims, Steps];
            int cores_num = System.Environment.ProcessorCount;
            int each_task = Sims / cores_num;
            //multithreading
            Action<object> Multi = (multi) =>
            {
                int tasks = Convert.ToInt32(multi) + each_task;
                Random rnd1 = new Random(GetRandomSeed());
                Random rnd2 = new Random(GetRandomSeed());
                for (int i = Convert.ToInt32(multi); i < tasks; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        //randn1 and randn2 are 2 uniform random values
                        //they between 0 and 1
                        double randn1, randn2;
                        double w;
                        //repeat until w > 1
                        do
                        {
                            randn1 = 2 * rnd1.NextDouble() - 1;
                            randn2 = 2 * rnd2.NextDouble() - 1;
                            w = randn1 * randn1 + randn2 * randn2;
                        } while (w > 1);
                        //use the equations to calculate z1 and z2
                        double c = Math.Sqrt(-2 * Math.Log(w) / w);
                        result[i, j] = c * randn1;
                    }
                }
            };
            int iter = 0;
            List<Thread> thread = new List<Thread>();
            for (int i = 0; i < cores_num; i++)
            {
                Thread new_thread = new Thread(new ParameterizedThreadStart(Multi));
                thread.Add(new_thread);
                new_thread.Start(iter);
                iter = iter + each_task;
            }
            foreach (Thread i in thread)
                i.Join();
            foreach (Thread i in thread)
                i.Abort();                       
            return result;
        }
    }
}
