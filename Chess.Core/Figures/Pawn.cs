// Sharipov 220 Chess-3 13.04

namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(TeamColor color, string coordinates)
            : base(color, coordinates)
        {
            FigureName = 'P';
        }

        protected override bool CheckRightMove(int newCol, int newRow)
        {
            switch (Color)
            {
                case TeamColor.White:
                    return ((newRow - Row == 2 && Row == 2)
                        || newRow - Row == 1) && newCol == Col;
                case TeamColor.Black:
                    return ((Row - newRow == 2 && Row == 7)
                        || Row - newRow == 1) && newCol == Col;
                default:
                    return false;
            }
        }
    }
}
