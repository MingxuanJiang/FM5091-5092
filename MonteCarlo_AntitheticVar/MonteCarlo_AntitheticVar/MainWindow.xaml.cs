using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonteCarlo_AntitheticVar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //read data: S,K,r,Sigma,T,Trials,steps
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
            European Euroption = new European();
            //store the data
            Euroption.S = S;
            Euroption.K = K;
            Euroption.Rate = r;
            Euroption.Sigma = Sigma;
            Euroption.Tenor = T;
            Euroption.Sims = Trials;
            Euroption.Steps = steps;
            //set the type (including call and put)
            if (Radio_Call.IsChecked == true)
                Euroption.Type = true;
            else
                Euroption.Type = false;
            //set the ant
            if (checkbox_AntVar.IsChecked == true)
                Euroption.Ant = true;
            else
                Euroption.Ant = false;
            //set matrix rn to store random numbers
            RandomNumber rn = new RandomNumber();
            rn.Sims = Trials;
            rn.Steps = steps;
            double[,] RandomNumber = rn.RN();
            //option price
            TextBox_Price.Text = Convert.ToString(Euroption.OptionPrice(S, K, r, Sigma, T, Trials, steps, Euroption.Type, RandomNumber)[0]);
            //delta
            TextBox_Delta.Text = Convert.ToString(Euroption.Delta(RandomNumber));
            //gamma
            TextBox_Gamma.Text = Convert.ToString(Euroption.Gamma(RandomNumber));
            //vega
            TextBox_Vega.Text = Convert.ToString(Euroption.Vega(RandomNumber));
            //theta
            TextBox_Theta.Text = Convert.ToString(Euroption.Theta(RandomNumber));
            //rho
            TextBox_Rho.Text = Convert.ToString(Euroption.Rho(RandomNumber));
            //standard error
            TextBox_Std.Text = Convert.ToString(Euroption.OptionPrice(S, K, r, Sigma, T, Trials, steps, Euroption.Type, RandomNumber)[1]);
        }
        //error point: change background color
        private void TextBox_S_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_S.Text, out num))
                TextBox_S.Background = Brushes.Pink;
            else
                TextBox_S.Background = Brushes.White;
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

        //error point: change background color
        private void TextBox_K_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_K.Text, out num))
                TextBox_K.Background = Brushes.Pink;
            else
                TextBox_K.Background = Brushes.White;
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
        //error point: change background color
        private void TextBox_r_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_r.Text, out num))
                TextBox_r.Background = Brushes.Pink;
            else
                TextBox_r.Background = Brushes.White;
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
        //error point: change background color
        private void TextBox_Sigma_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_Sigma.Text, out num))
                TextBox_Sigma.Background = Brushes.Pink;
            else
                TextBox_Sigma.Background = Brushes.White;
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
        //error point: change background color
        private void TextBox_T_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;
            if (!double.TryParse(TextBox_T.Text, out num))
                TextBox_T.Background = Brushes.Pink;
            else
                TextBox_T.Background = Brushes.White;
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
        //error point: change background color
        private void TextBox_Sims_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num;
            if (!int.TryParse(TextBox_Sims.Text, out num))
                TextBox_Sims.Background = Brushes.Pink;
            else
                TextBox_Sims.Background = Brushes.White;
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
        //error point: change background color
        private void TextBox_Steps_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num;
            if (!int.TryParse(TextBox_Steps.Text, out num))
                TextBox_Steps.Background = Brushes.Pink;
            else
                TextBox_Steps.Background = Brushes.White;
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

        private void Botton_Sample_Click(object sender, RoutedEventArgs e)
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
