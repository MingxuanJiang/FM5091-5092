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
    public partial class NewInstrType : Form
    {
        public NewInstrType()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //exit
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            String Context = "";
            //if select type, add it to SQL
            if(comboBox_InstrType.Text != "")
            {
                foreach (InstType instType in Program.PMC.InstTypes)
                    Context += instType.TypeName;
                //if the type exists
                if (Context.Contains(comboBox_InstrType.Text))
                    MessageBox.Show("This type already exists.");
                //if the type is new
                else
                {
                    Program.PMC.InstTypes.Add(new InstType() { TypeName = comboBox_InstrType.Text });
                    MessageBox.Show("Add successfully!");
                }
                Program.PMC.SaveChanges();
                this.Dispose();
            }
            //if not select type, return a messagebox
            else
                MessageBox.Show("Missing inputs.");
        }
    }
}
