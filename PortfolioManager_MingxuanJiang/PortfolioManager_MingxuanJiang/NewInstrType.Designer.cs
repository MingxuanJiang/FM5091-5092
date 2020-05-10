namespace PortfolioManager_MingxuanJiang
{
    partial class NewInstrType
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.comboBox_InstrType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instrument type name:";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(641, 124);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(134, 58);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(828, 124);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(136, 58);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // comboBox_InstrType
            // 
            this.comboBox_InstrType.FormattingEnabled = true;
            this.comboBox_InstrType.Items.AddRange(new object[] {
            "Stock",
            "EuropeanOption",
            "AsianOption",
            "DigitalOption",
            "BarrierOption",
            "LookbackOption",
            "RangeOption"});
            this.comboBox_InstrType.Location = new System.Drawing.Point(332, 55);
            this.comboBox_InstrType.Name = "comboBox_InstrType";
            this.comboBox_InstrType.Size = new System.Drawing.Size(670, 39);
            this.comboBox_InstrType.TabIndex = 4;
            // 
            // NewInstrType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 224);
            this.Controls.Add(this.comboBox_InstrType);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Name = "NewInstrType";
            this.Text = "New Instrument type...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox comboBox_InstrType;
    }
}