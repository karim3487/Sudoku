namespace Sudoku
{
    partial class NewGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewGameForm));
            this.inputName = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AdvancedLevel = new System.Windows.Forms.RadioButton();
            this.IntermediateLevel = new System.Windows.Forms.RadioButton();
            this.beginnerLevel = new System.Windows.Forms.RadioButton();
            this.startGame = new System.Windows.Forms.Button();
            this.recordsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputName
            // 
            this.inputName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputName.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputName.Location = new System.Drawing.Point(63, 141);
            this.inputName.MaxLength = 10;
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(201, 30);
            this.inputName.TabIndex = 2;
            this.inputName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Rubik", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(73, 106);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(184, 33);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Введите имя:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rubik", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(116, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Уровень";
            // 
            // AdvancedLevel
            // 
            this.AdvancedLevel.AutoSize = true;
            this.AdvancedLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdvancedLevel.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdvancedLevel.Location = new System.Drawing.Point(97, 261);
            this.AdvancedLevel.Margin = new System.Windows.Forms.Padding(2);
            this.AdvancedLevel.Name = "AdvancedLevel";
            this.AdvancedLevel.Size = new System.Drawing.Size(142, 23);
            this.AdvancedLevel.TabIndex = 5;
            this.AdvancedLevel.Text = "Профессионал";
            this.AdvancedLevel.UseVisualStyleBackColor = true;
            // 
            // IntermediateLevel
            // 
            this.IntermediateLevel.AutoSize = true;
            this.IntermediateLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IntermediateLevel.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IntermediateLevel.Location = new System.Drawing.Point(103, 238);
            this.IntermediateLevel.Margin = new System.Windows.Forms.Padding(2);
            this.IntermediateLevel.Name = "IntermediateLevel";
            this.IntermediateLevel.Size = new System.Drawing.Size(131, 23);
            this.IntermediateLevel.TabIndex = 6;
            this.IntermediateLevel.Text = "Продвинутый";
            this.IntermediateLevel.UseVisualStyleBackColor = true;
            // 
            // beginnerLevel
            // 
            this.beginnerLevel.AutoSize = true;
            this.beginnerLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beginnerLevel.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beginnerLevel.Location = new System.Drawing.Point(123, 217);
            this.beginnerLevel.Margin = new System.Windows.Forms.Padding(2);
            this.beginnerLevel.Name = "beginnerLevel";
            this.beginnerLevel.Size = new System.Drawing.Size(91, 23);
            this.beginnerLevel.TabIndex = 7;
            this.beginnerLevel.TabStop = true;
            this.beginnerLevel.Text = "Новичок";
            this.beginnerLevel.UseVisualStyleBackColor = true;
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(210)))), ((int)(((byte)(81)))));
            this.startGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGame.FlatAppearance.BorderSize = 0;
            this.startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGame.Font = new System.Drawing.Font("Rubik", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startGame.ForeColor = System.Drawing.Color.White;
            this.startGame.Location = new System.Drawing.Point(66, 289);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(201, 46);
            this.startGame.TabIndex = 10;
            this.startGame.Text = "Начать игру";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // recordsButton
            // 
            this.recordsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(0)))));
            this.recordsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.recordsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recordsButton.FlatAppearance.BorderSize = 0;
            this.recordsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordsButton.Font = new System.Drawing.Font("Rubik", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordsButton.ForeColor = System.Drawing.Color.White;
            this.recordsButton.Location = new System.Drawing.Point(88, 349);
            this.recordsButton.Name = "recordsButton";
            this.recordsButton.Size = new System.Drawing.Size(158, 40);
            this.recordsButton.TabIndex = 10;
            this.recordsButton.Text = "Рекорды";
            this.recordsButton.UseVisualStyleBackColor = false;
            this.recordsButton.Click += new System.EventHandler(this.recordsButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(306, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(334, 407);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.recordsButton);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdvancedLevel);
            this.Controls.Add(this.IntermediateLevel);
            this.Controls.Add(this.beginnerLevel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.inputName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewGameForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGameForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton AdvancedLevel;
        private System.Windows.Forms.RadioButton IntermediateLevel;
        private System.Windows.Forms.RadioButton beginnerLevel;
        public System.Windows.Forms.Button startGame;
        public System.Windows.Forms.Button recordsButton;
        private System.Windows.Forms.Label closeButton;
    }
}