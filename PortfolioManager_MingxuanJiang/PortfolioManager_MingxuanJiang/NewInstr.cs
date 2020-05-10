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
    public partial class NewInstr : Form
    {
        public NewInstr()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NewInstr_Load(object sender, EventArgs e)
        {
            //select Stocks, if Ticker is new, store it
            foreach (var i in (from j in Program.PMC.Instruments where j.InstType.TypeName == "Stock" select j))
            {
                if (!comboBox_Underlying.Items.Contains(i.Ticker))
                    comboBox_Underlying.Items.Add(i.Ticker);
            }
            //if not exist rows in instrument, show a messagebox and exit
            if ((from j in Program.PMC.InstTypes select j).Count() != 0)
            {
                //clear instrument type and reload
                comboBox_InstType.Items.Clear();
                foreach (InstType i in (from j in Program.PMC.InstTypes select j))
                    comboBox_InstType.Items.Add(i.TypeName);
                //initialize
                comboBox_InstType.Text = Convert.ToString(comboBox_InstType.Items[0]);
                radioButton_Neither.Checked = true;
                textBox_Strike.Enabled = false;
                textBox_Tenor.Enabled = false;
                textBox_Rebate.Enabled = false;
                textBox_Barrier.Enabled = false;
                comboBox_BarrierType.Enabled = false;
                //stock
                if (comboBox_InstType.Text == "Stock")
                {
                    radioButton_Neither.Checked = true;
                    textBox_Strike.Enabled = false;
                    textBox_Tenor.Enabled = false;
                    textBox_Rebate.Enabled = false;
                    textBox_Barrier.Enabled = false;
                    comboBox_BarrierType.Enabled = false;
                    comboBox_Underlying.Enabled = false;
                }
                //option
                else
                {
                    comboBox_Underlying.Enabled = true;
                    radioButton_Call.Checked = true;
                    textBox_Strike.Enabled = true;
                    textBox_Tenor.Enabled = true;
                    if (comboBox_InstType.Text == "DigitalOption")
                    {
                        textBox_Rebate.Enabled = true;
                        textBox_Barrier.Enabled = false;
                        comboBox_BarrierType.Enabled = false;
                    }
                    if (comboBox_InstType.Text == "BarrierOption")
                    {
                        textBox_Rebate.Enabled = false;
                        textBox_Barrier.Enabled = true;
                        comboBox_BarrierType.Enabled = true;
                        comboBox_BarrierType.Text = Convert.ToString(comboBox_BarrierType.Items[0]);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data in Instrument!");
                this.Dispose();
            }
        }

        private void comboBox_InstType_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton_Neither.Checked = true;
            textBox_Strike.Enabled = false;
            textBox_Tenor.Enabled = false;
            textBox_Rebate.Enabled = false;
            textBox_Barrier.Enabled = false;
            comboBox_BarrierType.Enabled = false;
            //stock
            if (comboBox_InstType.Text == "Stock")
            {
                radioButton_Neither.Checked = true;
                textBox_Strike.Enabled = false;
                textBox_Tenor.Enabled = false;
                textBox_Rebate.Enabled = false;
                textBox_Barrier.Enabled = false;
                comboBox_BarrierType.Enabled = false;
                comboBox_Underlying.Enabled = false;
            }
            else
            {
                comboBox_Underlying.Enabled = true;
                radioButton_Call.Checked = true;
                textBox_Strike.Enabled = true;
                textBox_Tenor.Enabled = true;
                //digital
                if (comboBox_InstType.Text == "DigitalOption")
                {
                    textBox_Rebate.Enabled = true;
                    textBox_Barrier.Enabled = false;
                    comboBox_BarrierType.Enabled = false;
                }
                //barrier
                if (comboBox_InstType.Text == "BarrierOption")
                {
                    textBox_Rebate.Enabled = false;
                    textBox_Barrier.Enabled = true;
                    comboBox_BarrierType.Enabled = true;
                    comboBox_BarrierType.Text = Convert.ToString(comboBox_BarrierType.Items[0]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if missing data
            if (textBox_CompanyName.Text == String.Empty || textBox_Ticker.Text == String.Empty
                || textBox_Exchange.Text == String.Empty || comboBox_InstType.Text == String.Empty)
                MessageBox.Show("Missing some inputs.");                
            else
            {
                InstType instType = (from i in Program.PMC.InstTypes where i.TypeName == comboBox_InstType.Text select i).FirstOrDefault();
                var query = from i in Program.PMC.Instruments where i.InstType.TypeName == "Stock" select i.Ticker;
                //justify where the ticker exists
                bool same_ticker = false;
                foreach (string i in query)
                {
                    if (i.Contains(textBox_Ticker.Text))
                        same_ticker = true;
                }
                //if exists same ticker
                if (!same_ticker)
                {
                    //stock
                    if (comboBox_InstType.Text == "Stock")
                    {
                        Program.PMC.Instruments.Add(new Instrument()
                        {
                            CompanyName = textBox_CompanyName.Text,
                            Ticker = textBox_Ticker.Text,
                            Exchange = textBox_Exchange.Text,
                            Underlying = "",
                            InstType = instType
                        });
                        Program.PMC.SaveChanges();
                        MessageBox.Show("Add successfully!");
                        this.Dispose();
                    }
                    else
                    {
                        //digital option
                        if (comboBox_InstType.Text == "DigitalOption")
                        {
                            if (textBox_Strike.Text == String.Empty || textBox_Tenor.Text == String.Empty
                                || textBox_Rebate.Text == String.Empty || comboBox_Underlying.Text == String.Empty)
                                MessageBox.Show("Missing some data.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_CompanyName.Text,
                                    Ticker = textBox_Ticker.Text,
                                    Exchange = textBox_Exchange.Text,
                                    Underlying = comboBox_Underlying.Text,
                                    Strike = Convert.ToDouble(textBox_Strike.Text),
                                    Tenor = Convert.ToDouble(textBox_Tenor.Text),
                                    IsCall = radioButton_Call.Checked,
                                    Rebate = Convert.ToDouble(textBox_Rebate.Text),
                                    Barrier = 0,
                                    BarrierType = "",
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }
                        //barrier option
                        else if (comboBox_InstType.Text == "BarrierOption")
                        {
                            if (textBox_Strike.Text == String.Empty || textBox_Tenor.Text == String.Empty
                                || textBox_Barrier.Text == String.Empty || comboBox_BarrierType.Text == String.Empty
                                || comboBox_Underlying.Text == String.Empty)
                                MessageBox.Show("Missing input.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_CompanyName.Text,
                                    Ticker = textBox_Ticker.Text,
                                    Exchange = textBox_Exchange.Text,
                                    Underlying = comboBox_Underlying.Text,
                                    Strike = Convert.ToDouble(textBox_Strike.Text),
                                    Tenor = Convert.ToDouble(textBox_Tenor.Text),
                                    IsCall = radioButton_Call.Checked,
                                    Rebate = 0,
                                    Barrier = Convert.ToDouble(textBox_Barrier.Text),
                                    BarrierType = comboBox_BarrierType.Text,
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }
                        //other option
                        else
                        {
                            if (textBox_Strike.Text == String.Empty || textBox_Tenor.Text == String.Empty
                            || comboBox_Underlying.Text == String.Empty)
                                MessageBox.Show("Missing input.");
                            else
                            {
                                Program.PMC.Instruments.Add(new Instrument()
                                {
                                    CompanyName = textBox_CompanyName.Text,
                                    Ticker = textBox_Ticker.Text,
                                    Exchange = textBox_Exchange.Text,
                                    Underlying = comboBox_Underlying.Text,
                                    Strike = Convert.ToDouble(textBox_Strike.Text),
                                    Tenor = Convert.ToDouble(textBox_Tenor.Text),
                                    IsCall = radioButton_Call.Checked,
                                    Rebate = 0,
                                    Barrier = 0,
                                    BarrierType = "",
                                    InstType = instType
                                });
                                Program.PMC.SaveChanges();
                                MessageBox.Show("Add successfully!");
                                this.Dispose();
                            }
                        }
                        
                    }
                }
                else
                    MessageBox.Show("Already exist.");
            }
        }

        private void comboBox_Underlying_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var query in (from i in Program.PMC.Instruments where i.Ticker == comboBox_Underlying.Text select i))
                textBox_CompanyName.Text = query.CompanyName;
        }
    }
}
