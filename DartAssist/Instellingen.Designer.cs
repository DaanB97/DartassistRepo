namespace DartAssist
{
    partial class Instellingen
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
            this.tbSpeler1 = new System.Windows.Forms.TextBox();
            this.tbSpeler2 = new System.Windows.Forms.TextBox();
            this.btnBeginSpel = new System.Windows.Forms.Button();
            this.rb301P1 = new System.Windows.Forms.RadioButton();
            this.rb501P1 = new System.Windows.Forms.RadioButton();
            this.rb701P1 = new System.Windows.Forms.RadioButton();
            this.gbSpelsoort = new System.Windows.Forms.GroupBox();
            this.gbBot = new System.Windows.Forms.GroupBox();
            this.gbSpel = new System.Windows.Forms.GroupBox();
            this.lblSpelLegs = new System.Windows.Forms.Label();
            this.lblSpelSets = new System.Windows.Forms.Label();
            this.nudLegs = new System.Windows.Forms.NumericUpDown();
            this.nudSets = new System.Windows.Forms.NumericUpDown();
            this.rbCostum = new System.Windows.Forms.RadioButton();
            this.tbCostum = new System.Windows.Forms.TextBox();
            this.gbSpelsoort.SuspendLayout();
            this.gbSpel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLegs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSets)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speler 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Speler 2";
            // 
            // tbSpeler1
            // 
            this.tbSpeler1.Location = new System.Drawing.Point(27, 57);
            this.tbSpeler1.Name = "tbSpeler1";
            this.tbSpeler1.Size = new System.Drawing.Size(100, 20);
            this.tbSpeler1.TabIndex = 2;
            this.tbSpeler1.Text = "Speler1";
            // 
            // tbSpeler2
            // 
            this.tbSpeler2.Location = new System.Drawing.Point(232, 57);
            this.tbSpeler2.Name = "tbSpeler2";
            this.tbSpeler2.Size = new System.Drawing.Size(100, 20);
            this.tbSpeler2.TabIndex = 3;
            this.tbSpeler2.Text = "Speler2";
            // 
            // btnBeginSpel
            // 
            this.btnBeginSpel.Location = new System.Drawing.Point(27, 301);
            this.btnBeginSpel.Name = "btnBeginSpel";
            this.btnBeginSpel.Size = new System.Drawing.Size(75, 23);
            this.btnBeginSpel.TabIndex = 4;
            this.btnBeginSpel.Text = "Begin spel";
            this.btnBeginSpel.UseVisualStyleBackColor = true;
            this.btnBeginSpel.Click += new System.EventHandler(this.btnBeginSpel_Click);
            // 
            // rb301P1
            // 
            this.rb301P1.AutoSize = true;
            this.rb301P1.Location = new System.Drawing.Point(6, 19);
            this.rb301P1.Name = "rb301P1";
            this.rb301P1.Size = new System.Drawing.Size(43, 17);
            this.rb301P1.TabIndex = 5;
            this.rb301P1.TabStop = true;
            this.rb301P1.Text = "301";
            this.rb301P1.UseVisualStyleBackColor = true;
            // 
            // rb501P1
            // 
            this.rb501P1.AutoSize = true;
            this.rb501P1.Location = new System.Drawing.Point(6, 42);
            this.rb501P1.Name = "rb501P1";
            this.rb501P1.Size = new System.Drawing.Size(43, 17);
            this.rb501P1.TabIndex = 6;
            this.rb501P1.TabStop = true;
            this.rb501P1.Text = "501";
            this.rb501P1.UseVisualStyleBackColor = true;
            // 
            // rb701P1
            // 
            this.rb701P1.AutoSize = true;
            this.rb701P1.Location = new System.Drawing.Point(6, 65);
            this.rb701P1.Name = "rb701P1";
            this.rb701P1.Size = new System.Drawing.Size(43, 17);
            this.rb701P1.TabIndex = 7;
            this.rb701P1.TabStop = true;
            this.rb701P1.Text = "701";
            this.rb701P1.UseVisualStyleBackColor = true;
            // 
            // gbSpelsoort
            // 
            this.gbSpelsoort.Controls.Add(this.tbCostum);
            this.gbSpelsoort.Controls.Add(this.rbCostum);
            this.gbSpelsoort.Controls.Add(this.rb301P1);
            this.gbSpelsoort.Controls.Add(this.rb701P1);
            this.gbSpelsoort.Controls.Add(this.rb501P1);
            this.gbSpelsoort.Location = new System.Drawing.Point(27, 83);
            this.gbSpelsoort.Name = "gbSpelsoort";
            this.gbSpelsoort.Size = new System.Drawing.Size(146, 133);
            this.gbSpelsoort.TabIndex = 8;
            this.gbSpelsoort.TabStop = false;
            this.gbSpelsoort.Text = "Spelsoort";
            // 
            // gbBot
            // 
            this.gbBot.Location = new System.Drawing.Point(199, 83);
            this.gbBot.Name = "gbBot";
            this.gbBot.Size = new System.Drawing.Size(200, 133);
            this.gbBot.TabIndex = 9;
            this.gbBot.TabStop = false;
            this.gbBot.Text = "Bot";
            // 
            // gbSpel
            // 
            this.gbSpel.Controls.Add(this.nudSets);
            this.gbSpel.Controls.Add(this.nudLegs);
            this.gbSpel.Controls.Add(this.lblSpelSets);
            this.gbSpel.Controls.Add(this.lblSpelLegs);
            this.gbSpel.Location = new System.Drawing.Point(27, 222);
            this.gbSpel.Name = "gbSpel";
            this.gbSpel.Size = new System.Drawing.Size(372, 73);
            this.gbSpel.TabIndex = 10;
            this.gbSpel.TabStop = false;
            this.gbSpel.Text = "Spel";
            // 
            // lblSpelLegs
            // 
            this.lblSpelLegs.AutoSize = true;
            this.lblSpelLegs.Location = new System.Drawing.Point(6, 20);
            this.lblSpelLegs.Name = "lblSpelLegs";
            this.lblSpelLegs.Size = new System.Drawing.Size(36, 13);
            this.lblSpelLegs.TabIndex = 0;
            this.lblSpelLegs.Text = "Legs :";
            // 
            // lblSpelSets
            // 
            this.lblSpelSets.AutoSize = true;
            this.lblSpelSets.Location = new System.Drawing.Point(180, 20);
            this.lblSpelSets.Name = "lblSpelSets";
            this.lblSpelSets.Size = new System.Drawing.Size(34, 13);
            this.lblSpelSets.TabIndex = 1;
            this.lblSpelSets.Text = "Sets :";
            // 
            // nudLegs
            // 
            this.nudLegs.Location = new System.Drawing.Point(48, 18);
            this.nudLegs.Name = "nudLegs";
            this.nudLegs.Size = new System.Drawing.Size(98, 20);
            this.nudLegs.TabIndex = 2;
            // 
            // nudSets
            // 
            this.nudSets.Location = new System.Drawing.Point(220, 18);
            this.nudSets.Name = "nudSets";
            this.nudSets.Size = new System.Drawing.Size(98, 20);
            this.nudSets.TabIndex = 3;
            // 
            // rbCostum
            // 
            this.rbCostum.AutoSize = true;
            this.rbCostum.Location = new System.Drawing.Point(6, 88);
            this.rbCostum.Name = "rbCostum";
            this.rbCostum.Size = new System.Drawing.Size(60, 17);
            this.rbCostum.TabIndex = 8;
            this.rbCostum.TabStop = true;
            this.rbCostum.Text = "Costum";
            this.rbCostum.UseVisualStyleBackColor = true;
            // 
            // tbCostum
            // 
            this.tbCostum.Location = new System.Drawing.Point(6, 107);
            this.tbCostum.Name = "tbCostum";
            this.tbCostum.Size = new System.Drawing.Size(100, 20);
            this.tbCostum.TabIndex = 9;
            // 
            // Instellingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 348);
            this.Controls.Add(this.gbSpel);
            this.Controls.Add(this.gbBot);
            this.Controls.Add(this.gbSpelsoort);
            this.Controls.Add(this.btnBeginSpel);
            this.Controls.Add(this.tbSpeler2);
            this.Controls.Add(this.tbSpeler1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Instellingen";
            this.Text = "Instellingen";
            this.gbSpelsoort.ResumeLayout(false);
            this.gbSpelsoort.PerformLayout();
            this.gbSpel.ResumeLayout(false);
            this.gbSpel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLegs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSpeler1;
        private System.Windows.Forms.TextBox tbSpeler2;
        private System.Windows.Forms.Button btnBeginSpel;
        private System.Windows.Forms.RadioButton rb301P1;
        private System.Windows.Forms.RadioButton rb501P1;
        private System.Windows.Forms.RadioButton rb701P1;
        private System.Windows.Forms.GroupBox gbSpelsoort;
        private System.Windows.Forms.TextBox tbCostum;
        private System.Windows.Forms.RadioButton rbCostum;
        private System.Windows.Forms.GroupBox gbBot;
        private System.Windows.Forms.GroupBox gbSpel;
        private System.Windows.Forms.NumericUpDown nudSets;
        private System.Windows.Forms.NumericUpDown nudLegs;
        private System.Windows.Forms.Label lblSpelSets;
        private System.Windows.Forms.Label lblSpelLegs;
    }
}