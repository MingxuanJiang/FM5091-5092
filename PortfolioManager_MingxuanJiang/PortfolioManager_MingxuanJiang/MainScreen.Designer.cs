namespace PortfolioManager_MingxuanJiang
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTradesFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceBookUsingSimulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_vol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView_Totals = new System.Windows.Forms.ListView();
            this.listView_Alltrades = new System.Windows.Forms.ListView();
            this.generateDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1677, 52);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refreshTradesFromDatabaseToolStripMenuItem,
            this.priceBookUsingSimulationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 48);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentTypeToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.tradeToolStripMenuItem,
            this.interestRateToolStripMenuItem,
            this.historicalPriceToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(571, 54);
            this.newToolStripMenuItem.Text = "New";
            // 
            // instrumentTypeToolStripMenuItem
            // 
            this.instrumentTypeToolStripMenuItem.Name = "instrumentTypeToolStripMenuItem";
            this.instrumentTypeToolStripMenuItem.Size = new System.Drawing.Size(395, 54);
            this.instrumentTypeToolStripMenuItem.Text = "Instrument type";
            this.instrumentTypeToolStripMenuItem.Click += new System.EventHandler(this.instrumentTypeToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(395, 54);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(395, 54);
            this.tradeToolStripMenuItem.Text = "Trade";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.tradeToolStripMenuItem_Click);
            // 
            // interestRateToolStripMenuItem
            // 
            this.interestRateToolStripMenuItem.Name = "interestRateToolStripMenuItem";
            this.interestRateToolStripMenuItem.Size = new System.Drawing.Size(395, 54);
            this.interestRateToolStripMenuItem.Text = "Interest rate";
            this.interestRateToolStripMenuItem.Click += new System.EventHandler(this.interestRateToolStripMenuItem_Click);
            // 
            // historicalPriceToolStripMenuItem
            // 
            this.historicalPriceToolStripMenuItem.Name = "historicalPriceToolStripMenuItem";
            this.historicalPriceToolStripMenuItem.Size = new System.Drawing.Size(395, 54);
            this.historicalPriceToolStripMenuItem.Text = "Historical price";
            this.historicalPriceToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceToolStripMenuItem_Click);
            // 
            // refreshTradesFromDatabaseToolStripMenuItem
            // 
            this.refreshTradesFromDatabaseToolStripMenuItem.Name = "refreshTradesFromDatabaseToolStripMenuItem";
            this.refreshTradesFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(571, 54);
            this.refreshTradesFromDatabaseToolStripMenuItem.Text = "Refresh trades from database";
            this.refreshTradesFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.refreshTradesFromDatabaseToolStripMenuItem_Click);
            // 
            // priceBookUsingSimulationToolStripMenuItem
            // 
            this.priceBookUsingSimulationToolStripMenuItem.Name = "priceBookUsingSimulationToolStripMenuItem";
            this.priceBookUsingSimulationToolStripMenuItem.Size = new System.Drawing.Size(571, 54);
            this.priceBookUsingSimulationToolStripMenuItem.Text = "Price book using simulation";
            this.priceBookUsingSimulationToolStripMenuItem.Click += new System.EventHandler(this.priceBookUsingSimulationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(571, 54);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicalPriceAnalysisToolStripMenuItem,
            this.interestRateAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(148, 48);
            this.analysisToolStripMenuItem.Text = "Analysis";
            // 
            // historicalPriceAnalysisToolStripMenuItem
            // 
            this.historicalPriceAnalysisToolStripMenuItem.Name = "historicalPriceAnalysisToolStripMenuItem";
            this.historicalPriceAnalysisToolStripMenuItem.Size = new System.Drawing.Size(489, 54);
            this.historicalPriceAnalysisToolStripMenuItem.Text = "Historical price analysis";
            this.historicalPriceAnalysisToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceAnalysisToolStripMenuItem_Click);
            // 
            // interestRateAnalysisToolStripMenuItem
            // 
            this.interestRateAnalysisToolStripMenuItem.Name = "interestRateAnalysisToolStripMenuItem";
            this.interestRateAnalysisToolStripMenuItem.Size = new System.Drawing.Size(489, 54);
            this.interestRateAnalysisToolStripMenuItem.Text = "Interest rate analysis";
            this.interestRateAnalysisToolStripMenuItem.Click += new System.EventHandler(this.interestRateAnalysisToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDataToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(136, 48);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 52);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(182, 48);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pricing volatility (%):";
            // 
            // textBox_vol
            // 
            this.textBox_vol.Location = new System.Drawing.Point(320, 80);
            this.textBox_vol.Name = "textBox_vol";
            this.textBox_vol.Size = new System.Drawing.Size(362, 38);
            this.textBox_vol.TabIndex = 3;
            this.textBox_vol.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Totals:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "All trades:";
            // 
            // listView_Totals
            // 
            this.listView_Totals.FullRowSelect = true;
            this.listView_Totals.HideSelection = false;
            this.listView_Totals.Location = new System.Drawing.Point(38, 201);
            this.listView_Totals.Name = "listView_Totals";
            this.listView_Totals.Size = new System.Drawing.Size(1554, 132);
            this.listView_Totals.TabIndex = 6;
            this.listView_Totals.UseCompatibleStateImageBehavior = false;
            this.listView_Totals.View = System.Windows.Forms.View.Details;
            // 
            // listView_Alltrades
            // 
            this.listView_Alltrades.FullRowSelect = true;
            this.listView_Alltrades.HideSelection = false;
            this.listView_Alltrades.Location = new System.Drawing.Point(39, 393);
            this.listView_Alltrades.Name = "listView_Alltrades";
            this.listView_Alltrades.Size = new System.Drawing.Size(1553, 474);
            this.listView_Alltrades.TabIndex = 1;
            this.listView_Alltrades.UseCompatibleStateImageBehavior = false;
            this.listView_Alltrades.View = System.Windows.Forms.View.Details;
            this.listView_Alltrades.SelectedIndexChanged += new System.EventHandler(this.listView_Alltrades_SelectedIndexChanged);
            this.listView_Alltrades.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView_Alltrades_MouseUp);
            // 
            // generateDataToolStripMenuItem
            // 
            this.generateDataToolStripMenuItem.Name = "generateDataToolStripMenuItem";
            this.generateDataToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.generateDataToolStripMenuItem.Text = "Generate Data";
            this.generateDataToolStripMenuItem.Click += new System.EventHandler(this.generateDataToolStripMenuItem_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 879);
            this.Controls.Add(this.listView_Alltrades);
            this.Controls.Add(this.listView_Totals);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_vol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainScreen";
            this.Text = "My Portfolio Manager";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshTradesFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceBookUsingSimulationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_vol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView_Totals;
        private System.Windows.Forms.ListView listView_Alltrades;
        private System.Windows.Forms.ToolStripMenuItem generateDataToolStripMenuItem;
    }
}