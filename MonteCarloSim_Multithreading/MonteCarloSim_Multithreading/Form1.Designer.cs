namespace MonteCarloSim_Multithreading
{
    partial class Form1
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TextBox_S = new System.Windows.Forms.TextBox();
            this.TextBox_K = new System.Windows.Forms.TextBox();
            this.TextBox_r = new System.Windows.Forms.TextBox();
            this.TextBox_Sigma = new System.Windows.Forms.TextBox();
            this.TextBox_T = new System.Windows.Forms.TextBox();
            this.TextBox_Sims = new System.Windows.Forms.TextBox();
            this.TextBox_Steps = new System.Windows.Forms.TextBox();
            this.Radio_Call = new System.Windows.Forms.RadioButton();
            this.Radio_Put = new System.Windows.Forms.RadioButton();
            this.checkbox_AntVar = new System.Windows.Forms.CheckBox();
            this.checkbox_CV = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TextBox_Std = new System.Windows.Forms.TextBox();
            this.TextBox_Rho = new System.Windows.Forms.TextBox();
            this.TextBox_Theta = new System.Windows.Forms.TextBox();
            this.TextBox_Vega = new System.Windows.Forms.TextBox();
            this.TextBox_Gamma = new System.Windows.Forms.TextBox();
            this.TextBox_Delta = new System.Windows.Forms.TextBox();
            this.TextBox_Price = new System.Windows.Forms.TextBox();
            this.TextBox_Time = new System.Windows.Forms.TextBox();
            this.Button_Sample = new System.Windows.Forms.Button();
            this.Button_Go = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider6 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider7 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox_MT = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBox_Cores = new System.Windows.Forms.TextBox();
            this.label_bar = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider7)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(71, 674);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1120, 31);
            this.progressBar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "S";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "K";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "r";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sigma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "T";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 32);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sims";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 32);
            this.label7.TabIndex = 9;
            this.label7.Text = "Steps";
            // 
            // TextBox_S
            // 
            this.TextBox_S.Location = new System.Drawing.Point(168, 101);
            this.TextBox_S.Name = "TextBox_S";
            this.TextBox_S.Size = new System.Drawing.Size(285, 38);
            this.TextBox_S.TabIndex = 10;
            this.TextBox_S.TextChanged += new System.EventHandler(this.TextBox_S_TextChanged);
            // 
            // TextBox_K
            // 
            this.TextBox_K.Location = new System.Drawing.Point(168, 159);
            this.TextBox_K.Name = "TextBox_K";
            this.TextBox_K.Size = new System.Drawing.Size(285, 38);
            this.TextBox_K.TabIndex = 11;
            this.TextBox_K.TextChanged += new System.EventHandler(this.TextBox_K_TextChanged);
            // 
            // TextBox_r
            // 
            this.TextBox_r.Location = new System.Drawing.Point(168, 219);
            this.TextBox_r.Name = "TextBox_r";
            this.TextBox_r.Size = new System.Drawing.Size(285, 38);
            this.TextBox_r.TabIndex = 12;
            this.TextBox_r.TextChanged += new System.EventHandler(this.TextBox_r_TextChanged);
            // 
            // TextBox_Sigma
            // 
            this.TextBox_Sigma.Location = new System.Drawing.Point(168, 285);
            this.TextBox_Sigma.Name = "TextBox_Sigma";
            this.TextBox_Sigma.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Sigma.TabIndex = 13;
            this.TextBox_Sigma.TextChanged += new System.EventHandler(this.TextBox_Sigma_TextChanged);
            // 
            // TextBox_T
            // 
            this.TextBox_T.Location = new System.Drawing.Point(168, 351);
            this.TextBox_T.Name = "TextBox_T";
            this.TextBox_T.Size = new System.Drawing.Size(285, 38);
            this.TextBox_T.TabIndex = 14;
            this.TextBox_T.TextChanged += new System.EventHandler(this.TextBox_T_TextChanged);
            // 
            // TextBox_Sims
            // 
            this.TextBox_Sims.Location = new System.Drawing.Point(168, 413);
            this.TextBox_Sims.Name = "TextBox_Sims";
            this.TextBox_Sims.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Sims.TabIndex = 15;
            this.TextBox_Sims.TextChanged += new System.EventHandler(this.TextBox_Sims_TextChanged);
            // 
            // TextBox_Steps
            // 
            this.TextBox_Steps.Location = new System.Drawing.Point(168, 488);
            this.TextBox_Steps.Name = "TextBox_Steps";
            this.TextBox_Steps.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Steps.TabIndex = 16;
            this.TextBox_Steps.TextChanged += new System.EventHandler(this.TextBox_Steps_TextChanged);
            // 
            // Radio_Call
            // 
            this.Radio_Call.AutoSize = true;
            this.Radio_Call.Location = new System.Drawing.Point(483, 191);
            this.Radio_Call.Name = "Radio_Call";
            this.Radio_Call.Size = new System.Drawing.Size(102, 36);
            this.Radio_Call.TabIndex = 17;
            this.Radio_Call.TabStop = true;
            this.Radio_Call.Text = "Call";
            this.Radio_Call.UseVisualStyleBackColor = true;
            // 
            // Radio_Put
            // 
            this.Radio_Put.AutoSize = true;
            this.Radio_Put.Location = new System.Drawing.Point(606, 190);
            this.Radio_Put.Name = "Radio_Put";
            this.Radio_Put.Size = new System.Drawing.Size(95, 36);
            this.Radio_Put.TabIndex = 18;
            this.Radio_Put.TabStop = true;
            this.Radio_Put.Text = "Put";
            this.Radio_Put.UseVisualStyleBackColor = true;
            // 
            // checkbox_AntVar
            // 
            this.checkbox_AntVar.AutoSize = true;
            this.checkbox_AntVar.Location = new System.Drawing.Point(483, 262);
            this.checkbox_AntVar.Name = "checkbox_AntVar";
            this.checkbox_AntVar.Size = new System.Drawing.Size(172, 36);
            this.checkbox_AntVar.TabIndex = 19;
            this.checkbox_AntVar.Text = "Antithetic";
            this.checkbox_AntVar.UseVisualStyleBackColor = true;
            // 
            // checkbox_CV
            // 
            this.checkbox_CV.AutoSize = true;
            this.checkbox_CV.Location = new System.Drawing.Point(483, 327);
            this.checkbox_CV.Name = "checkbox_CV";
            this.checkbox_CV.Size = new System.Drawing.Size(92, 36);
            this.checkbox_CV.TabIndex = 20;
            this.checkbox_CV.Text = "CV";
            this.checkbox_CV.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(769, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 32);
            this.label8.TabIndex = 21;
            this.label8.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(767, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 32);
            this.label9.TabIndex = 22;
            this.label9.Text = "Delta";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(767, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 32);
            this.label10.TabIndex = 23;
            this.label10.Text = "Gamma";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(773, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 32);
            this.label11.TabIndex = 24;
            this.label11.Text = "Vega";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(773, 296);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 32);
            this.label12.TabIndex = 25;
            this.label12.Text = "Theta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(782, 364);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 32);
            this.label13.TabIndex = 26;
            this.label13.Text = "Rho";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(780, 436);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 32);
            this.label14.TabIndex = 27;
            this.label14.Text = "Std Error";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(783, 575);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 32);
            this.label15.TabIndex = 28;
            this.label15.Text = "Time";
            // 
            // TextBox_Std
            // 
            this.TextBox_Std.Location = new System.Drawing.Point(906, 433);
            this.TextBox_Std.Name = "TextBox_Std";
            this.TextBox_Std.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Std.TabIndex = 35;
            // 
            // TextBox_Rho
            // 
            this.TextBox_Rho.Location = new System.Drawing.Point(906, 358);
            this.TextBox_Rho.Name = "TextBox_Rho";
            this.TextBox_Rho.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Rho.TabIndex = 34;
            // 
            // TextBox_Theta
            // 
            this.TextBox_Theta.Location = new System.Drawing.Point(906, 296);
            this.TextBox_Theta.Name = "TextBox_Theta";
            this.TextBox_Theta.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Theta.TabIndex = 33;
            // 
            // TextBox_Vega
            // 
            this.TextBox_Vega.Location = new System.Drawing.Point(906, 230);
            this.TextBox_Vega.Name = "TextBox_Vega";
            this.TextBox_Vega.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Vega.TabIndex = 32;
            // 
            // TextBox_Gamma
            // 
            this.TextBox_Gamma.Location = new System.Drawing.Point(906, 164);
            this.TextBox_Gamma.Name = "TextBox_Gamma";
            this.TextBox_Gamma.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Gamma.TabIndex = 31;
            // 
            // TextBox_Delta
            // 
            this.TextBox_Delta.Location = new System.Drawing.Point(906, 104);
            this.TextBox_Delta.Name = "TextBox_Delta";
            this.TextBox_Delta.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Delta.TabIndex = 30;
            // 
            // TextBox_Price
            // 
            this.TextBox_Price.Location = new System.Drawing.Point(906, 46);
            this.TextBox_Price.Name = "TextBox_Price";
            this.TextBox_Price.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Price.TabIndex = 29;
            // 
            // TextBox_Time
            // 
            this.TextBox_Time.Location = new System.Drawing.Point(905, 575);
            this.TextBox_Time.Name = "TextBox_Time";
            this.TextBox_Time.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Time.TabIndex = 36;
            // 
            // Button_Sample
            // 
            this.Button_Sample.Location = new System.Drawing.Point(71, 549);
            this.Button_Sample.Name = "Button_Sample";
            this.Button_Sample.Size = new System.Drawing.Size(215, 76);
            this.Button_Sample.TabIndex = 37;
            this.Button_Sample.Text = "Sample";
            this.Button_Sample.UseVisualStyleBackColor = true;
            this.Button_Sample.Click += new System.EventHandler(this.Button_Sample_Click);
            // 
            // Button_Go
            // 
            this.Button_Go.Location = new System.Drawing.Point(366, 549);
            this.Button_Go.Name = "Button_Go";
            this.Button_Go.Size = new System.Drawing.Size(351, 76);
            this.Button_Go.TabIndex = 38;
            this.Button_Go.Text = "Go";
            this.Button_Go.UseVisualStyleBackColor = true;
            this.Button_Go.Click += new System.EventHandler(this.Button_Go_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // errorProvider6
            // 
            this.errorProvider6.ContainerControl = this;
            // 
            // errorProvider7
            // 
            this.errorProvider7.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(483, 95);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 39);
            this.comboBox1.TabIndex = 39;
            this.comboBox1.Text = "European";
            // 
            // checkBox_MT
            // 
            this.checkBox_MT.AutoSize = true;
            this.checkBox_MT.Location = new System.Drawing.Point(483, 383);
            this.checkBox_MT.Name = "checkBox_MT";
            this.checkBox_MT.Size = new System.Drawing.Size(234, 36);
            this.checkBox_MT.TabIndex = 40;
            this.checkBox_MT.Text = "Multithreading";
            this.checkBox_MT.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(782, 506);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 32);
            this.label16.TabIndex = 41;
            this.label16.Text = "Cores";
            // 
            // TextBox_Cores
            // 
            this.TextBox_Cores.Location = new System.Drawing.Point(905, 506);
            this.TextBox_Cores.Name = "TextBox_Cores";
            this.TextBox_Cores.Size = new System.Drawing.Size(285, 38);
            this.TextBox_Cores.TabIndex = 42;
            // 
            // label_bar
            // 
            this.label_bar.AutoSize = true;
            this.label_bar.Location = new System.Drawing.Point(74, 639);
            this.label_bar.Name = "label_bar";
            this.label_bar.Size = new System.Drawing.Size(235, 32);
            this.label_bar.TabIndex = 43;
            this.label_bar.Text = "Waiting for inputs";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(345, 639);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 32);
            this.label19.TabIndex = 46;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 734);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label_bar);
            this.Controls.Add(this.TextBox_Cores);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.checkBox_MT);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Button_Go);
            this.Controls.Add(this.Button_Sample);
            this.Controls.Add(this.TextBox_Time);
            this.Controls.Add(this.TextBox_Std);
            this.Controls.Add(this.TextBox_Rho);
            this.Controls.Add(this.TextBox_Theta);
            this.Controls.Add(this.TextBox_Vega);
            this.Controls.Add(this.TextBox_Gamma);
            this.Controls.Add(this.TextBox_Delta);
            this.Controls.Add(this.TextBox_Price);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkbox_CV);
            this.Controls.Add(this.checkbox_AntVar);
            this.Controls.Add(this.Radio_Put);
            this.Controls.Add(this.Radio_Call);
            this.Controls.Add(this.TextBox_Steps);
            this.Controls.Add(this.TextBox_Sims);
            this.Controls.Add(this.TextBox_T);
            this.Controls.Add(this.TextBox_Sigma);
            this.Controls.Add(this.TextBox_r);
            this.Controls.Add(this.TextBox_K);
            this.Controls.Add(this.TextBox_S);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TextBox_S;
        private System.Windows.Forms.TextBox TextBox_K;
        private System.Windows.Forms.TextBox TextBox_r;
        private System.Windows.Forms.TextBox TextBox_Sigma;
        private System.Windows.Forms.TextBox TextBox_T;
        private System.Windows.Forms.TextBox TextBox_Sims;
        private System.Windows.Forms.TextBox TextBox_Steps;
        private System.Windows.Forms.RadioButton Radio_Call;
        private System.Windows.Forms.RadioButton Radio_Put;
        private System.Windows.Forms.CheckBox checkbox_AntVar;
        private System.Windows.Forms.CheckBox checkbox_CV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TextBox_Std;
        private System.Windows.Forms.TextBox TextBox_Rho;
        private System.Windows.Forms.TextBox TextBox_Theta;
        private System.Windows.Forms.TextBox TextBox_Vega;
        private System.Windows.Forms.TextBox TextBox_Gamma;
        private System.Windows.Forms.TextBox TextBox_Delta;
        private System.Windows.Forms.TextBox TextBox_Price;
        private System.Windows.Forms.TextBox TextBox_Time;
        private System.Windows.Forms.Button Button_Sample;
        private System.Windows.Forms.Button Button_Go;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;
        private System.Windows.Forms.ErrorProvider errorProvider5;
        private System.Windows.Forms.ErrorProvider errorProvider6;
        private System.Windows.Forms.ErrorProvider errorProvider7;
        private System.Windows.Forms.Label label_bar;
        private System.Windows.Forms.TextBox TextBox_Cores;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox checkBox_MT;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label19;
    }
}

