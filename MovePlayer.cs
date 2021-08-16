using System.ComponentModel;
using System.Threading;

namespace ChessGame
{
    public class MovePlayer
    {
        private BackgroundWorker Worker { get; set; }
        private Referee Referee { get; set; }
        private GameContext LoadedContext { get; set; }
        private GameContext RunningContext { get; set; }



        public MovePlayer(GameContext loadedContext, Referee referee)
        {
            LoadedContext = loadedContext;
            Referee = referee;
        }

        public void Initialize()
        {
            Cleanup();

            RunningContext = new();
            RunningContext.MoveHistory = new();
            RunningContext.Layout = new();
            RunningContext.Layout.Initialize();
        }

        public void ReplayMoves()
        {
            Initialize();

            Worker = new();
            Worker.DoWork += Worker_DoWork;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.WorkerReportsProgress = true;
            Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Worker.ReportProgress(0);

            int i = 1, percent;
            foreach (Move move in LoadedContext.MoveHistory)
            {
                Thread.Sleep(2000);

                RunningContext.Layout.Move(move);

                RunningContext.MoveHistory.Add(move);

                percent = i++ * 100 / LoadedContext.MoveHistory.Count;

                Worker.ReportProgress(percent);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Referee.StartWithContext(RunningContext);
        }

        public void Cleanup()
        {
            if (Worker != null)
            {
                if (Worker.IsBusy)
                {
                    Worker.CancelAsync();
                }
                Worker.ProgressChanged -= Worker_ProgressChanged;
                Worker.DoWork -= Worker_DoWork;
                Worker = null;
            }

            if(RunningContext != null)
            {
                RunningContext.Layout.Cleanup();
                RunningContext.Layout = null;
                RunningContext.MoveHistory = null;
                RunningContext = null;
            }
        }

    }
}