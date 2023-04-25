namespace Bomberman
{
    partial class BombermanForm
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.aboutButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.retryLevelButton = new System.Windows.Forms.Button();
            this.nextLevelButton = new System.Windows.Forms.Button();
            this.restartGameButton = new System.Windows.Forms.Button();
            this.nicknameTextBox = new System.Windows.Forms.TextBox();
            this.nicknameCheckButton = new System.Windows.Forms.Button();
            this.statsLabel = new System.Windows.Forms.Label();
            this.levelResultsLabel = new System.Windows.Forms.Label();
            this.gameResultsLabel = new System.Windows.Forms.Label();
            this.scoresLabel = new System.Windows.Forms.Label();
            this.wonButton = new System.Windows.Forms.Button();
            this.loseButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.leaderboardLabel = new System.Windows.Forms.Label();
            this.aboutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.FlatAppearance.BorderSize = 0;
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startGameButton.Location = new System.Drawing.Point(216, 224);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(368, 168);
            this.startGameButton.TabIndex = 1;
            this.startGameButton.Text = "START GAME";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGame_Click);
            // 
            // homeButton
            // 
            this.homeButton.FlatAppearance.BorderSize = 0;
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.homeButton.Location = new System.Drawing.Point(648, 24);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(120, 48);
            this.homeButton.TabIndex = 2;
            this.homeButton.Text = "HOME";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.aboutButton.Location = new System.Drawing.Point(648, 24);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(120, 48);
            this.aboutButton.TabIndex = 3;
            this.aboutButton.Text = "ABOUT";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.FlatAppearance.BorderSize = 0;
            this.resumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resumeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resumeButton.Location = new System.Drawing.Point(280, 104);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(248, 72);
            this.resumeButton.TabIndex = 0;
            this.resumeButton.Text = "RESUME";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // retryLevelButton
            // 
            this.retryLevelButton.FlatAppearance.BorderSize = 0;
            this.retryLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retryLevelButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.retryLevelButton.Location = new System.Drawing.Point(280, 184);
            this.retryLevelButton.Name = "retryLevelButton";
            this.retryLevelButton.Size = new System.Drawing.Size(248, 72);
            this.retryLevelButton.TabIndex = 5;
            this.retryLevelButton.Text = "RETRY LEVEL";
            this.retryLevelButton.UseVisualStyleBackColor = true;
            this.retryLevelButton.Click += new System.EventHandler(this.retryLevelButton_Click);
            // 
            // nextLevelButton
            // 
            this.nextLevelButton.FlatAppearance.BorderSize = 0;
            this.nextLevelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextLevelButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextLevelButton.Location = new System.Drawing.Point(280, 264);
            this.nextLevelButton.Name = "nextLevelButton";
            this.nextLevelButton.Size = new System.Drawing.Size(248, 72);
            this.nextLevelButton.TabIndex = 6;
            this.nextLevelButton.Text = "NEXT LEVEL";
            this.nextLevelButton.UseVisualStyleBackColor = true;
            this.nextLevelButton.Click += new System.EventHandler(this.nextLevelButton_Click);
            // 
            // restartGameButton
            // 
            this.restartGameButton.FlatAppearance.BorderSize = 0;
            this.restartGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartGameButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.restartGameButton.Location = new System.Drawing.Point(280, 264);
            this.restartGameButton.Name = "restartGameButton";
            this.restartGameButton.Size = new System.Drawing.Size(248, 72);
            this.restartGameButton.TabIndex = 7;
            this.restartGameButton.Text = "RESTART GAME";
            this.restartGameButton.UseVisualStyleBackColor = true;
            this.restartGameButton.Click += new System.EventHandler(this.restartGameButton_Click);
            // 
            // nicknameTextBox
            // 
            this.nicknameTextBox.Location = new System.Drawing.Point(568, 192);
            this.nicknameTextBox.Name = "nicknameTextBox";
            this.nicknameTextBox.Size = new System.Drawing.Size(182, 31);
            this.nicknameTextBox.TabIndex = 0;
            this.nicknameTextBox.TextChanged += new System.EventHandler(this.nicknameTextBox_TextChanged);
            // 
            // nicknameCheckButton
            // 
            this.nicknameCheckButton.FlatAppearance.BorderSize = 0;
            this.nicknameCheckButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nicknameCheckButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nicknameCheckButton.Location = new System.Drawing.Point(568, 232);
            this.nicknameCheckButton.Name = "nicknameCheckButton";
            this.nicknameCheckButton.Size = new System.Drawing.Size(184, 34);
            this.nicknameCheckButton.TabIndex = 1;
            this.nicknameCheckButton.Text = "Confirm nickname";
            this.nicknameCheckButton.UseVisualStyleBackColor = true;
            this.nicknameCheckButton.Click += new System.EventHandler(this.nicknameCheckButton_Click);
            // 
            // statsLabel
            // 
            this.statsLabel.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statsLabel.Location = new System.Drawing.Point(352, 264);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(296, 123);
            this.statsLabel.TabIndex = 12;
            this.statsLabel.Text = "label1";
            // 
            // levelResultsLabel
            // 
            this.levelResultsLabel.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.levelResultsLabel.Location = new System.Drawing.Point(224, 40);
            this.levelResultsLabel.Name = "levelResultsLabel";
            this.levelResultsLabel.Size = new System.Drawing.Size(352, 120);
            this.levelResultsLabel.TabIndex = 13;
            this.levelResultsLabel.Text = "level results";
            this.levelResultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameResultsLabel
            // 
            this.gameResultsLabel.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameResultsLabel.Location = new System.Drawing.Point(288, 64);
            this.gameResultsLabel.Name = "gameResultsLabel";
            this.gameResultsLabel.Size = new System.Drawing.Size(232, 120);
            this.gameResultsLabel.TabIndex = 14;
            this.gameResultsLabel.Text = "game results";
            this.gameResultsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoresLabel
            // 
            this.scoresLabel.Font = new System.Drawing.Font("Cascadia Mono", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoresLabel.Location = new System.Drawing.Point(32, 128);
            this.scoresLabel.Name = "scoresLabel";
            this.scoresLabel.Size = new System.Drawing.Size(224, 288);
            this.scoresLabel.TabIndex = 15;
            this.scoresLabel.Text = "label1";
            // 
            // wonButton
            // 
            this.wonButton.FlatAppearance.BorderSize = 0;
            this.wonButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wonButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.wonButton.Location = new System.Drawing.Point(8, 64);
            this.wonButton.Name = "wonButton";
            this.wonButton.Size = new System.Drawing.Size(120, 48);
            this.wonButton.TabIndex = 21;
            this.wonButton.TabStop = false;
            this.wonButton.Text = "WIN";
            this.wonButton.UseVisualStyleBackColor = true;
            this.wonButton.Visible = false;
            this.wonButton.Click += new System.EventHandler(this.wonButton_Click);
            // 
            // loseButton
            // 
            this.loseButton.Enabled = false;
            this.loseButton.FlatAppearance.BorderSize = 0;
            this.loseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loseButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loseButton.Location = new System.Drawing.Point(8, 8);
            this.loseButton.Name = "loseButton";
            this.loseButton.Size = new System.Drawing.Size(120, 48);
            this.loseButton.TabIndex = 20;
            this.loseButton.Text = "LOSE";
            this.loseButton.UseVisualStyleBackColor = true;
            this.loseButton.Visible = false;
            this.loseButton.Click += new System.EventHandler(this.loseButton_Click);
            // 
            // okButton
            // 
            this.okButton.FlatAppearance.BorderSize = 0;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.okButton.Location = new System.Drawing.Point(320, 352);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(168, 64);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.Location = new System.Drawing.Point(136, 48);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(536, 168);
            this.welcomeLabel.TabIndex = 17;
            this.welcomeLabel.Text = "welcome to\r\nBOMBERMAN";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aboutPanel
            // 
            this.aboutPanel.Controls.Add(this.label13);
            this.aboutPanel.Controls.Add(this.label8);
            this.aboutPanel.Controls.Add(this.label7);
            this.aboutPanel.Controls.Add(this.label6);
            this.aboutPanel.Controls.Add(this.label5);
            this.aboutPanel.Controls.Add(this.label4);
            this.aboutPanel.Controls.Add(this.label12);
            this.aboutPanel.Controls.Add(this.label11);
            this.aboutPanel.Controls.Add(this.label10);
            this.aboutPanel.Controls.Add(this.label9);
            this.aboutPanel.Controls.Add(this.label3);
            this.aboutPanel.Controls.Add(this.label2);
            this.aboutPanel.Controls.Add(this.label1);
            this.aboutPanel.Location = new System.Drawing.Point(8, 8);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(784, 432);
            this.aboutPanel.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(144, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(480, 24);
            this.label13.TabIndex = 34;
            this.label13.Text = "most of the images are from the original Bomberman for NES";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(568, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 32);
            this.label8.TabIndex = 33;
            this.label8.Text = "..........................................";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(472, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 32);
            this.label7.TabIndex = 32;
            this.label7.Text = "..........................................";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(464, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 32);
            this.label6.TabIndex = 31;
            this.label6.Text = "..........................................";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(608, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 32);
            this.label5.TabIndex = 30;
            this.label5.Text = "..........................................";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(496, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 48);
            this.label4.TabIndex = 29;
            this.label4.Text = "CONTROLS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(656, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 32);
            this.label12.TabIndex = 28;
            this.label12.Text = "pause";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(480, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(264, 32);
            this.label11.TabIndex = 27;
            this.label11.Text = "place a land mine";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(520, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 32);
            this.label10.TabIndex = 26;
            this.label10.Text = "place a bomb";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(664, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 32);
            this.label9.TabIndex = 25;
            this.label9.Text = "move";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(440, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 208);
            this.label3.TabIndex = 19;
            this.label3.Text = "Arrows/ASWD\r\n\r\nB\r\n\r\nM\r\n\r\nSpacebar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(128, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 80);
            this.label2.TabIndex = 18;
            this.label2.Text = "BOMBERMAN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 296);
            this.label1.TabIndex = 15;
            this.label1.Text = "Use bombs to eighter kill all monsters or find a key and an exit.\r\n\r\nKill monster" +
    "s or find chests to gain additional score. Freezer will frozen monsters down.";
            // 
            // leaderboardLabel
            // 
            this.leaderboardLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leaderboardLabel.Location = new System.Drawing.Point(48, 72);
            this.leaderboardLabel.Name = "leaderboardLabel";
            this.leaderboardLabel.Size = new System.Drawing.Size(184, 55);
            this.leaderboardLabel.TabIndex = 22;
            this.leaderboardLabel.Text = "Leaderboard";
            this.leaderboardLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BombermanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.loseButton);
            this.Controls.Add(this.wonButton);
            this.Controls.Add(this.scoresLabel);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.nicknameCheckButton);
            this.Controls.Add(this.nicknameTextBox);
            this.Controls.Add(this.nextLevelButton);
            this.Controls.Add(this.retryLevelButton);
            this.Controls.Add(this.restartGameButton);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.levelResultsLabel);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.gameResultsLabel);
            this.Controls.Add(this.leaderboardLabel);
            this.Controls.Add(this.aboutPanel);
            this.KeyPreview = true;
            this.Name = "BombermanForm";
            this.Text = "Bomberman II";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BombermanForm_KeyUp);
            this.aboutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer;
        internal Label statsLabel;
        internal Button startGameButton;
        internal Button homeButton;
        internal Button aboutButton;
        internal Button retryLevelButton;
        internal Button nextLevelButton;
        internal TextBox nicknameTextBox;
        internal Button nicknameCheckButton;
        internal Label gameResultsLabel;
        internal Label scoresLabel;
        internal Button resumeButton;
        internal Label levelResultsLabel;
        internal Button restartGameButton;
        internal Button wonButton;
        internal Button loseButton;
        internal Button okButton;
        internal Label welcomeLabel;
        internal Panel aboutPanel;
        internal Label leaderboardLabel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label13;
    }
}