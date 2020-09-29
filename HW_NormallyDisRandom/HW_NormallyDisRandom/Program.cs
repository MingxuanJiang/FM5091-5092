using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_NormallyDisRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Random number of the First Method (add together):");//add together
            double[] addtogether = { Addtogether(), Addtogether() };
            Console.WriteLine(addtogether[0]);//random number
            Console.WriteLine(addtogether[1]);//random number
            double[] result1 = { };//put 6000 random number into array result1
            int z = 0;
            // add new random number into list k1
            // add 6000 times
            while (z < 6000)
            {
                List<double> k1 = result1.ToList();
                k1.Add(Addtogether());
                // convert list k1 into array result1
                result1 = k1.ToArray();
                //result1 have all random numbers
                z++;
            }
            //count means the probability of smaller than -1 and larger than 1
            double count = 0;
            for (int i = 0; i < 6000; i++)
            {
                if (result1[i] > 1)
                {
                    count++;
                }
                else if (result1[i] < -1)
                {
                    count++;
                }
            }
            count = 100 * count / result1.Length;
            Console.WriteLine("the Probability of the abs larger than 1: " + count + "%");
            double[] meanvarresult1 = MeanVar(result1);//meanvarresult1 includes mean and var
            Console.WriteLine("Mean(should be 0): " + meanvarresult1[0]);
            Console.WriteLine("Variance(should be 1): " + meanvarresult1[1]);

            Console.WriteLine("Random number of the Second Method (Box-Muller Transform):");//Box-Muller Transform
            double[] boxmuller = BoxMuller();
            Console.WriteLine(boxmuller[0]);//random number
            Console.WriteLine(boxmuller[1]);//random number
            double[] result2 = { };//put 6000 random number into array result2
            z = 0;
            //add new random number into list k2
            while (z < 6000)
            {
                List<double> k2 = result2.ToList();
                double[] boxmuller1 = BoxMuller();//put each random number into array boxmuller1
                k2.Add(boxmuller1[0]);
                k2.Add(boxmuller1[1]);
                //convert list k2 into array result2
                result2 = k2.ToArray();
                //result2 have all random numbers
                z = z + 2;
            }
            //count means the probability of smaller than -1 and larger than 1
            count = 0;
            for (int i = 0; i < 6000; i++)
            {
                if (result2[i] > 1)
                {
                    count++;
                }
                else if (result2[i] < -1)
                {
                    count++;
                }
            }
            count = 100 * count / result2.Length;
            Console.WriteLine("the Probability of the abs larger than 1: " + count + "%");
            double[] meanvarresult2 = MeanVar(result2);//meanvarresult2 includes mean and var
            Console.WriteLine("Mean(should be 0): " + meanvarresult2[0]);
            Console.WriteLine("Variance(should be 1): " + meanvarresult2[1]);

            Console.WriteLine("Random number of the Third Method (Polar Rejection):");//Polar Rejection
            double[] polar = Polar();
            Console.WriteLine(polar[0]);//random number
            Console.WriteLine(polar[1]);//random number
            double[] result3 = { };//put 6000 random number into array result3
            z = 0;
            //add new random number into list k3
            while (z < 6000)
            {
                List<double> k3 = result3.ToList();
                double[] polar1 = Polar();//put each random number into array polar1
                k3.Add(polar1[0]);
                k3.Add(polar1[1]);
                //convert list k3 into array result3
                result3 = k3.ToArray();
                //result3 have all random numbers
                z = z + 2;
            }
            //count means the probability of smaller than -1 and larger than 1
            count = 0;
            for (int i = 0; i < 6000; i++)
            {
                if (result3[i] > 1)
                {
                    count++;
                }
                else if (result3[i] < -1)
                {
                    count++;
                }
            }
            count = 100 * count / result3.Length;
            Console.WriteLine("the Probability of the abs larger than 1: " + count + "%");
            double[] meanvarresult3 = MeanVar(result3);//meanvarresult3 includes mean and var
            Console.WriteLine("Mean(should be 0): " + meanvarresult3[0]);
            Console.WriteLine("Variance(should be 1): " + meanvarresult3[1]);

            Console.WriteLine("Enter a number(rho) (between -1 and 1):");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Joint Normally Distributed:");
            Console.WriteLine("First Method:");
            double[] joint1 = Joint(a, addtogether[0], addtogether[1]);//joint includes each joint normally distributed results
            Console.WriteLine(joint1[0]);
            Console.WriteLine(joint1[1]);
            Console.WriteLine("Second Method:");
            double[] joint2 = Joint(a, boxmuller[0], boxmuller[1]);//joint includes each joint normally distributed results
            Console.WriteLine(joint2[0]);
            Console.WriteLine(joint2[1]);
            Console.WriteLine("Third Method:");
            double[] joint3 = Joint(a, polar[0], polar[1]);//joint includes each joint normally distributed results
            Console.WriteLine(joint3[0]);
            Console.WriteLine(joint3[1]);
            Console.ReadLine();
        }
        static int GetRandomSeed()//Let random numbers don't match with each other
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        static double Addtogether()//first method
        {
            //randn is an unifrom random number
            //randn is between 0 and 1
            double randn;
            Random rnd = new Random(GetRandomSeed());
            double result = 0;
            //add 12 randns together
            for (int i = 0; i < 12; i++)
            {
                randn = rnd.NextDouble();
                result += randn;
            }
            //subtract six
            result = result - 6;
            return result;
        }
        static double[] BoxMuller()//second method --Box-Muller transform
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
            double z2 = Math.Sqrt(-2.0 * Math.Log(randn1)) * Math.Sin(2 * Math.PI * randn2);
            double[] z = { z1, z2 };
            return z;
        }
        static double[] Polar()//third method -- Polar Rejection
        {
            //randn1 and randn2 are 2 uniform random values
            //they between 0 and 1
            double randn1, randn2, u1, u2;
            Random rnd1 = new Random(GetRandomSeed());
            Random rnd2 = new Random(GetRandomSeed());
            double w;
            //repeat until w > 1
            do
            {
                u1 = rnd1.NextDouble();
                u2 = rnd2.NextDouble();
                randn1 = 2 * u1 - 1;
                randn2 = 2 * u2 - 1;
                w = randn1 * randn1 + randn2 * randn2;
            } while (w > 1);
            //use the equations to calculate z1 and z2
            double c = Math.Sqrt(-2 * Math.Log(w) / w);
            double z1 = c * randn1;
            double z2 = c * randn2;
            double[] z = { z1, z2 };
            return z;
        }
        static double[] Joint(double a, double epsilon1, double epsilon2)//joint normally distributed
        {
            //input a
            //a is a correlation value between -1 and 1
            //epsilon is a normal random value
            //use the three methods above to calculate the epsilon
            //use the formula to calculate z1 and z2
            double z1 = epsilon1;
            double z2 = a * epsilon1 + Math.Sqrt(1 - a * a) * epsilon2;
            double[] result = { z1, z2 };
            return result;
        }
        static double[] MeanVar(double[] result)// calculate mean and variance
        {
            double total = 0;// total means the sum of all random numbers in array result
            for (int i = 0; i < result.Length; i++)
            {
                total += result[i];
            }
            double average = total / result.Length;
            double fto = 0;//fto means the variance of all random numbers in array result
            for (int i = 0; i < result.Length; i++)
                fto += Math.Pow((average - result[i]), 2);
            double equation = fto / result.Length;
            double[] turnout = { average, equation };
            return turnout;//mean and variance should be 0 and 1
        }
    }
}
