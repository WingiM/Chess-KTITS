// Sharipov 220 Chess-3 13.04

using System;
namespace Chess
{
    public abstract class Piece
    {
        protected readonly TeamColor Color;
        protected char FigureName;

        protected int Col;
        protected int Row;

        public string Coordinates => $"{(char)(Col + 65)}{Row + 1}";

        protected Piece(TeamColor color, string coordinates)
        {
            Color = color;
            (Col, Row) = ParseCoordinates(coordinates);

            if (!IsRightCoordinate(Col) || !IsRightCoordinate(Row))
            {
                throw new Exception("Wromng piece coordinations");
            }
        }

        private bool IsRightCoordinate(int coordinate) => coordinate >= 0
                                                          && coordinate <= 7;

        public static Tuple<int, int> ParseCoordinates(string coordinates) =>
            new(coordinates.ToUpper()[0] - 65,
                coordinates[1] - 49);

        private bool IsRightMove(int col, int row)
        {
            if (!(IsRightCoordinate(col) && IsRightCoordinate(row)))
            {
                return false;
            }

            return CheckRightMove(col, row);
        }

        public bool IsRightMove(string coordinates)
        {
            var (newCol, newRow) = ParseCoordinates(coordinates.ToUpper());
            return IsRightMove(newCol, newRow);
        }

        protected abstract bool CheckRightMove(int col, int row);

        public void Move(string coordinates)
        {
            var (newCol, newRow) = ParseCoordinates(coordinates);
            Move(newCol, newRow);
        }

        public void Move(int col, int row)
        {
            if (!IsRightMove(col, row))
            {
                return;
            }

            (this.Col, this.Row) = (col, row);
        }

        public override string ToString()
        {
            return $"{Color.ToString().ToLower()[0]}{FigureName}";
        }
    }
}
