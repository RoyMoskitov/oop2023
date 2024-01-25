namespace WindowsFormsAppGame
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InventoryButton = new System.Windows.Forms.Button();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.TakeItemButton = new System.Windows.Forms.Button();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.ShootEnemyButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.OdLabel = new System.Windows.Forms.Label();
            this.AmmoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // InventoryButton
            // 
            this.InventoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InventoryButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InventoryButton.Location = new System.Drawing.Point(800, 20);
            this.InventoryButton.Name = "InventoryButton";
            this.InventoryButton.Size = new System.Drawing.Size(180, 80);
            this.InventoryButton.TabIndex = 9;
            this.InventoryButton.Text = "Open Inventory";
            this.InventoryButton.UseVisualStyleBackColor = true;
            this.InventoryButton.UseWaitCursor = true;
            this.InventoryButton.Click += new System.EventHandler(this.InventoryButton_Click);
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EndTurnButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTurnButton.Location = new System.Drawing.Point(800, 145);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(180, 80);
            this.EndTurnButton.TabIndex = 10;
            this.EndTurnButton.Text = "End Turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.UseWaitCursor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // TakeItemButton
            // 
            this.TakeItemButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TakeItemButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TakeItemButton.Location = new System.Drawing.Point(800, 278);
            this.TakeItemButton.Name = "TakeItemButton";
            this.TakeItemButton.Size = new System.Drawing.Size(180, 80);
            this.TakeItemButton.TabIndex = 11;
            this.TakeItemButton.Text = "Take Items ";
            this.TakeItemButton.UseVisualStyleBackColor = true;
            this.TakeItemButton.UseWaitCursor = true;
            this.TakeItemButton.Click += new System.EventHandler(this.TakeItemButton_Click);
            // 
            // ReloadButton
            // 
            this.ReloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReloadButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadButton.Location = new System.Drawing.Point(800, 417);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(180, 80);
            this.ReloadButton.TabIndex = 12;
            this.ReloadButton.Text = "Reload weapon";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.UseWaitCursor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // ShootEnemyButton
            // 
            this.ShootEnemyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShootEnemyButton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShootEnemyButton.Location = new System.Drawing.Point(800, 547);
            this.ShootEnemyButton.Name = "ShootEnemyButton";
            this.ShootEnemyButton.Size = new System.Drawing.Size(180, 80);
            this.ShootEnemyButton.TabIndex = 13;
            this.ShootEnemyButton.Text = "Shoot enemy";
            this.ShootEnemyButton.UseVisualStyleBackColor = true;
            this.ShootEnemyButton.UseWaitCursor = true;
            this.ShootEnemyButton.Click += new System.EventHandler(this.ShootEnemyButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox2.Location = new System.Drawing.Point(205, 208);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.UseWaitCursor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.IndianRed;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressBar1.Location = new System.Drawing.Point(1110, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 37);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            this.progressBar1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(1137, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 35);
            this.label1.TabIndex = 16;
            this.label1.Text = "Enemy HP";
            this.label1.UseWaitCursor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.Color.IndianRed;
            this.progressBar2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressBar2.Location = new System.Drawing.Point(1388, 76);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(209, 37);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 17;
            this.progressBar2.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(1371, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 35);
            this.label2.TabIndex = 18;
            this.label2.Text = "Character HP";
            this.label2.UseWaitCursor = true;
            // 
            // OdLabel
            // 
            this.OdLabel.AutoSize = true;
            this.OdLabel.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OdLabel.Location = new System.Drawing.Point(1110, 223);
            this.OdLabel.Name = "OdLabel";
            this.OdLabel.Size = new System.Drawing.Size(138, 35);
            this.OdLabel.TabIndex = 19;
            this.OdLabel.Text = "OdLabel";
            // 
            // AmmoLabel
            // 
            this.AmmoLabel.AutoSize = true;
            this.AmmoLabel.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmmoLabel.Location = new System.Drawing.Point(1110, 323);
            this.AmmoLabel.Name = "AmmoLabel";
            this.AmmoLabel.Size = new System.Drawing.Size(111, 35);
            this.AmmoLabel.TabIndex = 20;
            this.AmmoLabel.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1774, 1344);
            this.Controls.Add(this.AmmoLabel);
            this.Controls.Add(this.OdLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ShootEnemyButton);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.TakeItemButton);
            this.Controls.Add(this.EndTurnButton);
            this.Controls.Add(this.InventoryButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Divinty Original sin 3: Beta version";
            this.UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button InventoryButton;
        private System.Windows.Forms.Button EndTurnButton;
        private System.Windows.Forms.Button TakeItemButton;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Button ShootEnemyButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label OdLabel;
        private System.Windows.Forms.Label AmmoLabel;
    }
}

