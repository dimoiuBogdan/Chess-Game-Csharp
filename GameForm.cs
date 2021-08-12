using System;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        private Game Game { get; set; }
        public GameSaver GameSaver { get; set; }
        public GameLoader GameLoader = new();

        public GameForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("The app could not be closed");
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Game == null)
                {
                    Game = new Game();
                    Game.Initialize();
                }

                GameSaver = new();

                Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);

                this.Controls.Add(Game.Board);

                Game.Start();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Game could not start");
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game != null && Game.Referee != null && Game.Referee.Context != null)
            {
                GameSaver.PopulateLayout(Game.Referee.Context);
            }

            if (GameSaver != null)
            {
                GameSaver.Save();
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Game == null)
            {
                Game = new Game();
                Game.Initialize();
            }

            if(Game.Referee.Context != null)
            {
                Game.Referee.Context = new();
                Game.Referee.Context.Layout = new();
            }

            GameLoader.Load(Game.Referee.Context);
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        private void Cleanup()
        {
            if (Game != null && Game.Board != null)
            {
                Game.Cleanup();
                Controls.Remove(Game.Board);
                GameSaver = null;
                GameLoader = null;
                Game.Board = null;
            }
        }
    }
}
