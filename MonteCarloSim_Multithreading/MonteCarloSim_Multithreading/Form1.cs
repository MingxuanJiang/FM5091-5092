using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MonteCarloSim_Multithreading
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Button_Go_Click(object sender, EventArgs e)
        {
            if (TextBox_S.Text == String.Empty || TextBox_K.Text == String.Empty || TextBox_r.Text == String.Empty || TextBox_Sigma.Text == String.Empty || TextBox_T.Text == String.Empty || TextBox_Sims.Text == String.Empty || TextBox_Steps.Text == String.Empty)
                label_bar.Text = "Missing some inputs";
            else
            {
                // Initialize time
                Stopwatch watch = new Stopwatch();
                watch.Reset();
                watch.Start();

                CalculateData();
                watch.Stop();
                TextBox_Time.Text = watch.Elapsed.Hours.ToString() + ":" + watch.Elapsed.Minutes.ToString() + ":" + watch.Elapsed.Seconds.ToString() + ":" + watch.Elapsed.Milliseconds.ToString();
            }                       
        }
        public void inprogress(int i)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<int>(inprogress), new object[] {i});
                return;
            }
            progressBar.Value = i;
        }
        private void CalculateData()
        {
            //read data: S,K,r,Sigma,T,Trials,steps
            label_bar.Text = "Reading data";
            inprogress(10);
            //S means underlying
            double S = Convert.ToDouble(TextBox_S.Text);
            //K means strike price
            double K = Convert.ToDouble(TextBox_K.Text);
            //r means the interest rate
            double r = Convert.ToDouble(TextBox_r.Text);
            //Sigma means volatility
            double Sigma = Convert.ToDouble(TextBox_Sigma.Text);
            //T means tenor
            double T = Convert.ToDouble(TextBox_T.Text);
            //Trials means the trials of Mento Carlo Simulations
            int Trials = Convert.ToInt32(TextBox_Sims.Text);
            //steps means the steps to calculate the option price
            int steps = Convert.ToInt32(TextBox_Steps.Text);
            bool Type = Convert.ToBoolean(Radio_Call.Checked);
            bool AntVar = Convert.ToBoolean(checkbox_AntVar.Checked);
            bool CV = Convert.ToBoolean(checkbox_CV.Checked);
            bool Multithreading = Convert.ToBoolean(checkBox_MT.Checked);
            //store the data
            Option Euroption = new European(S, K, r, Sigma, T, Trials, steps, Type, AntVar, CV, Multithreading);
            //option price
            label_bar.Text = "Calculating Price";
            inprogress(30);
            TextBox_Price.Text = Convert.ToString(Euroption.OptionPrice()[0]);
            //delta
            label_bar.Text = "Calculating Delta";
            inprogress(40);
            TextBox_Delta.Text = Convert.ToString(Euroption.Delta());
            //gamma
            label_bar.Text = "Calculating Gamma";
            inprogress(50);
            TextBox_Gamma.Text = Convert.ToString(Euroption.Gamma());
            //vega
            label_bar.Text = "Calculating Vega";
            inprogress(60);
            TextBox_Vega.Text = Convert.ToString(Euroption.Vega());
            //theta
            label_bar.Text = "Calculating Theta";
            inprogress(70);
            TextBox_Theta.Text = Convert.ToString(Euroption.Theta());
            //rho
            label_bar.Text = "Calculating Rho";
            inprogress(80);
            TextBox_Rho.Text = Convert.ToString(Euroption.Rho());
            //standard error
            label_bar.Text = "Calculating Standard Error";
            inprogress(90);
            TextBox_Std.Text = Convert.ToString(Euroption.OptionPrice()[1]);
            TextBox_Cores.Text = Convert.ToString(Euroption.core_num());
            label_bar.Text = "Done.";
            inprogress(100);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_S_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_S.Text, out num))
                errorProvider1.SetError(TextBox_S, "Please enter a number!");
            else
                errorProvider1.SetError(TextBox_S, string.Empty);
            // print error
            try
            {
                double a = Convert.ToDouble(TextBox_S.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_K_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_K.Text, out num))
                errorProvider2.SetError(TextBox_K, "Please enter a number!");
            else
                errorProvider2.SetError(TextBox_K, string.Empty);
            // print error
            try
            {
                double a = Convert.ToDouble(TextBox_K.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_r_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_r.Text, out num))
                errorProvider3.SetError(TextBox_r, "Please enter a number!");
            else
                errorProvider3.SetError(TextBox_r, string.Empty);
            // print error
            try
            {
                double a = Convert.ToDouble(TextBox_r.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_Sigma_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_Sigma.Text, out num))
                errorProvider4.SetError(TextBox_Sigma, "Please enter a number!");
            else
                errorProvider4.SetError(TextBox_Sigma, string.Empty);
            // print error
            try
            {
                double a = Convert.ToDouble(TextBox_Sigma.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_T_TextChanged(object sender, EventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_T.Text, out num))
                errorProvider5.SetError(TextBox_T, "Please enter a number!");
            else
                errorProvider5.SetError(TextBox_T, string.Empty);
            // print error
            try
            {
                double a = Convert.ToDouble(TextBox_T.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_Sims_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(TextBox_Sims.Text, out num))
                errorProvider6.SetError(TextBox_Sims, "Please enter a number!");
            else
                errorProvider6.SetError(TextBox_Sims, string.Empty);
            // print error
            try
            {
                int a = Convert.ToInt32(TextBox_Sims.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void TextBox_Steps_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (!int.TryParse(TextBox_Steps.Text, out num))
                errorProvider7.SetError(TextBox_Steps, "Please enter a number!");
            else
                errorProvider7.SetError(TextBox_Steps, string.Empty);
            // print error
            try
            {
                int a = Convert.ToInt32(TextBox_Steps.Text);
            }
            catch
            {
                MessageBox.Show("Error: Not A Valid Number!");
            }
        }

        private void Button_Sample_Click(object sender, EventArgs e)
        {
            TextBox_S.Text = Convert.ToString(50);
            TextBox_K.Text = Convert.ToString(50);
            TextBox_r.Text = Convert.ToString(0.05);
            TextBox_Sigma.Text = Convert.ToString(0.5);
            TextBox_T.Text = Convert.ToString(1);
            TextBox_Sims.Text = Convert.ToString(10000);
            TextBox_Steps.Text = Convert.ToString(10);
        }
    }
}
