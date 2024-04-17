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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.EnterPlayerNamesLable = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CanselButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnterPlayerNamesLable
            // 
            this.EnterPlayerNamesLable.AutoSize = true;
            this.EnterPlayerNamesLable.BackColor = System.Drawing.Color.Transparent;
            this.EnterPlayerNamesLable.Font = new System.Drawing.Font("Cascadia Mono", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterPlayerNamesLable.ForeColor = System.Drawing.SystemColors.Info;
            this.EnterPlayerNamesLable.Location = new System.Drawing.Point(254, 102);
            this.EnterPlayerNamesLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EnterPlayerNamesLable.MaximumSize = new System.Drawing.Size(450, 225);
            this.EnterPlayerNamesLable.Name = "EnterPlayerNamesLable";
            this.EnterPlayerNamesLable.Size = new System.Drawing.Size(385, 37);
            this.EnterPlayerNamesLable.TabIndex = 0;
            this.EnterPlayerNamesLable.Text = "Введите имена игроков :";
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1TextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Player1TextBox.Location = new System.Drawing.Point(204, 205);
            this.Player1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Player1TextBox.Multiline = true;
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(165, 42);
            this.Player1TextBox.TabIndex = 1;
            this.Player1TextBox.Text = "Игрок 1";
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Font = new System.Drawing.Font("Georgia", 13.8F);
            this.Player2TextBox.Location = new System.Drawing.Point(485, 205);
            this.Player2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Player2TextBox.Multiline = true;
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(165, 42);
            this.Player2TextBox.TabIndex = 2;
            this.Player2TextBox.Text = "Игрок 2";
            this.Player2TextBox.TextChanged += new System.EventHandler(this.Player2TextBox_TextChanged);
            // 
            // OkButton
            // 
            this.OkButton.Font = new System.Drawing.Font("Georgia", 13.8F);
            this.OkButton.Location = new System.Drawing.Point(233, 268);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(127, 46);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "ОК";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CanselButton
            // 
            this.CanselButton.Font = new System.Drawing.Font("Georgia", 13.8F);
            this.CanselButton.Location = new System.Drawing.Point(495, 268);
            this.CanselButton.Margin = new System.Windows.Forms.Padding(4);
            this.CanselButton.Name = "CanselButton";
            this.CanselButton.Size = new System.Drawing.Size(127, 46);
            this.CanselButton.TabIndex = 4;
            this.CanselButton.Text = "Выход";
            this.CanselButton.UseVisualStyleBackColor = true;
            this.CanselButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Clicker.Properties.Resources.playerformfon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 506);
            this.Controls.Add(this.CanselButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.EnterPlayerNamesLable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlayerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnterPlayerNamesLable;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CanselButton;
        private System.Windows.Forms.TextBox Player2TextBox;
    }
}

