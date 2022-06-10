﻿// Sharipov 220 Chess-3 13.04

using System;
namespace Chess
{
    public class Rook : Piece
    {
        public Rook(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'R';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            return newCol == Col || newRow == Row;
        }
    }
}
