namespace DebugTester
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
            this.btInit = new System.Windows.Forms.Button();
            this.btGame = new System.Windows.Forms.Button();
            this.btGameday = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.cbGameday = new System.Windows.Forms.ComboBox();
            this.cbAwayTeam = new System.Windows.Forms.ComboBox();
            this.cbHomeTeam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btInit
            // 
            this.btInit.Location = new System.Drawing.Point(12, 24);
            this.btInit.Name = "btInit";
            this.btInit.Size = new System.Drawing.Size(102, 23);
            this.btInit.TabIndex = 0;
            this.btInit.Text = "init()";
            this.btInit.UseVisualStyleBackColor = true;
            this.btInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btGame
            // 
            this.btGame.Location = new System.Drawing.Point(12, 53);
            this.btGame.Name = "btGame";
            this.btGame.Size = new System.Drawing.Size(102, 23);
            this.btGame.TabIndex = 1;
            this.btGame.Text = "analyseGame()";
            this.btGame.UseVisualStyleBackColor = true;
            this.btGame.Click += new System.EventHandler(this.button2_Click);
            // 
            // btGameday
            // 
            this.btGameday.Location = new System.Drawing.Point(12, 82);
            this.btGameday.Name = "btGameday";
            this.btGameday.Size = new System.Drawing.Size(102, 23);
            this.btGameday.TabIndex = 2;
            this.btGameday.Text = "analyseGameDay";
            this.btGameday.UseVisualStyleBackColor = true;
            this.btGameday.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 124);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(481, 234);
            this.tbOutput.TabIndex = 4;
            // 
            // cbGameday
            // 
            this.cbGameday.FormattingEnabled = true;
            this.cbGameday.Items.AddRange(new object[] {
            "Week 1",
            "Week 2",
            "Week 3",
            "Week 4",
            "Week 5",
            "Week 6",
            "Week 7",
            "Week 8",
            "Week 9",
            "Week 10",
            "Week 11",
            "Week 12",
            "Week 13",
            "Week 14",
            "Week 15",
            "Week 16",
            "Week 17"});
            this.cbGameday.Location = new System.Drawing.Point(120, 84);
            this.cbGameday.Name = "cbGameday";
            this.cbGameday.Size = new System.Drawing.Size(121, 21);
            this.cbGameday.TabIndex = 6;
            // 
            // cbAwayTeam
            // 
            this.cbAwayTeam.FormattingEnabled = true;
            this.cbAwayTeam.Location = new System.Drawing.Point(120, 55);
            this.cbAwayTeam.Name = "cbAwayTeam";
            this.cbAwayTeam.Size = new System.Drawing.Size(121, 21);
            this.cbAwayTeam.TabIndex = 7;
            // 
            // cbHomeTeam
            // 
            this.cbHomeTeam.FormattingEnabled = true;
            this.cbHomeTeam.Location = new System.Drawing.Point(283, 55);
            this.cbHomeTeam.Name = "cbHomeTeam";
            this.cbHomeTeam.Size = new System.Drawing.Size(121, 21);
            this.cbHomeTeam.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(247, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "@";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbHomeTeam);
            this.Controls.Add(this.cbAwayTeam);
            this.Controls.Add(this.cbGameday);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.btGameday);
            this.Controls.Add(this.btGame);
            this.Controls.Add(this.btInit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btInit;
        private System.Windows.Forms.Button btGame;
        private System.Windows.Forms.Button btGameday;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.ComboBox cbGameday;
        private System.Windows.Forms.ComboBox cbAwayTeam;
        private System.Windows.Forms.ComboBox cbHomeTeam;
        private System.Windows.Forms.Label label1;
    }
}

