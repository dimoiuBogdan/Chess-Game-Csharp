using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        public int CellSize { get; set; }
        private const int Border = 0;
        private BoardLayout Layout;

        public Board()
        {

        }

        public void Initialize()
        {
            Layout = new BoardLayout();
            Layout?.Initialize();
        }

        public void Cleanup()
        {
            if(Layout != null)
            {
                Layout.Cleanup();
                Layout = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBoard(e.Graphics);
            DrawPieces(e.Graphics);
        }

        public void DrawBoard(Graphics g)
        {
            for (var row = 0; row < 8; row++)
            {
                for (var col = 0; col < 8; col++)
                {
                    g.FillRectangle((row + col) % 2 == 0 ? Brushes.White : Brushes.Brown, row * CellSize, col * CellSize, CellSize, CellSize);
                }
            }
        }

        public void DrawPieces(Graphics g)
        {
            CellSize = Width / 8;
            Pen greenPen = new(Color.Green, 5);
            foreach (var piece in Layout)
            {
                var centeredX = piece.Key.X * CellSize + CellSize / 8;
                var centeredY = piece.Key.Y * CellSize + CellSize / 8;
                Rectangle rect = new(centeredX, centeredY, CellSize - 20, CellSize - 20);

                g.DrawEllipse(greenPen, rect);
            }
            // Desenam piesele grafic in functie de datele din Layout
        }

        public void Reshape(int parentWidth, int parentHeight, int menuStripHeight)
        {
            bool widthIsSmaller = parentWidth <= parentHeight - menuStripHeight;
            var boardSize = widthIsSmaller ? parentWidth - 2 * Border : parentHeight - menuStripHeight - 2 * Border;
            CellSize = boardSize / 8;

            SetBounds(widthIsSmaller ? 0 : (parentWidth - parentHeight) / 2,
                      widthIsSmaller ? menuStripHeight + (parentHeight - parentWidth) / 2 : menuStripHeight,
                      CellSize * 8,
                      CellSize * 8);

            Refresh();
        }
    }
}