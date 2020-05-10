namespace PortfolioManager_MingxuanJiang
{
    partial class NewTrade
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_Buy = new System.Windows.Forms.RadioButton();
            this.radioButton_Sell = new System.Windows.Forms.RadioButton();
            this.textBox_Quantity = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.comboBox_Instrument = new System.Windows.Forms.ComboBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Direction:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instrument:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price:";
            // 
            // radioButton_Buy
            // 
            this.radioButton_Buy.AutoSize = true;
            this.radioButton_Buy.Location = new System.Drawing.Point(274, 39);
            this.radioButton_Buy.Name = "radioButton_Buy";
            this.radioButton_Buy.Size = new System.Drawing.Size(101, 36);
            this.radioButton_Buy.TabIndex = 4;
            this.radioButton_Buy.TabStop = true;
            this.radioButton_Buy.Text = "Buy";
            this.radioButton_Buy.UseVisualStyleBackColor = true;
            // 
            // radioButton_Sell
            // 
            this.radioButton_Sell.AutoSize = true;
            this.radioButton_Sell.Location = new System.Drawing.Point(461, 37);
            this.radioButton_Sell.Name = "radioButton_Sell";
            this.radioButton_Sell.Size = new System.Drawing.Size(101, 36);
            this.radioButton_Sell.TabIndex = 5;
            this.radioButton_Sell.TabStop = true;
            this.radioButton_Sell.Text = "Sell";
            this.radioButton_Sell.UseVisualStyleBackColor = true;
            // 
            // textBox_Quantity
            // 
            this.textBox_Quantity.Location = new System.Drawing.Point(215, 91);
            this.textBox_Quantity.Name = "textBox_Quantity";
            this.textBox_Quantity.Size = new System.Drawing.Size(633, 38);
            this.textBox_Quantity.TabIndex = 6;
            this.textBox_Quantity.TextChanged += new System.EventHandler(this.textBox_Quantity_TextChanged);
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(215, 204);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(633, 38);
            this.textBox_Price.TabIndex = 7;
            // 
            // comboBox_Instrument
            // 
            this.comboBox_Instrument.FormattingEnabled = true;
            this.comboBox_Instrument.Location = new System.Drawing.Point(215, 146);
            this.comboBox_Instrument.Name = "comboBox_Instrument";
            this.comboBox_Instrument.Size = new System.Drawing.Size(633, 39);
            this.comboBox_Instrument.TabIndex = 8;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(367, 271);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(212, 73);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(636, 271);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(212, 73);
            this.button_Cancel.TabIndex = 10;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // NewTrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 393);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_Instrument);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.textBox_Quantity);
            this.Controls.Add(this.radioButton_Sell);
            this.Controls.Add(this.radioButton_Buy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewTrade";
            this.Text = "New Trade...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_Buy;
        private System.Windows.Forms.RadioButton radioButton_Sell;
        private System.Windows.Forms.TextBox textBox_Quantity;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.ComboBox comboBox_Instrument;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}