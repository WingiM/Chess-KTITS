// Sharipov 220 Chess-3 13.04

using System;

namespace Chess.Core.Figures
{
    public class King : Piece
    {
        public King(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'K';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            return Math.Abs(newCol - Col) <= 1 && Math.Abs(newRow - Row) <= 1;
        }
    }
}
