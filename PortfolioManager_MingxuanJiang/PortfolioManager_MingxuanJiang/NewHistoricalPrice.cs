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
    public partial class NewHistoricalPrice : Form
    {
        public NewHistoricalPrice()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NewHistoricalPrice_Load(object sender, EventArgs e)
        {
            var query = from i in Program.PMC.Instruments where i.InstType.TypeName == "Stock" select i.Ticker;
            //load ticker
            List<string> ticker = new List<string>();
            foreach (var i in query)
                ticker.Add(i);
            comboBox_Product.DisplayMember = ticker[0];
            comboBox_Product.DataSource = ticker;
            dateTimePicker_Date.Value = System.DateTime.Today;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_ClosingPrice.Text == String.Empty || comboBox_Product.Text == String.Empty)
                MessageBox.Show("Missing data.");
            else
            {
                Program.PMC.Prices.Add(new Price()
                {
                    InstrumentId = (from i in Program.PMC.Instruments where i.Ticker == comboBox_Product.Text select i.Id).FirstOrDefault(),
                    Date = dateTimePicker_Date.Value,
                    ClosingPrice = Convert.ToDouble(textBox_ClosingPrice.Text)                    
                });
                Program.PMC.SaveChanges();
                MessageBox.Show("Add successfully!");
            }
        }

        private void comboBox_Product_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ClosingPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
