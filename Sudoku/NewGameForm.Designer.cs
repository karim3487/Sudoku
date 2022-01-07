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
            this.AdvancedLevel = new System.Windows.Forms.RadioButton();
            this.IntermediateLevel = new System.Windows.Forms.RadioButton();
            this.beginnerLevel = new System.Windows.Forms.RadioButton();
            this.startGame = new System.Windows.Forms.Button();
            this.recordsButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Label();
            this.classic_mode = new System.Windows.Forms.RadioButton();
            this.even_odd_mode = new System.Windows.Forms.RadioButton();
            this.Mode = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rules_button = new System.Windows.Forms.Button();
            this.Mode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputName
            // 
            this.inputName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputName.Font = new System.Drawing.Font("Rubik", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputName.Location = new System.Drawing.Point(90, 146);
            this.inputName.MaxLength = 9;
            this.inputName.Name = "inputName";
            this.inputName.Size = new System.Drawing.Size(201, 30);
            this.inputName.TabIndex = 2;
            this.inputName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Rubik", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(100, 111);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(184, 33);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Введите имя:";
            // 
            // AdvancedLevel
            // 
            this.AdvancedLevel.AutoSize = true;
            this.AdvancedLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdvancedLevel.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdvancedLevel.Location = new System.Drawing.Point(14, 67);
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
            this.IntermediateLevel.Location = new System.Drawing.Point(14, 45);
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
            this.beginnerLevel.Location = new System.Drawing.Point(14, 23);
            this.beginnerLevel.Margin = new System.Windows.Forms.Padding(2);
            this.beginnerLevel.Name = "beginnerLevel";
            this.beginnerLevel.Size = new System.Drawing.Size(91, 23);
            this.beginnerLevel.TabIndex = 7;
            this.beginnerLevel.Text = "Новичок";
            this.beginnerLevel.UseVisualStyleBackColor = true;
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.LimeGreen;
            this.startGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGame.FlatAppearance.BorderSize = 0;
            this.startGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGame.Font = new System.Drawing.Font("Rubik", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startGame.ForeColor = System.Drawing.Color.White;
            this.startGame.Location = new System.Drawing.Point(29, 317);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(338, 50);
            this.startGame.TabIndex = 10;
            this.startGame.Text = "Начать игру";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // recordsButton
            // 
            this.recordsButton.BackColor = System.Drawing.Color.Orange;
            this.recordsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.recordsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.recordsButton.FlatAppearance.BorderSize = 0;
            this.recordsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordsButton.Font = new System.Drawing.Font("Rubik", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recordsButton.ForeColor = System.Drawing.Color.White;
            this.recordsButton.Location = new System.Drawing.Point(29, 384);
            this.recordsButton.Name = "recordsButton";
            this.recordsButton.Size = new System.Drawing.Size(160, 50);
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
            this.closeButton.Location = new System.Drawing.Point(367, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(28, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // classic_mode
            // 
            this.classic_mode.AutoSize = true;
            this.classic_mode.Checked = true;
            this.classic_mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.classic_mode.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.classic_mode.Location = new System.Drawing.Point(11, 26);
            this.classic_mode.Margin = new System.Windows.Forms.Padding(2);
            this.classic_mode.Name = "classic_mode";
            this.classic_mode.Size = new System.Drawing.Size(136, 23);
            this.classic_mode.TabIndex = 7;
            this.classic_mode.TabStop = true;
            this.classic_mode.Text = "Классический";
            this.classic_mode.UseVisualStyleBackColor = true;
            // 
            // even_odd_mode
            // 
            this.even_odd_mode.AutoSize = true;
            this.even_odd_mode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.even_odd_mode.Font = new System.Drawing.Font("Rubik", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.even_odd_mode.Location = new System.Drawing.Point(11, 67);
            this.even_odd_mode.Margin = new System.Windows.Forms.Padding(2);
            this.even_odd_mode.Name = "even_odd_mode";
            this.even_odd_mode.Size = new System.Drawing.Size(105, 23);
            this.even_odd_mode.TabIndex = 6;
            this.even_odd_mode.Text = "Чет-нечет";
            this.even_odd_mode.UseVisualStyleBackColor = true;
            // 
            // Mode
            // 
            this.Mode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Mode.Controls.Add(this.classic_mode);
            this.Mode.Controls.Add(this.even_odd_mode);
            this.Mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mode.Font = new System.Drawing.Font("Rubik", 14F);
            this.Mode.Location = new System.Drawing.Point(29, 198);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(160, 100);
            this.Mode.TabIndex = 11;
            this.Mode.TabStop = false;
            this.Mode.Text = "Режим";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IntermediateLevel);
            this.groupBox1.Controls.Add(this.beginnerLevel);
            this.groupBox1.Controls.Add(this.AdvancedLevel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Rubik", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(207, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень";
            // 
            // rules_button
            // 
            this.rules_button.BackColor = System.Drawing.Color.Orange;
            this.rules_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rules_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rules_button.FlatAppearance.BorderSize = 0;
            this.rules_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rules_button.Font = new System.Drawing.Font("Rubik", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rules_button.ForeColor = System.Drawing.Color.White;
            this.rules_button.Location = new System.Drawing.Point(207, 384);
            this.rules_button.Name = "rules_button";
            this.rules_button.Size = new System.Drawing.Size(160, 50);
            this.rules_button.TabIndex = 10;
            this.rules_button.Text = "Правила";
            this.rules_button.UseVisualStyleBackColor = false;
            this.rules_button.Click += new System.EventHandler(this.rules_button_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(394, 459);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.inputName);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.rules_button);
            this.Controls.Add(this.recordsButton);
            this.Controls.Add(this.startGame);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewGameForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGameForm_Paint);
            this.Mode.ResumeLayout(false);
            this.Mode.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox inputName;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.RadioButton AdvancedLevel;
        private System.Windows.Forms.RadioButton IntermediateLevel;
        private System.Windows.Forms.RadioButton beginnerLevel;
        public System.Windows.Forms.Button startGame;
        public System.Windows.Forms.Button recordsButton;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.RadioButton classic_mode;
        private System.Windows.Forms.RadioButton even_odd_mode;
        private System.Windows.Forms.GroupBox Mode;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button rules_button;
    }
}