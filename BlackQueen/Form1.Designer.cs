namespace TurnTest
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
            this.pPlayer = new System.Windows.Forms.Panel();
            this.pTable = new System.Windows.Forms.Panel();
            this.pDeck = new System.Windows.Forms.Panel();
            this.pActive = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pActive)).BeginInit();
            this.SuspendLayout();
            // 
            // pPlayer
            // 
            this.pPlayer.Location = new System.Drawing.Point(151, 300);
            this.pPlayer.Name = "pPlayer";
            this.pPlayer.Size = new System.Drawing.Size(466, 138);
            this.pPlayer.TabIndex = 0;
            // 
            // pTable
            // 
            this.pTable.Location = new System.Drawing.Point(151, 38);
            this.pTable.Name = "pTable";
            this.pTable.Size = new System.Drawing.Size(466, 239);
            this.pTable.TabIndex = 1;
            // 
            // pDeck
            // 
            this.pDeck.Location = new System.Drawing.Point(12, 38);
            this.pDeck.Name = "pDeck";
            this.pDeck.Size = new System.Drawing.Size(134, 239);
            this.pDeck.TabIndex = 2;
            // 
            // pActive
            // 
            this.pActive.Location = new System.Drawing.Point(677, 38);
            this.pActive.Name = "pActive";
            this.pActive.Size = new System.Drawing.Size(100, 239);
            this.pActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pActive.TabIndex = 3;
            this.pActive.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pActive);
            this.Controls.Add(this.pDeck);
            this.Controls.Add(this.pTable);
            this.Controls.Add(this.pPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPlayer;
        private System.Windows.Forms.Panel pTable;
        private System.Windows.Forms.Panel pDeck;
        private System.Windows.Forms.PictureBox pActive;
    }
}

