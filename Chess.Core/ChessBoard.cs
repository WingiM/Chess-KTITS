using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chess.Core.Figures;

namespace Chess.Core
{
    public class ChessBoard : IEnumerable<Piece>
    {
        private static readonly Dictionary<string, ChessPieces> ChessPiecesCode;
        private readonly List<Piece> _pieces;

        static ChessBoard()
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

        public ChessBoard(bool fillDefault = false)
        {
            _pieces = new();

            if (fillDefault)
                FillBoardDefault();
        }

        public void AddPiece(TeamColor color, ChessPieces pieceCode,
            string position)
        {
            if (_pieces.FirstOrDefault(p => p.Coordinates.Equals(position)) is
                not null)
            {
                throw new Exception("Position already taken");
            }

            switch (pieceCode)
            {
                case ChessPieces.King:
                    _pieces.Add(new King(color, position));
                    break;
                case ChessPieces.Queen:
                    _pieces.Add(new Queen(color, position));
                    break;
                case ChessPieces.Bishop:
                    _pieces.Add(new Bishop(color, position));
                    break;
                case ChessPieces.Knight:
                    _pieces.Add(new Knight(color, position));
                    break;
                case ChessPieces.Rook:
                    _pieces.Add(new Rook(color, position));
                    break;
                case ChessPieces.Pawn:
                    _pieces.Add(new Pawn(color, position));
                    break;

                default:
                    throw new Exception("Unknown piece code");
            }
        }

        public void AddPiece(TeamColor color, ChessPieces code, int x, int y)
        {
            AddPiece(color, code, Piece.ParseCoordinates(x, y));
        }

        public void AddPiece(TeamColor color, string code, int x, int y)
        {
            AddPiece(color, ChessPiecesCode[code], x, y);
        }

        public void AddPiece(TeamColor color, string code, string coordinates)
        {
            AddPiece(color, ChessPiecesCode[code], coordinates);
        }

        public void RemovePiece(int col, int row)
        {
            RemovePiece(Piece.ParseCoordinates(col, row));
        }

        public void RemovePiece(string coordinates)
        {
            if (GetPieceOnCell(coordinates) is null)
                return;
            
            var piece =
                _pieces.FirstOrDefault(p => p.Coordinates.Equals(coordinates));
            _pieces.Remove(piece);
        }

        public Piece GetPieceOnCell(string coordinates)
        {
            return _pieces.FirstOrDefault(
                p => p.Coordinates.Equals(coordinates));
        }

        public Piece GetPieceOnCell(int col, int row)
        {
            var coordinates = Piece.ParseCoordinates(col, row);
            return _pieces.FirstOrDefault(
                p => p.Coordinates.Equals(coordinates));
        }

        public bool CanPieceMove(Piece piece, int col, int row)
        {
            return CanPieceMove(piece, Piece.ParseCoordinates(col, row));
        }

        public bool CanPieceMove(Piece piece, string coordinates)
        {
            var targetPiece = GetPieceOnCell(coordinates);
            if (targetPiece is not null && targetPiece.Color == piece.Color)
                return false;
            return piece.IsRightMove(coordinates);
        }

        public bool MovePiece(Piece piece, int col, int row)
        {
            return MovePiece(piece, Piece.ParseCoordinates(col, row));
        }

        public bool MovePiece(Piece piece, string coordinates)
        {
            if (!CanPieceMove(piece, coordinates))
                return false;

            var targetPiece =
                _pieces.FirstOrDefault(p => p.Coordinates == coordinates);
            if (targetPiece is not null && targetPiece.Color != piece.Color)
            {
                _pieces.Remove(targetPiece);
            }

            return piece.Move(coordinates);
        }

        private void FillBoardDefault()
        {
            for (char i = 'A'; i < 'I'; i++)
            {
                _pieces.Add(new Pawn(TeamColor.Black, $"{i}7"));
                _pieces.Add(new Pawn(TeamColor.White, $"{i}2"));
            }

            _pieces.Add(new Rook(TeamColor.Black, "A8"));
            _pieces.Add(new Rook(TeamColor.Black, "H8"));
            _pieces.Add(new Knight(TeamColor.Black, "B8"));
            _pieces.Add(new Knight(TeamColor.Black, "G8"));
            _pieces.Add(new Bishop(TeamColor.Black, "C8"));
            _pieces.Add(new Bishop(TeamColor.Black, "F8"));
            _pieces.Add(new Queen(TeamColor.Black, "D8"));
            _pieces.Add(new King(TeamColor.Black, "E8"));

            _pieces.Add(new Rook(TeamColor.White, "A1"));
            _pieces.Add(new Rook(TeamColor.White, "H1"));
            _pieces.Add(new Knight(TeamColor.White, "B1"));
            _pieces.Add(new Knight(TeamColor.White, "G1"));
            _pieces.Add(new Bishop(TeamColor.White, "C1"));
            _pieces.Add(new Bishop(TeamColor.White, "F1"));
            _pieces.Add(new Queen(TeamColor.White, "D1"));
            _pieces.Add(new King(TeamColor.White, "E1"));
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