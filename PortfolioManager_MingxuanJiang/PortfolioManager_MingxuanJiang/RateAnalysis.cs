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
    public partial class RateAnalysis : Form
    {
        public RateAnalysis()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            //exit
            this.Dispose();
        }

        private void RateAnalysis_Load(object sender, EventArgs e)
        {
            //refresh database
            var query = from i in Program.PMC.InterestRates select i;
            List<InterestRate> Rate = new List<InterestRate>();
            foreach (var i in query)
                Rate.Add(i);
            dataGridView1.DataSource = Rate;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            //delete selected rows and then refresh
            foreach(DataGridViewRow k in dataGridView1.SelectedRows)
            {
                Int32 inter = Convert.ToInt32(k.Cells[0].Value);
                Program.PMC.InterestRates.Remove((from j in Program.PMC.InterestRates where j.Id == inter select j).FirstOrDefault());
                Program.PMC.SaveChanges();
                var query = from i in Program.PMC.InterestRates select i;
                List<InterestRate> Rate = new List<InterestRate>();
                foreach (var i in query)
                    Rate.Add(i);
                dataGridView1.DataSource = Rate;
                dataGridView1.Columns[0].Visible = false;
            }
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
