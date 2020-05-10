using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonteCarloSim_ExoticOptions;

namespace PortfolioManager_MingxuanJiang
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //add columns into GUI
            listView_Totals.Columns.Add("Total P&L", 80);
            listView_Totals.Columns.Add("Total delta", 80);
            listView_Totals.Columns.Add("Total gamma", 80);
            listView_Totals.Columns.Add("Total vega", 80);
            listView_Totals.Columns.Add("Total theta", 80);
            listView_Totals.Columns.Add("Total rho", 80);
            listView_Alltrades.Columns.Add("ID", 80);
            listView_Alltrades.Columns.Add("Diection", 80);
            listView_Alltrades.Columns.Add("Quantity", 80);
            listView_Alltrades.Columns.Add("Instrument", 80);
            listView_Alltrades.Columns.Add("Inst type", 80);
            listView_Alltrades.Columns.Add("Trade price", 80);
            listView_Alltrades.Columns.Add("Market price", 80);
            listView_Alltrades.Columns.Add("P&L", 80);
            listView_Alltrades.Columns.Add("Delta", 80);
            listView_Alltrades.Columns.Add("Gamma", 80);
            listView_Alltrades.Columns.Add("Vega", 80);
            listView_Alltrades.Columns.Add("Theta", 80);
            listView_Alltrades.Columns.Add("Rho", 80);            
        }

        private void instrumentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInstrType newInstrType = new NewInstrType();
            newInstrType.ShowDialog();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInstr newInstr = new NewInstr();
            newInstr.ShowDialog();
        }

        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTrade newTrade = new NewTrade();
            newTrade.ShowDialog();
        }

        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInterestRate newInterestRate = new NewInterestRate();
            newInterestRate.ShowDialog();
        }

        private void historicalPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHistoricalPrice newHistoricalPrice = new NewHistoricalPrice();
            newHistoricalPrice.ShowDialog();
        }

        private void refreshTradesFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView_Alltrades.Items.Clear();
            ListViewItem listViewItem;
            foreach (Trade i in Program.PMC.Trades)
            {
                listViewItem = new ListViewItem();
                //id
                listViewItem.Text = Convert.ToString(i.Id);
                //direction
                if (i.IsBuy)
                    listViewItem.SubItems.Add("BUY");
                else
                    listViewItem.SubItems.Add("SELL");
                //quantity
                listViewItem.SubItems.Add(Convert.ToString(i.Quantity));
                //instrument
                listViewItem.SubItems.Add(i.Instrument.Ticker);
                //intrument type
                listViewItem.SubItems.Add(i.Instrument.InstType.TypeName);
                //trade price
                listViewItem.SubItems.Add(Convert.ToString(i.Price));
                listView_Alltrades.Items.Add(listViewItem);
            }
        }

        private void priceBookUsingSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double vol = Convert.ToDouble(textBox_vol.Text) / 100;
            var query1 = from i in Program.PMC.Prices select i;
            //if just 2 rates
            if ((from i in Program.PMC.InterestRates select i.Rate).Count() < 3)
                MessageBox.Show("Please add more interest rate!");
            else
            {
                // if the prices is not enough
                if ((query1.Count() == 0) || (query1.Count() < (from i in Program.PMC.Instruments where i.InstType.TypeName == "Stock" select i).Count()))
                    MessageBox.Show("Please add more historical prices!");
                else
                {
                    listView_Alltrades.BeginUpdate();
                    foreach(ListViewItem i in listView_Alltrades.Items)
                    {
                        int id = Convert.ToInt32(i.SubItems[0].Text);
                        Trade trade = Program.PMC.Trades.SingleOrDefault(j => j.Id == id);
                        if(id > 0)
                        {
                            int direction;
                            if (i.SubItems[1].Text == "BUY")
                                direction = 1;
                            else
                                direction = -1;
                            int quantity = Convert.ToInt32(i.SubItems[2].Text);
                            string instrument = i.SubItems[3].Text;
                            string instrtype = i.SubItems[4].Text;
                            double marketprice = Convert.ToDouble(i.SubItems[5].Text);
                            //get the id of instrument
                            int Instid = GetData.InstrumentID(instrument);
                            Instrument instrument1 = GetData.instrument(Instid);
                            double S = GetData.S(id);
                            double K = GetData.strike(Instid);
                            double t = GetData.tenor(Instid);
                            double r = GetData.rate(t, Instid);
                            double rebate = Convert.ToDouble(instrument1.Rebate);
                            double barrier = Convert.ToDouble(instrument1.Barrier);
                            int barriertype = 0;
                            if (instrument1.BarrierType == "Down and out")
                                barriertype = 1;
                            if (instrument1.BarrierType == "Up and out")
                                barriertype = 2;
                            if (instrument1.BarrierType == "Down and in")
                                barriertype = 3;
                            if (instrument1.BarrierType == "Up and in")
                                barriertype = 4;
                            int optiontype = 0;
                            if(instrtype == "Stock")
                                optiontype = 0;
                            if(instrtype == "EuropeanOption")
                                optiontype = 1;
                            if (instrtype == "AsianOption")
                                optiontype = 2;
                            if (instrtype == "DigitalOption")
                                optiontype = 3;
                            if (instrtype == "BarrierOption")
                                optiontype = 4;
                            if (instrtype == "LookbackOption")
                                optiontype = 5;
                            if (instrtype == "RangeOption")
                                optiontype = 6;

                            bool Iscall;
                            if (instrument1.IsCall == true)
                                Iscall = true;
                            else
                                Iscall = false;
                            if(optiontype == 0)
                            {
                                //stock
                                //market price
                                i.SubItems.Add(Convert.ToString(S));
                                //P&L
                                i.SubItems.Add(((S - marketprice) * direction * quantity).ToString());
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity));
                                //gamma
                                i.SubItems.Add(Convert.ToString(0));
                                //vega
                                i.SubItems.Add(Convert.ToString(0));
                                //rho
                                i.SubItems.Add(Convert.ToString(0));
                                //theta
                                i.SubItems.Add(Convert.ToString(0));
                            }
                            //European
                            if (optiontype == 1)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option European = new MonteCarloSim_ExoticOptions.European(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, 0, 0, 0);
                                //market price
                                i.SubItems.Add(Convert.ToString(European.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((European.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * European.Rho()));
                            }
                            //Asian
                            if (optiontype == 2)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option AisanOption = new MonteCarloSim_ExoticOptions.Asian(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, 0, 0, 0);
                                //market price
                                i.SubItems.Add(Convert.ToString(AisanOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((AisanOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * AisanOption.Rho()));
                            }
                            //Digital
                            if (optiontype == 3)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option DigitalOption = new MonteCarloSim_ExoticOptions.Digital(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, rebate, 0, 0);
                                //market price
                                i.SubItems.Add(Convert.ToString(DigitalOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((DigitalOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * DigitalOption.Rho()));
                            }
                            //Barrier
                            if (optiontype == 4)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option BarrierOption = new MonteCarloSim_ExoticOptions.Barrier(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, 0, barrier, barriertype);
                                //market price
                                i.SubItems.Add(Convert.ToString(BarrierOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((BarrierOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * BarrierOption.Rho()));
                            }
                            //Lookback
                            if (optiontype == 5)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option LookbackOption = new MonteCarloSim_ExoticOptions.Lookback(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, 0, 0, 0);
                                //market price
                                i.SubItems.Add(Convert.ToString(LookbackOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((LookbackOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * LookbackOption.Rho()));
                            }
                            //Range
                            if (optiontype == 6)
                            {
                                //option
                                MonteCarloSim_ExoticOptions.Option RangeOption = new MonteCarloSim_ExoticOptions.Range(S, K, r, vol, t, 10000, 50, Iscall, true, false, true, 0, 0, 0);
                                //market price
                                i.SubItems.Add(Convert.ToString(RangeOption.OptionPrice()[0]));
                                //P&L
                                i.SubItems.Add(Convert.ToString((RangeOption.OptionPrice()[0] - marketprice) * direction * quantity));
                                //delta
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Delta()));
                                //gamma
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Gamma()));
                                //vega
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Vega()));
                                //theta
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Theta()));
                                //rho
                                i.SubItems.Add(Convert.ToString(direction * quantity * RangeOption.Rho()));
                            }
                        }                                                             
                    }
                }
            }
            listView_Alltrades.EndUpdate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void historicalPriceAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HisPriceAnalysis hisPriceAnalysis = new HisPriceAnalysis();
            hisPriceAnalysis.ShowDialog();
        }

        private void interestRateAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RateAnalysis rateAnalysis = new RateAnalysis();
            rateAnalysis.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem i in listView_Alltrades.SelectedItems)
            {
                listView_Alltrades.Items.Remove(i);
                Program.PMC.Trades.Remove((from j in Program.PMC.Trades where j.Id.ToString() == i.Text select j).FirstOrDefault());
                Program.PMC.SaveChanges();
            }
        }

        private void listView_Alltrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            //market price MP
            double MP = 0, Delta = 0, Gamma = 0, Vega = 0, Theta = 0, Rho = 0;
            foreach(ListViewItem i in listView_Alltrades.SelectedItems)
            {
                if(i.SubItems.Count > 7)
                {
                    MP = MP + Convert.ToDouble(i.SubItems[7].Text);
                    Delta = Delta + Convert.ToDouble(i.SubItems[8].Text);
                    Gamma = Gamma + Convert.ToDouble(i.SubItems[9].Text);
                    Vega = Vega + Convert.ToDouble(i.SubItems[10].Text);
                    Theta = Theta + Convert.ToDouble(i.SubItems[11].Text);
                    Rho = Rho + Convert.ToDouble(i.SubItems[12].Text);
                }
            }
            ListViewItem listViewItem = new ListViewItem(MP.ToString());
            listViewItem.SubItems.Add(Convert.ToString(Delta));
            listViewItem.SubItems.Add(Convert.ToString(Gamma));
            listViewItem.SubItems.Add(Convert.ToString(Vega));
            listViewItem.SubItems.Add(Convert.ToString(Theta));
            listViewItem.SubItems.Add(Convert.ToString(Rho));
            listView_Totals.BeginUpdate();
            listView_Totals.Items.Clear();
            listView_Totals.Items.Add(listViewItem);
            listView_Totals.EndUpdate();
        }

        private void listView_Alltrades_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Alltrades.FocusedItem.Bounds.Contains(e.Location))
                    contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void generateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateData generateData = new GenerateData();
            generateData.ShowDialog();
        }
    }
}
