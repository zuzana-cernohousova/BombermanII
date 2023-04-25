using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bomberman.Level;
using System.Diagnostics.Metrics;
using System.CodeDom;
using Bomberman.LevelVisualization;
using Bomberman.Properties;

namespace Bomberman.Game
{
    /// <summary>
    /// Loads and manages levels, counts total score and creates the leaderboard.
    /// </summary>
    internal class Game
    {
        BombermanForm bf;
        Level.Level currentLevel { get; set; }
        List<Level.Level> levels;
        int levelIndex = -1;

        GraphicMapPrinter gmp;

        int lives = 3;
        private bool lastLevel = false;

        private const string scoresFileName = "scores.txt";

        /// <summary>
        /// Represents the total amount of score accumulated from all the previous levels.
        /// </summary>
        public int Score { get; private set; }
        private string? nickname; // null if not yet enetered for this game
        Dictionary<string, int>? scores;

        public Game(BombermanForm bf)
        {
            this.bf = bf;
            levels = GetLevels();
        }


        /// <summary>
        /// Loads levels from the levels directory and returns and list of and <see cref="global::Bomberman.Level.Level"/> objects.
        /// </summary>
        /// <returns>List of levels.</returns>
        List<Level.Level> GetLevels()
        {
            List<Level.Level> levels = new();

            levels.Add(new Level.Level(new FileMapFactory("maps/emptymap.txt")));

            Random r = new Random(12);

            int start = r.Next(1234);
            for (int i = start; i < start + 10; i++)
            {
                //levels.Add(new Level.Level(new RandomMapFactory(i)));
            }

            return levels;
        }

        /// <summary>
        /// Sets current level to the next one in levels list, starts the level.
        /// </summary>
        public void StartNextLevel()
        {
            // create next level from next factory
            // put level in current level
            // play level

            levelIndex++;
            if (levelIndex < levels.Count)
            {
                currentLevel = levels[levelIndex];
                currentLevel.InitializeMap();

                CreateOrResetGMP();

                bf.SetPhase(Phase.level); // start ticking, set visibility

                if (levelIndex == levels.Count - 1)
                {
                    // last level
                    lastLevel = true;
                }
            }
        }

        /// <summary>
        /// Updates level, if level ended, sets the corresponding phase. 
        /// Updates pictures of entities in map.
        /// </summary>
        internal void Tick()
        {
            if (currentLevel.Won)
            {
                if (lastLevel)
                {
                    AddLevelScore();
                    bf.SetPhase(Phase.gameWon);
                    return;
                }

                bf.SetPhase(Phase.levelWon);
                return;
            }

            if (currentLevel.Lost)
            {
                lives -= 1;
                if (lives == 0)
                {
                    bf.SetPhase(Phase.gameLost);
                    return;
                }

                bf.SetPhase(Phase.levelLost);
                return;
            }

            // update level
            currentLevel.Tick();

            // print level
            gmp.UpdatePictures(currentLevel.map);
        }

        /// <summary>
        /// Adds level <see cref="Level.Level.Score"/> from current level to <see cref="Score"/> of the current game.
        /// </summary>
        public void AddLevelScore()
        {
            if (currentLevel is not null)
            {
                Score += currentLevel.Score;
            }
        }

        #region methods on level


        /// <summary>
        /// Restrarts last level and sets phase. If the score from level was added, substracts it.
        /// </summary>
        public void RetryLevel()
        {
            // subtract previously added score
            // only added if last time won and decided to retry
            // only in that case the score is added and needs to be substracted
            if (lastLevel && currentLevel.Won)
            {
                Score -= currentLevel.Score;
            }

            currentLevel.Reset();

            bf.timer_Tick(this, new EventArgs());
            // tick once so that everything will be in its place

            bf.SetPhase(Phase.level);
        }

        /// <summary>
        /// Updates information about pressed key in the current level
        /// </summary>
        /// <param name="key">Which key was pressed. If no key is pressed, use <see cref="KeyDown.None"/>.</param>
        public void PassKeyDownInfo(KeyDown key)
        {
            currentLevel.UpdateKeyInfo(key);
        }

        #endregion
        /// <summary>
        /// Creates a string containing the major statistics of the game including number of living monsters in the level, level score and lives left.
        /// </summary>
        /// <returns>A string containing game statistics.</returns>
        public string PrintStats()
        {
            int levelScore = currentLevel.Score;
            int monstersLeft = currentLevel.LivingMonsters;

            return "score:\t" + levelScore + Environment.NewLine + "monsters left:\t" + monstersLeft
                + Environment.NewLine + "lives left:\t" + lives;
        }

        /// <summary>
        /// Changes the Text property of the corresponding labels after level ended to display results of the game or the level.
        /// </summary>
        /// <param name="phase">Currnet phase</param>
        internal void PrintResults(Phase phase)
        {

            switch (phase)
            {
                case Phase.levelWon:
                    bf.levelResultsLabel.Text = PrintLevelResults(true);
                    break;
                case Phase.levelLost:
                    bf.levelResultsLabel.Text = PrintLevelResults(false);
                    break;

                case Phase.gameWon:

                    bf.gameResultsLabel.Text = PrintGameResults(true);

                    // print scores
                    if (scores is null)
                    {
                        LoadScores();
                    }
                    bf.scoresLabel.Text = PrintTopScores(12);

                    // todo print scores when home

                    break;
                case Phase.gameLost:
                    bf.gameResultsLabel.Text = PrintGameResults(false);
                    break;
            }
        }

        /// <summary>
        /// Creates and returns a <see cref="string"/> that sumarizes the level results.
        /// </summary>
        /// <param name="won">Signigies weather the player won or not</param>
        /// <returns>A <see cref="string"/> that sumarizes the level results.</returns>
        string PrintLevelResults(bool won)
        {
            if (won)
            {
                return "You WON this level" + Environment.NewLine + currentLevel.Score.ToString();
            }
            return "You LOST this level";
        }

        /// <summary>
        /// Creates and returns a <see cref="string"/> that sumarizes the game results.
        /// </summary>
        /// <param name="won">Signigies weather the player won or not</param>
        /// <returns>A <see cref="string"/> that sumarizes the game results.</returns>
        string PrintGameResults(bool won)
        {
            if (won)
            {
                return "! CONGRATS !" + Environment.NewLine + "score: " + Score.ToString();
            }
            return "GAME OVER";
        }

        #region scores
        /// <summary>
        /// Loads the top scores and nicknames from a file.
        /// Filename is stored in <see cref="scoresFileName"/>.
        /// If scores file is not found, scores will be set to <see langword="null"/>.
        /// </summary>
        void LoadScores()
        {
            Dictionary<string, int> res = new();

            try
            {
                using (StreamReader reader = new StreamReader(scoresFileName))
                {
                    string? line = reader.ReadLine();
                    while (line is not null)
                    {
                        line.Replace("\n", "");
                        string[] values = line.Split("\t");
                        res[values[0]] = int.Parse(values[1]);

                        line = reader.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                scores = null;
                return;
            }

            scores = res;
        }

        /// <summary>
        /// When scores are loaded and not empty, returns top <paramref name="numberOfScores"/> scores and nicknames in a <see cref="string"/>.
        /// If they are empty or not loaded, returns a special message.
        /// </summary>
        /// <param name="numberOfScores">How many top scores should be displayed</param>
        /// <returns><see cref="string"/> containing top <paramref name="numberOfScores"/> scores and nicknames</returns>
        internal string PrintTopScores(int numberOfScores)
        {
            const string noScoresYet = "No scores yet!";

            if (scores is null || scores.Count == 0)
            {
                return noScoresYet;
            }

            const int totalLength = 17;

            StringBuilder sb = new(10 * numberOfScores);
            int counter = 0;

            foreach (KeyValuePair<string, int> kvp in scores.OrderByDescending(key => key.Value))
            {

                int spacecount = totalLength - kvp.Key.Length - kvp.Value.ToString().Length;
                if (spacecount < 1) spacecount = 1;

                sb.Append(kvp.Key);

                for (int i = 0; i < spacecount; i++)
                {
                    sb.Append(" ");
                }
                sb.Append(kvp.Value.ToString());
                sb.Append("\n");

                counter++;
                if (counter == numberOfScores)
                {
                    break;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Saves best 2000 scores to file. Filename is stored in the <see cref="scoresFileName"/> field.
        /// </summary>
        internal void SaveScores()
        {
            if (nickname is null) // do not rewrite the scores if new nickname was not added
            {
                return;
            }
            if (scores is null) { return; }

            const int maxNumberOfScores = 2000;
            int counter = 0;

            scores[nickname] = Score;

            try
            {
                using (StreamWriter writer = new StreamWriter(scoresFileName))
                {
                    foreach (KeyValuePair<string, int> kvp in scores.OrderByDescending(key => key.Value))
                    {
                        writer.WriteLine("{0}\t{1}", kvp.Key, kvp.Value.ToString());

                        counter++;
                        if (counter == maxNumberOfScores)
                        {
                            break;
                        }
                    }
                }
            }
            catch (IOException) { }

            nickname = null;
        }

        #endregion

        #region nickname

        /// <summary>
        /// Sets nickname and attaches corresponding score.
        /// </summary>
        /// <param name="nickname"></param>
        public void SetNickname(string nickname)
        {
            this.nickname = nickname;

            if (scores is null)
            {
                scores = new();
            }

            if (scores.ContainsKey(nickname))
            {
                int currentScore = scores[nickname];

                if (Score > currentScore)
                {
                    scores[nickname] = Score;
                }
                return;
            }

            scores[nickname] = Score;
        }

        /// <summary>
        /// Determines weather the <paramref name="nickname"/> parameter is a suitable nickname.
        /// </summary>
        /// <param name="nickname">nickname about to be set</param>
        /// <returns><see langword="true"/> if <paramref name="nickname"/> is suitable, otherwise <see langword="false"/>.</returns>
        public bool IsNickNameOK(string nickname)
        {
            if (nickname.Equals("")) return false;
            if (nickname.Contains('\t')) return false;
            if (nickname.Length > 11) return false;

            return true;
        }
        #endregion

        #region graphics
        /// <summary>
        /// Resets <see cref="GraphicMapPrinter"/> <see cref="gmp"/>. It one already exists, removes all picture boxes from form.
        /// </summary>
        void CreateOrResetGMP()
        {
            if (gmp is not null) gmp.RemoveGraphicsFromForm();

            gmp = new GraphicMapPrinter(bf, currentLevel.Rows, currentLevel.Columns);
            gmp.AddGraphicsToForm();
        }

        /// <summary>
        /// Hides the level graphics.
        /// </summary>
        public void HideGameGraphics()
        {
            gmp.HideGraphics();
        }

        /// <summary>
        /// Shows the level graphics.
        /// </summary>
        public void ShowGameGraphics()
        { gmp.ShowGraphics(); }

        /// <summary>
        /// Returns the dimensions of level map in pixels
        /// </summary>
        /// <returns>A tupple of two ints, where the first int signifies the height and the second int signifies the width of the level map in pixels</returns>
        public (int, int) GetMapHeightAndWidthInPixels()
        { return gmp.GetSizeOfGame(); }

        #endregion

        // todo remove
        public void setWon()
        {
            currentLevel.setWon();
        }

        internal void setLost()
        {
            currentLevel.setLost();
        }
    }
}

