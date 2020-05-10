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
    public partial class NewTrade : Form
    {
        public NewTrade()
        {
            InitializeComponent();
            RefershInstrument();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            //if missing data
            if (textBox_Quantity.Text == String.Empty || textBox_Price.Text == String.Empty
                || comboBox_Instrument.Text == String.Empty)
                MessageBox.Show("Missing input.");
            else
            {
                Instrument instrument = (from i in Program.PMC.Instruments where i.Ticker == comboBox_Instrument.Text select i).FirstOrDefault();
                Program.PMC.Trades.Add(new Trade()
                {
                    IsBuy = radioButton_Buy.Checked,
                    Quantity = Convert.ToDouble(textBox_Quantity.Text),
                    Price = Convert.ToDouble(textBox_Price.Text),
                    Timestamp = DateTime.Now,
                    Instrument = instrument
                });
                Program.PMC.SaveChanges();
                MessageBox.Show("Add successfully!");
                this.Dispose();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        //refresh
        private void RefershInstrument()
        {
            comboBox_Instrument.Items.Clear();
            foreach (Instrument i in Program.PMC.Instruments)
                comboBox_Instrument.Items.Add(i.Ticker);
        }

        private void textBox_Quantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
