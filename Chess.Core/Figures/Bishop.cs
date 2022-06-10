// Sharipov 220 Chess-3 13.04

using System;
namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'B';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            return Math.Abs(Col - newCol) == Math.Abs(Row - newRow);
        }
    }
}
