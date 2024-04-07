namespace BrickBreaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.restartTimer = new System.Windows.Forms.Timer(this.components);
            this.losePanel = new System.Windows.Forms.Panel();
            this.restartButton = new System.Windows.Forms.Button();
            this.lossTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.losePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 17;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(752, 397);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(702, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // restartTimer
            // 
            this.restartTimer.Interval = 2000;
            this.restartTimer.Tick += new System.EventHandler(this.restartTimer_Tick);
            // 
            // losePanel
            // 
            this.losePanel.Controls.Add(this.restartButton);
            this.losePanel.Controls.Add(this.lossTextbox);
            this.losePanel.Location = new System.Drawing.Point(47, 26);
            this.losePanel.Name = "losePanel";
            this.losePanel.Size = new System.Drawing.Size(660, 344);
            this.losePanel.TabIndex = 2;
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(287, 128);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(99, 34);
            this.restartButton.TabIndex = 1;
            this.restartButton.TabStop = false;
            this.restartButton.Text = "try again";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // lossTextbox
            // 
            this.lossTextbox.Enabled = false;
            this.lossTextbox.Location = new System.Drawing.Point(232, 44);
            this.lossTextbox.Name = "lossTextbox";
            this.lossTextbox.Size = new System.Drawing.Size(211, 23);
            this.lossTextbox.TabIndex = 0;
            this.lossTextbox.Text = "ur trash get good";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 397);
            this.Controls.Add(this.losePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.losePanel.ResumeLayout(false);
            this.losePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Label label1;
        private System.Windows.Forms.Timer restartTimer;
        private Panel losePanel;
        private Button restartButton;
        private TextBox lossTextbox;
    }
}