using System;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        private Game Game { get; set; }

        public GameForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cleanup();

            Game = new Game();

            Game?.Board?.Initialize();

            this.Controls.Add(Game.Board);

            Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
        }

        private void Cleanup()
        {
            if (Game?.Board != null)
            {
                Game.Board.Cleanup();
                this.Controls.Remove(Game.Board);
                Game.Board = null;
            }
        }
    }
}
