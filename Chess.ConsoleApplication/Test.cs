// Sharipov 220 Chess-3 13.04

using System;
using System.Diagnostics;

namespace Chess.ConsoleApplication
{
    public static class Test
    {
        public static void Run()
        {
            TestBlackPawnMoveRight();
            TestBlackPawnMoveWrong();
            TestWhitePawnMoveRight();
            TestWhitePawnMoveWrong();
            TestRookMoveRight();
            TestRookMoveWrong();
            TestKnightMoveRight();
            TestKnightMoveWrong();
            TestQueenMoveBishopStyle();
            TestQueenMoveRookStyle();
            TestQueenMoveWrong();
            TestKingMoveBishopStyle();
            TestKingMoveRookStyle();
            TestKingMoveWrong();
            TestMoveBeyondFields();

        }

        
        public static void TestBlackPawnMoveRight()
        {
            var startPosition = "A7";
            var endPosition = "A6";
            Piece piece = new Pawn(TeamColor.Black, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Black pawn right move complete");
        }

        
        public static void TestBlackPawnMoveWrong()
        {
            var startPosition = "A7";
            var endPosition = "B7";
            Piece piece = new Pawn(TeamColor.Black, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Black pawn wrong move complete");
        }

        
        public static void TestWhitePawnMoveRight()
        {
            var startPosition = "A2";
            var endPosition = "A3";
            Piece piece = new Pawn(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("White pawn right move complete");
        }

        
        public static void TestWhitePawnMoveWrong()
        {
            var startPosition = "A2";
            var endPosition = "A6";
            Piece piece = new Pawn(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("White pawn wrong move complete");
        }

        
        public static void TestRookMoveRight()
        {
            var startPosition = "A1";
            var endPosition = "G1";
            var piece = new Rook(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Rook right move complete");
        }

        
        public static void TestRookMoveWrong()
        {
            var startPosition = "A1";
            var endPosition = "G2";
            var piece = new Rook(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Rook wrong move complete");
        }

        
        public static void TestKnightMoveRight()
        {
            var startPosition = "B1";
            var endPosition = "A3";
            var piece = new Knight(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Knight right move complete");
        }

        
        public static void TestKnightMoveWrong()
        {
            var startPosition = "B1";
            var endPosition = "A2";
            var piece = new Knight(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Knight wrong move complete");
        }

        
        public static void TestQueenMoveRookStyle()
        {
            var startPosition = "D1";
            var endPosition = "D6";
            var piece = new Queen(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Queen rook style move complete");
        }

        
        public static void TestQueenMoveBishopStyle()
        {
            var startPosition = "D1";
            var endPosition = "H5";
            var piece = new Queen(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Queen bishop style move complete");
        }

        
        public static void TestQueenMoveWrong()
        {
            var startPosition = "D1";
            var endPosition = "A2";
            var piece = new Queen(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Queen wrong move complete");
        }

        
        public static void TestKingMoveRookStyle()
        {
            var startPosition = "E1";
            var endPosition = "E2";
            var piece = new King(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("King rook style move complete");
        }

        
        public static void TestKingMoveBishopStyle()
        {
            var startPosition = "E1";
            var endPosition = "F2";
            var piece = new King(TeamColor.White, startPosition);

            var expectedResult = true;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("King bishop style move complete");
        }

        
        public static void TestKingMoveWrong()
        {
            var startPosition = "E1";
            var endPosition = "G3";
            var piece = new King(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("King wrong move complete");
        }

        
        public static void TestMoveBeyondFields()
        {
            var startPosition = "D1";
            var endPosition = "J8";
            var piece = new Queen(TeamColor.White, startPosition);

            var expectedResult = false;

            Debug.Assert(expectedResult == piece.IsRightMove(endPosition));
            Console.WriteLine("Move beyond fields compelte");
        }
    }
}
