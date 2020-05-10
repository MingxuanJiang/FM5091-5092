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
    public partial class GenerateData : Form
    {
        public GenerateData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add data into instrument type table
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "Stock"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "EuropeanOption"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "AsianOption"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "DigitalOption"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "BarrierOption"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "LookbackOption"
            });
            Program.PMC.InstTypes.Add(new InstType()
            {
                TypeName = "RangeOption"
            });
            //add data into Instrument table
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "Miscroft Corp.",
                Ticker = "MSFTC90",
                Exchange = "NASDAQ",
                Underlying = "MSFT",
                Strike = 90,
                Tenor = 0.5,
                IsCall = true,
                InstTypeId = 2
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "AA",
                Exchange = "A",
                Underlying = "",
                InstTypeId = 1
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "BB",
                Exchange = "B",
                Underlying = "AA",
                Strike = 90,
                Tenor = 1,
                IsCall = true,
                Rebate = 0,
                Barrier = 0,
                InstTypeId = 2
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "CC",
                Exchange = "C",
                Underlying = "AA",
                Strike = 60,
                Tenor = 1,
                IsCall = true,
                Rebate = 0,
                Barrier = 0,
                InstTypeId = 3
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "AAA",
                Ticker = "DD",
                Exchange = "D",
                Underlying = "AA",
                Strike = 90,
                Tenor = 0.6,
                IsCall = true,
                Rebate = 1,
                Barrier = 0,
                InstTypeId = 4
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "GGG",
                Ticker = "GG",
                Exchange = "G",
                Underlying = "",
                InstTypeId = 1
            });
            Program.PMC.Instruments.Add(new Instrument()
            {
                CompanyName = "Miscroft Corp.",
                Ticker = "EE",
                Exchange = "E",
                Underlying = "MSFT",
                Strike = 80,
                Tenor = 1,
                IsCall = false,
                InstTypeId = 2
            });
            //add data into InterestRates table
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 1,
                Rate = 3
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 2,
                Rate = 4
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 0.21,
                Rate = 3
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 0.1,
                Rate = 1.5
            });
            Program.PMC.InterestRates.Add(new InterestRate()
            {
                Tenor = 0.5,
                Rate = 3.5
            });
            //add data into prices table
            Program.PMC.Prices.Add(new Price()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 10,
                InstrumentId = 2
            });
            Program.PMC.Prices.Add(new Price()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 20,
                InstrumentId = 2
            });
            Program.PMC.Prices.Add(new Price()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 40,
                InstrumentId = 2
            });
            Program.PMC.Prices.Add(new Price()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 30,
                InstrumentId = 2
            });
            Program.PMC.Prices.Add(new Price()
            {
                Date = System.DateTime.Today,
                ClosingPrice = 60,
                InstrumentId = 6
            });
            //add data into Trades table
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = true,
                Quantity = 1,
                Price = 30,
                Timestamp =System.DateTime.Now,
                InstrumentId = 2
            });
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = false,
                Quantity = 2,
                Price = 40,
                Timestamp = System.DateTime.Now,
                InstrumentId = 2
            });
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = true,
                Quantity = 1,
                Price = 30,
                Timestamp = System.DateTime.Now,
                InstrumentId = 4
            });
            Program.PMC.Trades.Add(new Trade()
            {
                IsBuy = false,
                Quantity = 2,
                Price = 40,
                Timestamp = System.DateTime.Now,
                InstrumentId = 3
            });
            Program.PMC.SaveChanges();
            MessageBox.Show("Add data to SQL successfully!");
        }
    }
}
