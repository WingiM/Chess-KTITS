using System.Windows.Controls;
using Chess.Core.Figures;

namespace Chess.WPFApplication
{
    public class ChessCell : Label
    {
        public int Col { get; }
        public int Row { get; }

        public ChessCell(int col, int row)
        {
            Col = col;
            Row = Piece.ChessBoardSize - row - 1;
        }
        
    }
}