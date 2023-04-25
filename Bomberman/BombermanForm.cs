using System.Text;
using System.Windows.Forms.VisualStyles;
using Bomberman.Game;
using Bomberman.Level;

namespace Bomberman
{
    public partial class BombermanForm : Form
    {
        Phase phase;
        Game.Game? game;
        AppearanceManager appearanceManager;
       
        public BombermanForm()
        {
            InitializeComponent();
            appearanceManager = new(this);

            SetPhase(Phase.home);
        }

        #region CONTROLS INTERACTION

        private void startGame_Click(object sender, EventArgs e)
        {
            game = new Game.Game(this);
            game.StartNextLevel();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            SetPhase(Phase.home);
        }
        private void aboutButton_Click(object sender, EventArgs e)
        {
            SetPhase(Phase.about);
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            SetPhase(Phase.level);
        }
        private void retryLevelButton_Click(object sender, EventArgs e)
        {
            game.RetryLevel();
        }
        private void nextLevelButton_Click(object sender, EventArgs e)
        {
            game.AddLevelScore();
            game.StartNextLevel();
        }

        private void restartGameButton_Click(object sender, EventArgs e)
        {
            this.game = new Game.Game(this);
            game.StartNextLevel();
        }

        private void nicknameCheckButton_Click(object sender, EventArgs e)
        {
            game.SetNickname(nicknameTextBox.Text);
            nicknameTextBox.Text = "";

            appearanceManager.DisableRetryAndNicknameAfterNicknameSet();

            scoresLabel.Text = game.PrintTopScores(10);
            game.SaveScores();
        }

        private void nicknameTextBox_TextChanged(object sender, EventArgs e)
        {
            appearanceManager.DisableOrEnableNicknameButton(game.IsNickNameOK(nicknameTextBox.Text));
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            appearanceManager.SetPhaseAppearance(phase, game);
        }
        #endregion

        #region KEYS RESPONSES

        /// <summary>
        /// If a level is running, passes key information down to level through game.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (phase == Phase.level)
            {
                if (keyData == Keys.Space)
                {
                    SetPhase(Phase.pause);
                    return true;
                }
                if (keyData == Keys.Up || keyData == Keys.W)
                {
                    game.PassKeyDownInfo(Game.KeyDown.Up);
                    return true;
                }
                if (keyData == Keys.Down || keyData == Keys.S)
                {
                    game.PassKeyDownInfo(Game.KeyDown.Down);
                    return true;
                }
                if (keyData == Keys.Left || keyData == Keys.A)
                {
                    game.PassKeyDownInfo(Game.KeyDown.Left);
                    return true;
                }
                if (keyData == Keys.Right || keyData == Keys.D)
                {
                    game.PassKeyDownInfo(Game.KeyDown.Right);
                    return true;
                }
                if (keyData == Keys.B)
                {
                    game.PassKeyDownInfo(Game.KeyDown.B);
                    return true;
                }
                if (keyData == Keys.M)
                {
                    game.PassKeyDownInfo(Game.KeyDown.M);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BombermanForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (game is not null)
            {
                game.PassKeyDownInfo(Game.KeyDown.None);
            }
        }
        #endregion

        /// <summary>
        /// When timer ticks, entities in level take the next step.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void timer_Tick(object sender, EventArgs e)
        {
            game.Tick(); 
            statsLabel.Text = game.PrintStats();
        }

        #region SET PHASE FUNCIONALITY

        /// 
        /// <summary>
        /// Change the phase of the game - change functionality and appereance of the window accordingly using AppearanceManager.
        /// </summary>
        /// <param name="phase">Phase to be set.</param>
        internal void SetPhase(Phase phase)
        {
            this.phase = phase;

            appearanceManager.PrintResults(phase, game);

            if (phase == Phase.gameLost || phase == Phase.levelLost)
            {
                appearanceManager.WaitIfLost(game);
                return;
            }
            appearanceManager.SetPhaseAppearance(phase, game);

            SetTimer(phase);
        }

        /// 
        /// <summary>
        /// Set timer functionality according to the parameter <paramref name="phase"/>
        /// </summary>
        /// <param name="phase">According to this parameter, the timer functionality will be changed.</param>
        void SetTimer(Phase phase)
        {
            switch (phase)
            {
                case Phase.home:
                    timer.Enabled = false;
                    break;
                case Phase.level:
                    timer.Enabled = true;
                    break;
                case Phase.pause:
                    timer.Enabled = false;
                    break;
                case Phase.levelWon:
                    timer.Enabled = false;
                    break;
                case Phase.levelLost:
                    timer.Enabled = false;
                    break;
                case Phase.gameWon:
                    timer.Enabled = false;
                    break;
                case Phase.gameLost:
                    timer.Enabled = false;
                    break;
                case Phase.about:
                    timer.Enabled = false;
                    break;
            }
        }

        #endregion

        // todo remove
        private void loseButton_Click(object sender, EventArgs e)
        {
            game.setLost();
        }

        private void wonButton_Click(object sender, EventArgs e)
        {
            game.setWon();
        }
    }
}