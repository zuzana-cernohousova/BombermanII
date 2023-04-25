using Bomberman.Game;

namespace Bomberman
{
    /// <summary>
    /// Changes the sizes and colors of the form elements according to current game phase.
    /// </summary>
    internal class AppearanceManager
    {
        BombermanForm bf;

        public AppearanceManager(BombermanForm bf)
        {
            this.bf = bf;
        }

        /// <summary>
        /// Sets window appearance according to the <paramref name="phase"/> parameter.
        /// Appearance includes the size of the window, visibility of controls, which controls are enabled, colours of the window and controls.
        /// </summary>
        /// <param name="phase">Current phase the appearance should be changed according to.</param>
        /// <param name="game">Currently running game.</param>
        internal void SetPhaseAppearance(Phase phase, Game.Game game)
        {
            setColours(phase);
            setVisibleAndEnabled(phase);

            if (game is not null)
            {
                ResizeForm(phase, game);
                MoveButtons(phase, game);
                ShowOrHideLevelGraphics(phase, game);
            }
        }

        /// <summary>
        /// Sets control properties Visible and Enabled according to the <paramref name="phase"/> parameter.
        /// </summary>
        /// <param name="phase">Current phase.</param>
        void setVisibleAndEnabled(Phase phase)
        {
            switch (phase)
            {
                case Phase.home:
                    bf.startGameButton.Visible = true;
                    bf.startGameButton.Enabled = true;
                    bf.welcomeLabel.Visible = true;
                    bf.welcomeLabel.Enabled = true;
                    bf.homeButton.Visible = false;
                    bf.homeButton.Enabled = false;
                    bf.aboutButton.Visible = true;
                    bf.aboutButton.Enabled = true;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = false;
                    bf.retryLevelButton.Enabled = false;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = false;
                    bf.restartGameButton.Enabled = false;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.level:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = false;
                    bf.homeButton.Enabled = false;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = false;
                    bf.retryLevelButton.Enabled = false;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = false;
                    bf.restartGameButton.Enabled = false;
                    bf.statsLabel.Visible = true;
                    bf.statsLabel.Enabled = true;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.pause:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = true;
                    bf.resumeButton.Enabled = true;
                    bf.retryLevelButton.Visible = true;
                    bf.retryLevelButton.Enabled = true;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = false;
                    bf.restartGameButton.Enabled = false;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.levelWon:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = true;
                    bf.retryLevelButton.Enabled = true;
                    bf.nextLevelButton.Visible = true;
                    bf.nextLevelButton.Enabled = true;
                    bf.restartGameButton.Visible = false;
                    bf.restartGameButton.Enabled = false;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = true;
                    bf.levelResultsLabel.Enabled = true;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.levelLost:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = true;
                    bf.retryLevelButton.Enabled = true;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = true;
                    bf.restartGameButton.Enabled = true;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = true;
                    bf.levelResultsLabel.Enabled = true;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.gameWon:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = true;
                    bf.retryLevelButton.Enabled = true;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = true;
                    bf.restartGameButton.Enabled = true;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = true;
                    bf.nicknameTextBox.Enabled = true;
                    bf.nicknameCheckButton.Visible = true;
                    bf.nicknameCheckButton.Enabled = false; // first not able to write
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = true;
                    bf.gameResultsLabel.Enabled = true;
                    bf.scoresLabel.Visible = true;
                    bf.scoresLabel.Enabled = true;
                    bf.leaderboardLabel.Visible = true;
                    bf.leaderboardLabel.Enabled = true;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.gameLost:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = false;
                    bf.aboutPanel.Enabled = false;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = false;
                    bf.retryLevelButton.Enabled = false;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = true;
                    bf.restartGameButton.Enabled = true;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = true;
                    bf.gameResultsLabel.Enabled = true;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;


                case Phase.about:
                    bf.startGameButton.Visible = false;
                    bf.startGameButton.Enabled = false;
                    bf.welcomeLabel.Visible = false;
                    bf.welcomeLabel.Enabled = false;
                    bf.homeButton.Visible = true;
                    bf.homeButton.Enabled = true;
                    bf.aboutButton.Visible = false;
                    bf.aboutButton.Enabled = false;
                    bf.aboutPanel.Visible = true;
                    bf.aboutPanel.Enabled = true;
                    bf.resumeButton.Visible = false;
                    bf.resumeButton.Enabled = false;
                    bf.retryLevelButton.Visible = false;
                    bf.retryLevelButton.Enabled = false;
                    bf.nextLevelButton.Visible = false;
                    bf.nextLevelButton.Enabled = false;
                    bf.restartGameButton.Visible = false;
                    bf.restartGameButton.Enabled = false;
                    bf.statsLabel.Visible = false;
                    bf.statsLabel.Enabled = false;
                    bf.nicknameTextBox.Visible = false;
                    bf.nicknameTextBox.Enabled = false;
                    bf.nicknameCheckButton.Visible = false;
                    bf.nicknameCheckButton.Enabled = false;
                    bf.levelResultsLabel.Visible = false;
                    bf.levelResultsLabel.Enabled = false;
                    bf.gameResultsLabel.Visible = false;
                    bf.gameResultsLabel.Enabled = false;
                    bf.scoresLabel.Visible = false;
                    bf.scoresLabel.Enabled = false;
                    bf.leaderboardLabel.Visible = false;
                    bf.leaderboardLabel.Enabled = false;
                    bf.okButton.Visible = false;
                    bf.okButton.Enabled = false;
                    break;
            }
        }


        // used colours
        Color reddish = ColorTranslator.FromHtml("#FAC3C5");
        Color buttonReddish = ColorTranslator.FromHtml("#CE7B7D");
        Color greenish = ColorTranslator.FromHtml("#D7FDDE");
        Color buttonGreenish = ColorTranslator.FromHtml("#78CA86");
        //Color neutral = SystemColors.Control;
        Color neutral = ColorTranslator.FromHtml("#E6F6FF");
        Color buttonNeutral = ColorTranslator.FromHtml("#95C8EB");


        #region colours
        /// <summary>
        /// Set colours of the window according to <paramref name="phase"/>.
        /// </summary>
        /// <param name="phase"></param>
        private void setColours(Phase phase)
        {
            setBackColour(phase);
            setButtonsColours(phase);
        }

        void setBackColour(Phase phase)
        {
            switch (phase)
            {
                case Phase.home:
                    bf.BackColor = neutral;
                    break;
                case Phase.level:
                    bf.BackColor = neutral;
                    break;
                case Phase.pause:
                    bf.BackColor = neutral;
                    break;
                case Phase.levelWon:
                    bf.BackColor = greenish;
                    break;
                case Phase.levelLost:
                    bf.BackColor = reddish;
                    break;
                case Phase.gameWon:
                    bf.BackColor = greenish;
                    break;
                case Phase.gameLost:
                    bf.BackColor = reddish;
                    break;
                case Phase.about:
                    bf.BackColor = neutral;
                    break;
            }
        }
        void setButtonsColours(Phase phase)
        {
            switch (phase)
            {
                case Phase.home:
                    bf.startGameButton.BackColor = buttonNeutral;
                    bf.aboutButton.BackColor = buttonNeutral;
                    break;
                case Phase.pause:
                    bf.resumeButton.BackColor = buttonNeutral;
                    bf.retryLevelButton.BackColor = buttonNeutral;
                    bf.homeButton.BackColor = buttonNeutral;
                    break;
                case Phase.levelWon:
                    bf.retryLevelButton.BackColor = buttonGreenish;
                    bf.nextLevelButton.BackColor = buttonGreenish;
                    bf.homeButton.BackColor = buttonGreenish;

                    break;
                case Phase.levelLost:
                    bf.retryLevelButton.BackColor = buttonReddish;
                    bf.restartGameButton.BackColor = buttonReddish;

                    bf.homeButton.BackColor = buttonReddish;

                    break;
                case Phase.gameWon:
                    bf.retryLevelButton.BackColor = buttonGreenish;
                    bf.restartGameButton.BackColor = buttonGreenish;
                    bf.homeButton.BackColor = buttonGreenish;
                    bf.nicknameCheckButton.BackColor = buttonGreenish;

                    break;
                case Phase.gameLost:
                    bf.retryLevelButton.BackColor = buttonReddish;
                    bf.restartGameButton.BackColor = buttonReddish;
                    bf.homeButton.BackColor = buttonReddish;
                    break;
                case Phase.about:
                    bf.homeButton.BackColor = buttonNeutral;
                    break;
            }
        }
        #endregion

        #region resize
        /// <summary>
        /// Resizes form according to current <paramref name="game"/> (current level) or to default according to <paramref name="phase"/>.
        /// </summary>
        /// <param name="phase">Current phase</param>
        /// <param name="game">Running game</param>
        private void ResizeForm(Phase phase, Game.Game game)
        {
            if (phase == Phase.level || phase == Phase.pause)
            {
                ResizeFormAccordingToGame(game);
                MoveStatsLabel(game);
            }
            else { ResizeFormToDefault(); }
        }

        /// <summary>
        /// Resizes form to fixed values of 822x506
        /// </summary>
        private void ResizeFormToDefault()
        {
            bf.Size = new Size(822, 506);
        }

        /// <summary>
        /// Resizes form according to the size of current level extracted form <paramref name="game"/>. Leaves some margin.
        /// </summary>
        /// <param name="game">Running game.</param>
        private void ResizeFormAccordingToGame(Game.Game game)
        {
            (int mapHeight, int mapWidth) = game.GetMapHeightAndWidthInPixels();
            const int baseValue = 10;

            int formHeight = baseValue * 5 + mapHeight + bf.statsLabel.Height;
            int formWidth = baseValue * 5 + mapWidth;

            bf.Size = new Size(formWidth, formHeight);
        }

        #endregion

        #region move

        void MoveOKButton(Game.Game game)
        {
            (int mapHeight, _) = game.GetMapHeightAndWidthInPixels();

            int width = bf.Width - bf.okButton.Width - 50;

            bf.okButton.Location = new Point(
                       width,
                       30 + mapHeight
                       );
        }

        /// <summary>
        /// Moves label containing game statistics according to the size of current level, extracted from <paramref name="game"/>.
        /// </summary>
        /// <param name="game">Running game</param>
        private void MoveStatsLabel(Game.Game game)
        {
            (int mapHeight, _) = game.GetMapHeightAndWidthInPixels();

            bf.statsLabel.Location = new Point(
                       10,
                       10 + mapHeight
                       );
        }

        private void MoveButtons(Phase phase, Game.Game game)
        {
            if (phase == Phase.pause)
            {
                MoveButtonsInPause(game);

            }
            else
            {
                MoveButtonsToDefault();
            }
        }

        private void MoveButtonsToDefault()
        {
            bf.resumeButton.Location = new Point(280, 104);
            bf.retryLevelButton.Location = new Point(280, 184);
            bf.homeButton.Location = new Point(648, 24);
        }

        private void MoveButtonsInPause(Game.Game game)
        {
            (int mapHeight, _) = game.GetMapHeightAndWidthInPixels();
            int retryWidth = (bf.Width - bf.homeButton.Width) / 2 - 10;
            int resumeWidth = retryWidth - bf.resumeButton.Width - 10;


            bf.resumeButton.Location = new Point(
                resumeWidth, mapHeight + 30);
            bf.retryLevelButton.Location = new Point(
                retryWidth, mapHeight + 30);

            int homeHeight = mapHeight + 30 + (bf.restartGameButton.Height - bf.homeButton.Height) / 2;
            int homeWidth = bf.Width - bf.homeButton.Width - 50;

            bf.homeButton.Location = new Point(homeWidth, homeHeight);

        }

        #endregion

        #region nickname

        /// <summary>
        /// Hides the retry level button agter nickname is submitted
        /// </summary>
        internal void DisableRetryAndNicknameAfterNicknameSet()
        {
            bf.nicknameCheckButton.Enabled = false;
            bf.nicknameTextBox.Enabled = false;
            bf.retryLevelButton.Enabled = false;
        }

        /// <summary>
        /// Sets the Enabled property of the nicknameCheckButton control according to he <paramref name="enable"/> parameter and changes the color of the nicknameTextBox control.
        /// </summary>
        /// <param name="enable">Signifies weather nickname button should be enabled or disabled</param>
        internal void DisableOrEnableNicknameButton(bool enable)
        {
            if (enable)
            {
                bf.nicknameTextBox.BackColor = greenish;
                bf.nicknameCheckButton.Enabled = true;
            }
            else
            {
                bf.nicknameTextBox.BackColor = reddish;
                bf.nicknameCheckButton.Enabled = false;
            }
        }

        #endregion

        /// <summary>
        /// If current <paramref name="phase"/> is Phase.level shows level graphics, else hides it.
        /// </summary>
        /// <param name="phase">Current phase</param>
        /// <param name="game">Running game</param>
        void ShowOrHideLevelGraphics(Phase phase, Game.Game game)
        {
            if (phase == Phase.level || phase == Phase.pause) { game.ShowGameGraphics(); }
            else { game.HideGameGraphics(); }
        }

        /// <summary>
        /// Shows and enables an OK button that must be pressed in order to continue.
        /// This creates an opportunity for the player to look at his mistakes.
        /// </summary>
        /// <param name="game">Current game. Access is needed for OK button placement.</param>
        /// <returns></returns>
        internal void WaitIfLost(Game.Game game)
        {
            bf.okButton.Visible = true;
            bf.okButton.Enabled = true;

            bf.BackColor = reddish;
            bf.okButton.BackColor = buttonReddish;

            MoveOKButton(game);

            bf.timer.Enabled = false;
        }

        // todo extract from game
        /// <summary>
        /// Creates strings containing results of the game or level and puts them into corresponding labels to be visible to the user.
        /// </summary>
        /// <param name="phase">The phase of the game.</param>
        /// <param name="game">Current game. Acces to the game is needed so that the statistics of the game and level can be extracted.</param>
        internal void PrintResults(Phase phase, Game.Game? game)
        {
            if (game is not null)
            {
                game.PrintResults(phase);
            }
        }
    }
}
