// Sharipov 220 Chess-3 13.04

using System;

namespace Chess.Core.Figures
{
    public class Knight : Piece
    {
        public Knight(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'N';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            return Math.Abs(newCol - Col) * Math.Abs(newRow - Row) == 2;
        }
    }
}
