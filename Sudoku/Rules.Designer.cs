namespace Sudoku
{
    partial class Rules
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
            this.closeButton = new System.Windows.Forms.Label();
            this.rules_sud = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rules_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(459, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 26);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // rules_sud
            // 
            this.rules_sud.AutoSize = true;
            this.rules_sud.BackColor = System.Drawing.Color.Transparent;
            this.rules_sud.Font = new System.Drawing.Font("Rubik", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules_sud.Location = new System.Drawing.Point(187, 16);
            this.rules_sud.Name = "rules_sud";
            this.rules_sud.Size = new System.Drawing.Size(133, 33);
            this.rules_sud.TabIndex = 2;
            this.rules_sud.Text = "Правила";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Wheat;
            this.label1.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(470, 653);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // rules_button
            // 
            this.rules_button.BackColor = System.Drawing.Color.IndianRed;
            this.rules_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rules_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rules_button.FlatAppearance.BorderSize = 0;
            this.rules_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rules_button.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules_button.ForeColor = System.Drawing.Color.White;
            this.rules_button.Location = new System.Drawing.Point(199, 738);
            this.rules_button.Name = "rules_button";
            this.rules_button.Size = new System.Drawing.Size(106, 39);
            this.rules_button.TabIndex = 11;
            this.rules_button.Text = "OK";
            this.rules_button.UseVisualStyleBackColor = false;
            this.rules_button.Click += new System.EventHandler(this.rules_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 784);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 12;
            // 
            // Rules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(504, 473);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rules_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rules_sud);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Rules";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label rules_sud;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button rules_button;
        private System.Windows.Forms.Label label2;
    }
}