using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        public int CellSize { get; set; }
        public object Enviroment { get; private set; }
        private const int Border = 3;

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
            if (Layout != null)
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
            {
                for (var row = 0; row < 8; row++)
                {
                    for (var col = 0; col < 8; col++)
                    {
                        g.FillRectangle((row + col) % 2 == 0 ? Brushes.White : Brushes.Brown, row * CellSize, col * CellSize, CellSize, CellSize);
                    }
                }
            }
        }

        public void DrawPieces(Graphics g)
        {
            foreach (var coordinate in Layout.Keys)
            {
                g.DrawImage(Layout[coordinate].GetImage(coordinate.Y), coordinate.X * CellSize, coordinate.Y * CellSize, CellSize, CellSize);
            }
        }

        public void Reshape(int parentWidth, int parentHeight, int menuStripHeight)
        {
            // Lucram pe inaltime ( y mijloc , x 0 )
            bool widthIsSmaller = parentWidth <= parentHeight - menuStripHeight;
            // Lucram pe latime ( y 0 , x mijloc )

            var boardSize = widthIsSmaller ? parentWidth - 3 * Border : parentHeight - menuStripHeight / 3 - 6 * Border;

            CellSize = boardSize / 8;

            SetBounds(widthIsSmaller ? 0 : (parentWidth - parentHeight) / 2 + 3 * Border,
                      widthIsSmaller ? menuStripHeight + (parentHeight - parentWidth) / 2 - Border : menuStripHeight + Border,
                      boardSize,
                      boardSize);

            Refresh();
        }
    }
}