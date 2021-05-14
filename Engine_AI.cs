using System;
using System.Collections.Generic;
using System.Linq;
using static TicTacToe.Engine_Game;

namespace TicTacToe
{
    public class Engine_AI
    {

        // SIMPLE AIs

        public static int[] DetermineMoveRandomly(int[,] actualBoardState)
        {
            int[] nextMoveCoordinates = { 0, 0 };

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardHeight;)
                {
                    int[] validMove = { 0, 0 };

                    if (actualBoardState[i, j] == 0)
                    {
                        validMove[0] = i;
                        validMove[1] = j;
                        availableMoves.Add(validMove);
                    }

                    j++;
                }

                i++;
            }

            int moveCount = availableMoves.Count();

            Random random = new Random();

            int randomNumber = random.Next(0, moveCount - 1);

            nextMoveCoordinates = availableMoves[randomNumber];

            return nextMoveCoordinates;
        }

        public static int[] FindWinningMove(int[,] actualBoardState, int playerID)
        {
            int[] nextMoveCoordinates = { 0, 0 };

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardHeight;)
                {
                    int[] validMove = { 0, 0 };

                    if (actualBoardState[i, j] == 0)
                    {
                        validMove[0] = i;
                        validMove[1] = j;
                        availableMoves.Add(validMove);
                    }

                    j++;
                }

                i++;
            }


            bool winningMoveExists = false;

            for (int i = 0; i < availableMoves.Count;)
            {
                int[] currentMoveCoordinates = availableMoves[i];
                int[,] potentialBoard = AddMoveToBoard(actualBoardState, currentMoveCoordinates, playerID);
                winningMoveExists = CheckIfPlayerWon(potentialBoard, playerID);

                if (winningMoveExists == true)
                {
                    nextMoveCoordinates = currentMoveCoordinates;
                    break;
                }

                i++;
            }

            if (winningMoveExists == false)
            {
                nextMoveCoordinates = DetermineMoveRandomly(actualBoardState);
            }

            return nextMoveCoordinates;
        }

        public static int[] FindWinningAvoidLosingMove(int[,] actualBoardState, int playerID)
        {
            int[] nextMoveCoordinates = { 0, 0 };

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardHeight;)
                {
                    int[] validMove = { 0, 0 };

                    if (actualBoardState[i, j] == 0)
                    {
                        validMove[0] = i;
                        validMove[1] = j;
                        availableMoves.Add(validMove);
                    }

                    j++;
                }

                i++;
            }

            // Check for winning move

            bool winningMoveExists = false;

            for (int i = 0; i < availableMoves.Count;)
            {
                int[] currentMoveCoordinates = availableMoves[i];
                int[,] potentialBoard = AddMoveToBoard(actualBoardState, currentMoveCoordinates, playerID);
                winningMoveExists = CheckIfPlayerWon(potentialBoard, playerID);

                if (winningMoveExists == true)
                {
                    nextMoveCoordinates = currentMoveCoordinates;
                    break;
                }

                i++;
            }

            // Check for opponent's winning move

            bool opponentWinningMoveExists = false;
            int opponentID = GetNextPlayer(playerID);

            for (int i = 0; i < availableMoves.Count;)
            {
                int[] currentMoveCoordinates = availableMoves[i];
                int[,] potentialBoard = AddMoveToBoard(actualBoardState, currentMoveCoordinates, opponentID);
                opponentWinningMoveExists = CheckIfPlayerWon(potentialBoard, opponentID);

                if (opponentWinningMoveExists == true)
                {
                    nextMoveCoordinates = currentMoveCoordinates;
                    break;
                }

                i++;

            }

            if (winningMoveExists == false & opponentWinningMoveExists == false)
            {
                nextMoveCoordinates = DetermineMoveRandomly(actualBoardState);
            }

            return nextMoveCoordinates;
        }

        // MINIMAX CODE

        public static int[] AIMakeMove(int[,] actualBoardState, int playerID)
        {
            int[] nextMoveCoordinates = { 0, 0 };

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            // Find all available moves of player

            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardHeight;)
                {
                    int[] validMove = { 0, 0 };

                    if (actualBoardState[i, j] == 0)
                    {
                        validMove[0] = i;
                        validMove[1] = j;
                        availableMoves.Add(validMove);
                    }

                    j++;
                }

                i++;
            }

            int[] moveScores = new int[availableMoves.Count];

            for (int i = 0; i < availableMoves.Count;)
            {
                int[] currentMove = availableMoves[i];
                moveScores[i] = MiniMax(actualBoardState, currentMove, playerID);
                i++;
            }

            int maxValue = moveScores.Max();
            int maxIndex = moveScores.ToList().IndexOf(maxValue);

            nextMoveCoordinates = availableMoves[maxIndex];

            return nextMoveCoordinates;
        }

        public static int MiniMax(int[,] actualBoardState, int[] currentMove, int playerID)
        {
            int maxScore = 0;

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            int[,] nextBoardState = CopyArray(actualBoardState);

            nextBoardState = AddMoveToBoard(actualBoardState, currentMove, playerID);

            // Check for winning move

            bool winningMove = false;

            winningMove = CheckIfPlayerWon(nextBoardState, playerID);

            if (winningMove == true)
            {
                maxScore = 10;
            }

            if (winningMove == false)
            {
                int opponentID = GetNextPlayer(playerID);
                List<int[]> opponentAvailableMoves = new List<int[]>();

                for (int i = 0; i < boardHeight;)
                {
                    for (int j = 0; j < boardHeight;)
                    {
                        int[] validMove = { 0, 0 };

                        if (nextBoardState[i, j] == 0)
                        {
                            validMove[0] = i;
                            validMove[1] = j;
                            opponentAvailableMoves.Add(validMove);
                        }

                        j++;
                    }

                    i++;
                }

                if (opponentAvailableMoves.Count != 0)
                {
                    int[] opponentMoveScores = new int[opponentAvailableMoves.Count];

                    for (int i = 0; i < opponentAvailableMoves.Count;)
                    {
                        int[] currentOpponentMove = opponentAvailableMoves[i];
                        int[,] nextOpponentBoardState = AddMoveToBoard(nextBoardState, currentOpponentMove, opponentID);

                        bool opponentWinningMove = false;

                        opponentWinningMove = CheckIfPlayerWon(nextOpponentBoardState, opponentID);

                        if (opponentWinningMove == true)
                        {
                            opponentMoveScores[i] = -10;
                        }

                        if (opponentWinningMove == false)
                        {
                            List<int[]> nextRoundAvailableMoves = new List<int[]>();

                            for (int j = 0; j < boardHeight;)
                            {
                                for (int k = 0; k < boardHeight;)
                                {
                                    int[] validMove = { 0, 0 };

                                    if (nextOpponentBoardState[j, k] == 0)
                                    {
                                        validMove[0] = j;
                                        validMove[1] = k;
                                        nextRoundAvailableMoves.Add(validMove);
                                    }

                                    k++;
                                }

                                j++;
                            }

                            int[] nextRoundMoveScores = new int[nextRoundAvailableMoves.Count];

                            if (nextRoundAvailableMoves.Count != 0)
                            {
                                for (int j = 0; j < nextRoundAvailableMoves.Count;)
                                {
                                    int[] nextRoundMove = nextRoundAvailableMoves[j];
                                    nextRoundMoveScores[j] = MiniMax(nextOpponentBoardState, nextRoundMove, playerID);
                                    j++;
                                }

                                int nextRoundMaxValue = nextRoundMoveScores.Max();
                                opponentMoveScores[i] = nextRoundMaxValue;
                            }
                        }

                        i++;

                    }

                    maxScore = opponentMoveScores.Min();

                }
            }

            return maxScore;
        }

        // MINIMAX CODE with depth

        public static int[] AIMakeMoveWithDepth(int[,] actualBoardState, int playerID)
        {
            int[] nextMoveCoordinates = { 0, 0 };

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            // Find all available moves of player

            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardHeight;)
                {
                    int[] validMove = { 0, 0 };

                    if (actualBoardState[i, j] == 0)
                    {
                        validMove[0] = i;
                        validMove[1] = j;
                        availableMoves.Add(validMove);
                    }

                    j++;
                }

                i++;
            }

            int[] moveScores = new int[availableMoves.Count];
            int depth = 0;

            for (int i = 0; i < availableMoves.Count;)
            {
                int[] currentMove = availableMoves[i];
                moveScores[i] = MiniMaxWithDepth(actualBoardState, currentMove, playerID, depth);
                i++;
            }

            int maxValue = moveScores.Max();
            int maxIndex = moveScores.ToList().IndexOf(maxValue);

            nextMoveCoordinates = availableMoves[maxIndex];

            return nextMoveCoordinates;
        }

        public static int MiniMaxWithDepth(int[,] actualBoardState, int[] currentMove, int playerID, int currentDepth)
        {
            int maxScore = 0;

            int boardHeight = actualBoardState.GetLength(0);
            int boardWidth = actualBoardState.GetLength(1);

            int[,] nextBoardState = CopyArray(actualBoardState);

            nextBoardState = AddMoveToBoard(actualBoardState, currentMove, playerID);

            // Check for winning move

            bool winningMove = false;

            winningMove = CheckIfPlayerWon(nextBoardState, playerID);

            if (winningMove == true)
            {
                maxScore = 10 - currentDepth;
            }

            if (winningMove == false)
            {
                int opponentID = GetNextPlayer(playerID);
                List<int[]> opponentAvailableMoves = new List<int[]>();

                for (int i = 0; i < boardHeight;)
                {
                    for (int j = 0; j < boardHeight;)
                    {
                        int[] validMove = { 0, 0 };

                        if (nextBoardState[i, j] == 0)
                        {
                            validMove[0] = i;
                            validMove[1] = j;
                            opponentAvailableMoves.Add(validMove);
                        }

                        j++;
                    }

                    i++;
                }

                if (opponentAvailableMoves.Count != 0)
                {
                    int[] opponentMoveScores = new int[opponentAvailableMoves.Count];

                    for (int i = 0; i < opponentAvailableMoves.Count;)
                    {
                        int[] currentOpponentMove = opponentAvailableMoves[i];
                        int[,] nextOpponentBoardState = AddMoveToBoard(nextBoardState, currentOpponentMove, opponentID);

                        bool opponentWinningMove = false;

                        opponentWinningMove = CheckIfPlayerWon(nextOpponentBoardState, opponentID);

                        if (opponentWinningMove == true)
                        {
                            opponentMoveScores[i] = -10 + currentDepth;
                        }

                        if (opponentWinningMove == false)
                        {
                            List<int[]> nextRoundAvailableMoves = new List<int[]>();

                            for (int j = 0; j < boardHeight;)
                            {
                                for (int k = 0; k < boardHeight;)
                                {
                                    int[] validMove = { 0, 0 };

                                    if (nextOpponentBoardState[j, k] == 0)
                                    {
                                        validMove[0] = j;
                                        validMove[1] = k;
                                        nextRoundAvailableMoves.Add(validMove);
                                    }

                                    k++;
                                }

                                j++;
                            }

                            int[] nextRoundMoveScores = new int[nextRoundAvailableMoves.Count];

                            if (nextRoundAvailableMoves.Count != 0)
                            {

                                int nextDepth = currentDepth + 1;

                                for (int j = 0; j < nextRoundAvailableMoves.Count;)
                                {
                                    int[] nextRoundMove = nextRoundAvailableMoves[j];
                                    nextRoundMoveScores[j] = MiniMaxWithDepth(nextOpponentBoardState, nextRoundMove, playerID, nextDepth);
                                    j++;
                                }

                                int nextRoundMaxValue = nextRoundMoveScores.Max();
                                opponentMoveScores[i] = nextRoundMaxValue;
                            }
                        }

                        i++;

                    }

                    maxScore = opponentMoveScores.Min();

                }
            }

            return maxScore;

        }
    }
}