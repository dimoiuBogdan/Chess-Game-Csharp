using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        private const int Border = 3;
        private Pen borderPen = new(Color.Green, 3);

        private BoardLayout Layout;

        public int CellSize { get; set; }

        public MoveCoordinates MoveCoordinates = new(null, null);

        public Board()
        {

        }

        public void Initialize()
        {
            Layout = new BoardLayout();
            Layout?.Initialize();

            this.MouseMove += Board_MouseMove;
            this.MouseDown += Board_MouseDown;
            this.MouseUp += Board_MouseUp;

            DoubleBuffered = true;
        }

        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            var coordinateY = e.Y / CellSize;
            var coordinateX = e.X / CellSize;

            this.Cursor = Cursors.Default;

            if ((coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0))
            {
                if (MoveCoordinates.InitialCoordinate != null && MoveCoordinates.InitialCoordinate != MoveCoordinates.MouseOverCoordinate)
                {
                    Layout.Move(MoveCoordinates);
                }
            }

            MoveCoordinates.InitialCoordinate = null;
            MoveCoordinates.MouseOverCoordinate = null;

            Refresh();
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            var coordinateX = e.X / CellSize;
            var coordinateY = e.Y / CellSize;
            if (coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0 && e.Button == MouseButtons.Left)
            {
                if (Layout.ContainsKey(Coordinate.GetInstance(coordinateX, coordinateY)))
                {
                    MoveCoordinates.InitialCoordinate = Coordinate.GetInstance(coordinateX, coordinateY);

                    Cursor = new Cursor(new Bitmap(Layout[MoveCoordinates.InitialCoordinate].GetImage(), CellSize, CellSize).GetHicon());

                    Refresh();
                }
            }
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            var coordinateX = e.X / CellSize;
            var coordinateY = e.Y / CellSize;
            if ((coordinateX < 8 && coordinateY < 8 && coordinateX >= 0 && coordinateY >= 0) &&
                (coordinateX != MoveCoordinates.MouseOverCoordinate?.X || coordinateY != MoveCoordinates.MouseOverCoordinate?.Y))
            {
                MoveCoordinates.MouseOverCoordinate = Coordinate.GetInstance(coordinateX, coordinateY);

                Refresh();
            }
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
            DrawHoveredCellBorder(e.Graphics);
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
                g.DrawImage(Layout[coordinate].GetImage(), coordinate.X * CellSize, coordinate.Y * CellSize, CellSize, CellSize);
            }
        }

        public void DrawHoveredCellBorder(Graphics g)
        {
            if (MoveCoordinates.MouseOverCoordinate != null)
            {
                if (Layout.ContainsKey(MoveCoordinates.MouseOverCoordinate))
                {
                    borderPen.Color = Color.Green;
                }
                else
                {
                    borderPen.Color = Color.Red;
                }
                g.DrawRectangle(borderPen, MoveCoordinates.MouseOverCoordinate.X * CellSize, MoveCoordinates.MouseOverCoordinate.Y * CellSize, CellSize, CellSize);
            }
        }

        public void Reshape(int parentWidth, int parentHeight, int menuStripHeight)
        {
            bool widthIsSmaller = parentWidth <= parentHeight - menuStripHeight;

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