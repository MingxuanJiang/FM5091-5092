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
    public partial class HisPriceAnalysis : Form
    {
        public HisPriceAnalysis()
        {
            InitializeComponent();
        }

        private void HisPriceAnalysis_Load(object sender, EventArgs e)
        {
            //load data from SQL
            var query = from i in Program.PMC.Instruments join j in Program.PMC.InstTypes on i.InstTypeId equals j.Id where j.TypeName == "Stock" select i.Ticker;
            List<string> ticker = new List<string>();
            foreach (var i in query)
                ticker.Add(i);
            comboBox_Instrument.DisplayMember = ticker[0];
            comboBox_Instrument.DataSource = ticker;
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.Prices where i.Instrument.Ticker == comboBox_Instrument.Text select i;
            foreach (Price price in Query)
                dataGridView1.Rows.Add(price.Date.ToShortDateString(), price.ClosingPrice);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_Instrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.Prices where i.Instrument.Ticker == comboBox_Instrument.Text select i;
            foreach (Price price in Query)
                dataGridView1.Rows.Add(price.Date.ToShortDateString(), price.ClosingPrice);
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            foreach(DataGridViewRow i in dataGridView1.SelectedRows)
            {
                DateTime newdata = new DateTime();
                newdata = Convert.ToDateTime(i.Cells[0].Value);
                Program.PMC.Prices.Remove((from j in Program.PMC.Prices where j.Date == newdata select j).FirstOrDefault());
            }
            Program.PMC.SaveChanges();
            //refresh
            dataGridView1.Rows.Clear();
            var Query = from i in Program.PMC.Prices where i.Instrument.Ticker == comboBox_Instrument.Text select i;
            foreach (Price price in Query)
                dataGridView1.Rows.Add(price.Date.ToShortDateString(), price.ClosingPrice);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
