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
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message, ex.StackTrace);
                MessageBox.Show("The app could not be closed");
            }
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                //throw new Exception("Game could not start. Try again later.");

                Cleanup();

                Game = new Game();

                Game.Initialize();

                Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);

                this.Controls.Add(Game.Board);

                Game.Start();

            }
            catch (Exception ex)
            {
                //log
                Logger.Log(ex.Message, ex.StackTrace);
                //inform user MessageBox
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                Game?.Board?.Reshape(Width, Height - 40, GameToolstrip.Height);
                throw new Exception("Can not resize");
            }
            catch (Exception ex)
            {
                //log
                Logger.Log(ex.Message, ex.StackTrace);
            }
        }

        private void Cleanup()
        {
            if (Game != null && Game.Board != null)
            {
                Game.Cleanup();
                Controls.Remove(Game.Board);
                Game.Board = null;
            }
        }
    }
}
