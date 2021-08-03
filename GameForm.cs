using System;
using System.IO;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class GameForm : Form
    {
        private Board Board { get; set; }

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

            Board = new Board();

            Board?.Initialize();

            this.Controls.Add(Board);

            Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
        }

        protected override void OnResize(EventArgs e)
        {
            Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
        }

        private void Cleanup()
        {
            if(Board != null)
            {
                Board.Cleanup();
                this.Controls.Remove(Board);
                Board = null;
            }
        }
    }
}
