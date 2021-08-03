using ChessGame.Pieces;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        private const int Border = 3;
        private Pen borderPen = new(Color.Green, 3);
        public Rectangle Rect;
        private BoardLayout Layout;

        public int CellSize { get; set; }
        public Coordinate TargetCoordinates { get; set; }
        public Coordinate InitialCoordiantes { get; set; }
        public APiece TargetedPiece { get; set; }
        public PieceColor TeamToMove = PieceColor.White;

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
            this.Cursor = Cursors.Default;

            // if(Coordinates.GetInstance(TargetCoordinates.X, TargetCoordinates.Y) nu da eroare )
            Layout.Move(TargetedPiece, InitialCoordiantes, TargetCoordinates);

            Refresh();
        }

        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            if (Layout.ContainsKey(TargetCoordinates))
            {
                InitialCoordiantes = TargetCoordinates;

                this.Cursor = new Cursor(Layout[TargetCoordinates].GetImage().GetHicon());

                TargetedPiece = Layout[InitialCoordiantes];

                Layout.Remove(InitialCoordiantes);

                Refresh();
            }   
        }

        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            // if(Coordinates.GetInstance(TargetCoordinates.X, TargetCoordinates.Y) nu da eroare )
            if ((e.X / CellSize < 8 && e.Y / CellSize < 8) && (e.X / CellSize != TargetCoordinates?.X || e.Y / CellSize != TargetCoordinates?.Y))
            {
                TargetCoordinates = Coordinate.GetInstance(e.X / CellSize, e.Y / CellSize);

                if (Layout.ContainsKey(TargetCoordinates))
                {
                    borderPen.Color = Color.Green;
                }
                else
                {
                    borderPen.Color = Color.Red;
                }
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
            if (TargetCoordinates != null)
            {
                g.DrawRectangle(borderPen, TargetCoordinates.X * CellSize, TargetCoordinates.Y * CellSize, CellSize, CellSize);
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
// Evenimente
// Afisam intr-un fisier coordonatele on hover ( cand se schimba )
// Creez border pentru piesa la care ii dau hover ( cand se schimba )