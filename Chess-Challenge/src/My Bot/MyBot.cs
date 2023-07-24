using ChessChallenge.API;
using System;

public class MyBot : IChessBot
{
    private int[] pieceValues = { 0, 1, 3, 3, 5, 8 };

    public Move Think(Board board, Timer timer)
    {
        Move[] allLegalMoves = board.GetLegalMoves();

        Random rng = new();
        Move moveToPlay = allLegalMoves[rng.Next(allLegalMoves.Length)];

        foreach (var move in allLegalMoves)
        {
            if (MoveIsCheckmate(board, move))
            {
                moveToPlay = move;
            }
        }

        return moveToPlay;
    }

    bool MoveIsCheckmate(Board board, Move move)
    {
        board.MakeMove(move);
        bool isMate = board.IsInCheckmate();
        board.UndoMove(move);
        return isMate;
    }
}