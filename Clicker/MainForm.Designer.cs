namespace Clicker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ScoreLabel1 = new System.Windows.Forms.Label();
            this.ScoreLabel2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PenaltyLabel = new System.Windows.Forms.Label();
            this.PenaltyColorBox = new System.Windows.Forms.PictureBox();
            this.topPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenaltyColorBox)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoreLabel1
            // 
            this.ScoreLabel1.AutoSize = true;
            this.ScoreLabel1.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.8F);
            this.ScoreLabel1.Location = new System.Drawing.Point(15, 10);
            this.ScoreLabel1.Name = "ScoreLabel1";
            this.ScoreLabel1.Size = new System.Drawing.Size(91, 23);
            this.ScoreLabel1.TabIndex = 0;
            this.ScoreLabel1.Text = "Player1 : 0";
            this.ScoreLabel1.Visible = false;
            // 
            // ScoreLabel2
            // 
            this.ScoreLabel2.AutoSize = true;
            this.ScoreLabel2.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel2.Location = new System.Drawing.Point(1605, 10);
            this.ScoreLabel2.Name = "ScoreLabel2";
            this.ScoreLabel2.Size = new System.Drawing.Size(91, 23);
            this.ScoreLabel2.TabIndex = 1;
            this.ScoreLabel2.Text = "Player2 : 0";
            this.ScoreLabel2.Visible = false;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(748, 339);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(271, 95);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(1472, 650);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(9, 14);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(360, 650);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(9, 14);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // PenaltyLabel
            // 
            this.PenaltyLabel.AutoSize = true;
            this.PenaltyLabel.Font = new System.Drawing.Font("Microsoft PhagsPa", 10.8F);
            this.PenaltyLabel.Location = new System.Drawing.Point(747, 9);
            this.PenaltyLabel.Name = "PenaltyLabel";
            this.PenaltyLabel.Size = new System.Drawing.Size(150, 23);
            this.PenaltyLabel.TabIndex = 5;
            this.PenaltyLabel.Text = "Штрафной цвет :";
            this.PenaltyLabel.Visible = false;
            // 
            // PenaltyColorBox
            // 
            this.PenaltyColorBox.BackColor = System.Drawing.Color.White;
            this.PenaltyColorBox.Location = new System.Drawing.Point(903, 9);
            this.PenaltyColorBox.Name = "PenaltyColorBox";
            this.PenaltyColorBox.Size = new System.Drawing.Size(48, 23);
            this.PenaltyColorBox.TabIndex = 6;
            this.PenaltyColorBox.TabStop = false;
            this.PenaltyColorBox.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Silver;
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topPanel.Controls.Add(this.PenaltyColorBox);
            this.topPanel.Controls.Add(this.ScoreLabel1);
            this.topPanel.Controls.Add(this.PenaltyLabel);
            this.topPanel.Controls.Add(this.ScoreLabel2);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1837, 45);
            this.topPanel.TabIndex = 7;
            this.topPanel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1837, 856);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenaltyColorBox)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label ScoreLabel1;
        private System.Windows.Forms.Label ScoreLabel2;
        private System.Windows.Forms.Label PenaltyLabel;
        private System.Windows.Forms.PictureBox PenaltyColorBox;
        private System.Windows.Forms.Panel topPanel;
    }
}