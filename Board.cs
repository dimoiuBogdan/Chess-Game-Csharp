using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ChessGame
{
    public class Board : Panel
    {
        public int CellSize { get; set; }
        public object Enviroment { get; private set; }
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
            foreach (var coordinate in Layout.Keys)
            {
                g.DrawImage(Layout[coordinate].GetImage(), coordinate.X * CellSize, coordinate.Y * CellSize, CellSize, CellSize);
            }
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