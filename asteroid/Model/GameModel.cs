using asteroid.Persistance;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace asteroid.Model
{
    public enum GameDifficulty { Easy, Medium, Hard }

    internal class GameModel
    {
        #region Diff Const

        private const int astSpeedEasy = 10;
        private const int astSpeedMed = 25;
        private const int astSpeedHard = 35;
        int generTimeEasy = 8;
        int generTimeMed = 5;
        int generTimeHard = 3;
        #endregion

        #region Fields

        private Table _table; 
        private IDataAccess _dataAccess;
        private GameDifficulty _gameDifficulty; 
        private Int32 _astMove; 
        #endregion

        #region Properties

        public Int32 AstMove { get { return _astMove; } }
        public Boolean IsGameOver { get { return (_astMove == 0 || _table.IsFilled); } }
        public GameDifficulty GameDifficulty { get { return _gameDifficulty; } set { _gameDifficulty = value; } }

        #endregion

        #region Events

        public event EventHandler<EventArgs>? GameAdvanced;

        public event EventHandler<EventArgs>? GameOver;

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true && rocket.Left > 30)
            {
                rocket.Left -= playerSpeed;
            }
            if (goRight == true && rocket.Left < 600)
            {
                rocket.Left += playerSpeed;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Sudoku játék példányosítása.
        /// </summary>
        /// <param name="dataAccess">Az adatelérés.</param>
        public GameModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _gameDifficulty = GameDifficulty.Medium;
        }
        #endregion

        #region Public game methods

        private void RestartGame()
        {
            switch (_gameDifficulty) // nehézségfüggő beállítása az időnek, illetve a generált mezőknek
            {
                case GameDifficulty.Easy:
                    _astMove = astSpeedEasy;
                    GenerateAst(generTimeEasy);
                    break;
                case GameDifficulty.Medium:
                    _astMove = astSpeedMed;
                    GenerateAst(generTimeMed);
                    break;
                case GameDifficulty.Hard:
                    _astMove = astSpeedHard;
                    GenerateAst(generTimeHard);
                    break;
            }

            boom.Visible = false;
            btnStart.Enabled = false;
            goLeft = false;
            goRight = false;
            Score = 0;

            meteor1.Top = 0;
            int ap = asterPos.Next(300);
            meteor1.Left = ap;

            moon2.Top = 0;
            int ap1 = asterPos.Next(300, 500);
            moon2.Left = ap1;

            moveAster(10);

            _timer.Start();
            //gameTimeEvent();
        }

        public async Task LoadGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            _table = await _dataAccess.LoadAsync(path);

            switch (_gameDifficulty) // játékidő beállítása
            {
                case GameDifficulty.Easy:
                    _astMove = astSpeedEasy;
                    break;
                case GameDifficulty.Medium:
                    _astMove = astSpeedMed;
                    break;
                case GameDifficulty.Hard:
                    _astMove = astSpeedHard;
                    break;
            }
        }

        public async Task SaveGameAsync(String path)
        {
            if (_dataAccess == null)
                throw new InvalidOperationException("No data access is provided.");

            await _dataAccess.SaveAsync(path, _table);
        }
        #endregion

        #region Private game methods
        private void GenerAst(int gameTime)
        {
            //generate ast in random loc in time function
        }
        #endregion
    }
}
