namespace Clicker
{
    partial class PlayerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CanselButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS PGothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 70);
            this.label1.MaximumSize = new System.Drawing.Size(400, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the names of the players";
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Font = new System.Drawing.Font("MS PGothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player1TextBox.Location = new System.Drawing.Point(90, 182);
            this.Player1TextBox.Multiline = true;
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(240, 38);
            this.Player1TextBox.TabIndex = 1;
            this.Player1TextBox.Text = "Player1";
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Font = new System.Drawing.Font("MS PGothic", 13.8F);
            this.Player2TextBox.Location = new System.Drawing.Point(488, 182);
            this.Player2TextBox.Multiline = true;
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(240, 38);
            this.Player2TextBox.TabIndex = 2;
            this.Player2TextBox.Text = "Player2";
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("MS PGothic", 13.8F);
            this.OkButton.Location = new System.Drawing.Point(190, 261);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(113, 41);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CanselButton
            // 
            this.CanselButton.Font = new System.Drawing.Font("MS PGothic", 13.8F);
            this.CanselButton.Location = new System.Drawing.Point(450, 261);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(113, 41);
            this.CanselButton.TabIndex = 4;
            this.CanselButton.Text = "Cancel";
            this.CanselButton.UseVisualStyleBackColor = true;
            this.CanselButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.label1);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CanselButton;
    }
}

