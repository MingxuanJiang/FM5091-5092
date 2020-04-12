using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MonteCarloSim_Multithreading
{
    class Allsims
    {
        public double[,] allsims_calculate(double S, double K, double Rate, double Sigma, double Tenor, int Sims, int Steps, bool TYPE, bool Ant, bool CV, bool Multithreading, double[,] Rn)
        {
            // count the number of cores
            int cores_num;
            if (Multithreading)
                cores_num = System.Environment.ProcessorCount;
            else
                cores_num = 1;
            int each_task;
            // sepearate tasks for each core
            if (Sims % cores_num == 0)
                each_task = Sims / cores_num;
            else
                each_task = Sims / cores_num + 1;

            //allsims store the price of each step
            double[,] allsims;
            if (Ant)
                allsims = new double[2 * Sims, Steps + 1];
            else
                allsims = new double[Sims, Steps + 1];
            //let the first column be S
            for (int i = 0; i < allsims.GetLength(0); i++)
                allsims[i, 0] = S;

            List<Thread> thread = new List<Thread>();
            Action<Object> Multi = (multi) =>
            {
                int tasks = Convert.ToInt32(multi) + each_task;
                // in last core, if the number of tasks is small, suppose it do the left tasks
                if (tasks > Sims)
                    tasks = Sims;

                //calculate the option price step by step
                for (int i = Convert.ToInt32(multi); i < tasks; i++)
                {
                    for (int j = 0; j < Steps; j++)
                    {
                        allsims[i, j + 1] = allsims[i, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) + Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                        if (Ant)
                            allsims[i + Sims, j + 1] = allsims[i + Sims, j] * Math.Exp((Rate - Sigma * Sigma / 2) * (Tenor / Steps) - Sigma * Math.Sqrt(Tenor / Steps) * Rn[i, j]);
                    }
                }
            };
            int iter = 0;
            for(int i = 0; i < cores_num; i++)
            {
                thread.Add(new Thread(new ParameterizedThreadStart(Multi)));
                thread[i].Start(iter);
                iter = iter + each_task;
            }
            foreach (Thread i in thread)
                i.Join();
            return allsims;
        }
    }
}
