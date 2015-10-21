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
            this.btnBeginSpel.Location = new System.Drawing.Point(167, 245);
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
            this.rb301P1.Location = new System.Drawing.Point(154, 101);
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
            this.rb501P1.Location = new System.Drawing.Point(154, 124);
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
            this.rb701P1.Location = new System.Drawing.Point(154, 147);
            this.rb701P1.Name = "rb701P1";
            this.rb701P1.Size = new System.Drawing.Size(43, 17);
            this.rb701P1.TabIndex = 7;
            this.rb701P1.TabStop = true;
            this.rb701P1.Text = "701";
            this.rb701P1.UseVisualStyleBackColor = true;
            // 
            // Instellingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 348);
            this.Controls.Add(this.rb701P1);
            this.Controls.Add(this.rb501P1);
            this.Controls.Add(this.rb301P1);
            this.Controls.Add(this.btnBeginSpel);
            this.Controls.Add(this.tbSpeler2);
            this.Controls.Add(this.tbSpeler1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Instellingen";
            this.Text = "Instellingen";
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
    }
}