using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfolioManager_MingxuanJiang
{
    public partial class NewInterestRate : Form
    {
        public NewInterestRate()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            double tenor = Convert.ToDouble(textBox_Tenor.Text);
            if (textBox_Tenor.Text == String.Empty || textBox_Rate.Text == String.Empty)
                MessageBox.Show("Missing input.");
            else
            {
                if ((from i in Program.PMC.InterestRates where i.Tenor == tenor select i).Count() != 0)
                    MessageBox.Show("Already exist the tenor.");
                //add tenor and rate
                else 
                {
                    Program.PMC.InterestRates.Add(new InterestRate()
                    {
                        Tenor = Convert.ToDouble(textBox_Tenor.Text),
                        Rate = Convert.ToDouble(textBox_Rate.Text)
                    });
                    Program.PMC.SaveChanges();
                    MessageBox.Show("Add successfully!");
                }
            }
            this.Dispose();
        }
    }
}
