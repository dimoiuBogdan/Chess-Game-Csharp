using System;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        private Game Game { get; set; }
        public GameSaver GameSaver { get; set; }
        public GameLoader GameLoader { get; set; }

        public GameForm()
        {
            InitializeComponent();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cleanup();

                Game = new Game();
                Game.Initialize();

                Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
                Controls.Add(Game.Board);

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
            try
            {
                SaveFileDialog saveFileWindow = new()
                {
                    Filter = "json files (*.json)|*.json|All files (*.*)|*.*",
                    DefaultExt = "json",
                    FilterIndex = 1,
                    RestoreDirectory = true,
                    FileName = "Chess Game Context"
                };

                if (saveFileWindow.ShowDialog() == DialogResult.OK)
                {
                    Game?.Save(saveFileWindow.FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("The context could not be saved");
            }
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog openFileDialog = new();
                openFileDialog.InitialDirectory = "Desktop";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cleanup();

                    Game = new Game();
                    Game.Initialize();

                    Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
                    Controls.Add(Game.Board);

                    Game.Load(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show("Context could not be loaded");
            }
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

        private void ReplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using OpenFileDialog openFileDialog = new();
                openFileDialog.InitialDirectory = "Desktop";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cleanup();

                    Game = new Game();
                    Game.Initialize();

                    Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
                    Controls.Add(Game.Board);

                    Game.Replay(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                MessageBox.Show(ex.Message);
            }
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
