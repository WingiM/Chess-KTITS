
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chess.Core
{
    public class PieceController : IEnumerable<Piece>
    {
        private static readonly Dictionary<string, ChessPieces> ChessPiecesCode;
        private readonly List<Piece> _pieces;

        static PieceController()
        {
            ChessPiecesCode = new Dictionary<string, ChessPieces>
            {
                { "King", ChessPieces.King },
                { "K", ChessPieces.King },
                { "Queen", ChessPieces.Queen },
                { "Q", ChessPieces.Queen },
                { "Bishop", ChessPieces.Bishop },
                { "B", ChessPieces.Bishop },
                { "Knight", ChessPieces.Knight },
                { "N", ChessPieces.Knight },
                { "Rook", ChessPieces.Rook },
                { "R", ChessPieces.Rook },
                { "Pawn", ChessPieces.Pawn },
                { "P", ChessPieces.Pawn }
            };
        }

        public PieceController(bool fillDefault = false)
        {
            _pieces = new();

            if (fillDefault)
                FillBoardDefault();
        }

        private void FillBoardDefault()
        {
            
        }

        public IEnumerator<Piece> GetEnumerator()
        {
            foreach (var piece in _pieces)
            {
                yield return piece;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}