// Sharipov 220 Chess-3 13.04

using System;
namespace Chess
{
    public class Queen : Piece
    {
        public Queen(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'Q';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            return (newCol == Col || newRow == Row)
                || Math.Abs(Col - newCol) == Math.Abs(Row - newRow);
        }
    }
}
