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
            this.pPlayer1 = new System.Windows.Forms.Panel();
            this.pActive = new System.Windows.Forms.PictureBox();
            this.pPlayer3 = new System.Windows.Forms.Panel();
            this.pPlayer2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pActive)).BeginInit();
            this.SuspendLayout();
            // 
            // pPlayer1
            // 
            this.pPlayer1.Location = new System.Drawing.Point(310, 304);
            this.pPlayer1.Name = "pPlayer1";
            this.pPlayer1.Size = new System.Drawing.Size(466, 138);
            this.pPlayer1.TabIndex = 0;
            this.pPlayer1.Paint += new System.Windows.Forms.PaintEventHandler(this.pPlayer_Paint);
            // 
            // pActive
            // 
            this.pActive.Location = new System.Drawing.Point(904, 301);
            this.pActive.Name = "pActive";
            this.pActive.Size = new System.Drawing.Size(92, 141);
            this.pActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pActive.TabIndex = 3;
            this.pActive.TabStop = false;
            // 
            // pPlayer3
            // 
            this.pPlayer3.Location = new System.Drawing.Point(530, 12);
            this.pPlayer3.Name = "pPlayer3";
            this.pPlayer3.Size = new System.Drawing.Size(466, 138);
            this.pPlayer3.TabIndex = 4;
            this.pPlayer3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pPlayer2
            // 
            this.pPlayer2.Location = new System.Drawing.Point(12, 12);
            this.pPlayer2.Name = "pPlayer2";
            this.pPlayer2.Size = new System.Drawing.Size(466, 138);
            this.pPlayer2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 454);
            this.Controls.Add(this.pPlayer2);
            this.Controls.Add(this.pPlayer3);
            this.Controls.Add(this.pActive);
            this.Controls.Add(this.pPlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pActive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPlayer1;
        private System.Windows.Forms.PictureBox pActive;
        private System.Windows.Forms.Panel pPlayer3;
        private System.Windows.Forms.Panel pPlayer2;
    }
}

