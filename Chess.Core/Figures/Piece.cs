// Sharipov 220 Chess-3 13.04

using System;

namespace Chess.Core.Figures
{
    public abstract class Piece
    {
        public const int ChessBoardSize = 8;
        public TeamColor Color { get; }
        public char FigureName { get; init; }

        protected int Col;
        protected int Row;

        public string Coordinates => $"{(char)(Col + 65)}{Row + 1}";
        public Tuple<int, int> NumericCoordinates => new Tuple<int, int>(Col, Row);

        protected Piece(TeamColor color, string coordinates)
        {
            Color = color;
            (Col, Row) = ParseCoordinates(coordinates);

            if (!IsRightCoordinate(Col) || !IsRightCoordinate(Row))
            {
                throw new Exception("Wromng piece coordinations");
            }
        }

        private bool IsRightCoordinate(int coordinate) => coordinate is >= 0 and < ChessBoardSize;

        public static Tuple<int, int> ParseCoordinates(string coordinates) =>
            new(coordinates.ToUpper()[0] - 65,
                coordinates[1] - 49);

        public static string ParseCoordinates(int col, int row) => $"{(char)(col + 65)}{row + 1}";


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

        public bool Move(string coordinates)
        {
            var (newCol, newRow) = ParseCoordinates(coordinates);
            return Move(newCol, newRow);
        }

        public bool Move(int col, int row)
        {
            if (!IsRightMove(col, row))
            {
                return false;
            }

            (this.Col, this.Row) = (col, row);
            return true;
        }

        public override string ToString()
        {
            return $"{Color.ToString().ToLower()[0]}{FigureName}";
        }
    }
}