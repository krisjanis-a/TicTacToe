using System;
using static TicTacToe.Engine_Game;
using static TicTacToe.Engine_AI;

namespace TicTacToe
{
    class MainClass
    {
        public static int[,] currentBoardState { get; private set; }

        public static void Main(string[] args)
        {
            int player1Score = 0;
            int player2Score = 0;
            int drawsCount = 0;

        Beginning:

            Console.WriteLine("Tic Tac Toe - Game" + Environment.NewLine);

            // Create empty board

            int[,] emptyBoard = new int[3, 3];

            for (int i = 0; i < emptyBoard.GetLength(0);)
            {
                for (int j = 0; j < emptyBoard.GetLength(1);)
                {
                    emptyBoard[i, j] = 0;
                    j++;
                }

                i++;
            }

            // Print board

            PrintBoard(emptyBoard);

            Console.WriteLine(Environment.NewLine + "Player-1 score: " + player1Score);
            Console.WriteLine("Player-2 score: " + player2Score);

            Console.WriteLine("Press any key to start the game.");
            Console.ReadKey();
            Console.Clear();

            // Get user or AI input for coordinates

            currentBoardState = CopyArray(emptyBoard);

            int boardHeight = currentBoardState.GetLength(0);
            int boardWidth = currentBoardState.GetLength(1);

            int player1 = 1;
            int player2 = 2;

            int player1MoveCount = 0;
            int player2MoveCount = 0;

            int playerID = 1; // Choose starting player

            bool gameFinished = false;
            bool boardIsFull = false;
            bool player1Wins = false;
            bool player2Wins = false;

            while (gameFinished == false)
            {

                // Change value of playerID in if() statement to valid values to determine human vs human, human vs AI or AI vs AI game version.

                // Human player makes a move. If human vs human, enable both player IDs.

                if (playerID == 1 | playerID == 3)
                {

                CoordinateInput:

                    // Ask user to input coordinates

                    int[] nextMoveCoordinates = GetCoordinates(currentBoardState, playerID);

                    // Ask if user wants to change the coordinates

                    bool changeCoordinates = ChangeCoordinateChoice(currentBoardState, nextMoveCoordinates, playerID);

                    if (changeCoordinates == true)
                    {
                        goto CoordinateInput;
                    }

                    // Check if move is valid

                    bool moveValid = CheckMoveValid(currentBoardState, nextMoveCoordinates);

                    // Add to the board if valid. If not, return to coordinate input

                    int[,] nextBoardState = emptyBoard;

                    if (moveValid == true)
                    {
                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }

                    if (moveValid == false)
                    {
                        Console.WriteLine("Tic Tac Toe - Game" + Environment.NewLine);
                        PrintBoard(currentBoardState);
                        Console.WriteLine("Player-" + playerID + " move");
                        Console.WriteLine("Row number: " + nextMoveCoordinates[0]);
                        Console.WriteLine("Column number: " + nextMoveCoordinates[1]);
                        Console.WriteLine("Move is not valid. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                        goto CoordinateInput;
                    }

                    // Add to player move count

                    int playerMoveCount = 0;

                    if (playerID == player1)
                    {
                        player1MoveCount++;
                        playerMoveCount = player1MoveCount;
                    }

                    if (playerID == player2)
                    {
                        player2MoveCount++;
                        playerMoveCount = player2MoveCount;
                    }

                    // Check if there is a winner

                    if (playerMoveCount >= 3)
                    {
                        if (playerID == player1)
                        {
                            player1Wins = CheckIfPlayerWon(nextBoardState, playerID);
                        }

                        if (playerID == player2)
                        {
                            player2Wins = CheckIfPlayerWon(nextBoardState, playerID);
                        }
                    }

                    if (player1Wins == true | player2Wins == true)
                    {
                        currentBoardState = nextBoardState;
                        gameFinished = true;
                        break;
                    }

                    // Check if board is full

                    boardIsFull = CheckIfBoardFull(nextBoardState);

                    if (boardIsFull == true)
                    {
                        currentBoardState = nextBoardState;
                        gameFinished = true;
                        drawsCount += 1;
                        break;
                    }

                    // Determine next player and setup for next move

                    int nextPlayer = GetNextPlayer(playerID);

                    playerID = nextPlayer;

                    currentBoardState = nextBoardState;
                }

                // Computer makes a move. If computer vs computer, enable both player IDs.

                if (playerID == 2 | playerID == 3) 
                {
                    int methodOfChoice = 5; // Choose mode of AI 1) random; 2) winning; 3) avoid losing.
                    int[,] nextBoardState = CopyArray(emptyBoard);

                    // Modes of AI: 
                    // 1) Determine moves randomly

                    if (methodOfChoice == 1 /*& playerID == 1*/)
                    {
                        int[] nextMoveCoordinates = DetermineMoveRandomly(currentBoardState);

                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }

                    // 2) Determines moves randomly unless a winning move is available

                    if (methodOfChoice == 2 /*& playerID == 2*/)
                    {
                        int[] nextMoveCoordinates = FindWinningMove(currentBoardState, playerID);

                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }

                    // 3) Determines whether a winning move is possible, if not avoids losing moves or otherwise chooses randomly

                    if (methodOfChoice == 3 /*& playerID == 2*/)
                    {
                        int[] nextMoveCoordinates = FindWinningAvoidLosingMove(currentBoardState, playerID);

                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }

                    // 4) AI makes the move

                    if (methodOfChoice == 4 /*& playerID == 1*/)
                    {
                        int[] nextMoveCoordinates = AIMakeMove(currentBoardState, playerID);

                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }

                    // 5) AI with depth makes the move

                    if (methodOfChoice == 5 /*& playerID == 1*/)
                    {
                        int[] nextMoveCoordinates = AIMakeMoveWithDepth(currentBoardState, playerID);

                        nextBoardState = AddMoveToBoard(currentBoardState, nextMoveCoordinates, playerID);
                    }


                    // Add to player move count

                    int playerMoveCount = 0;

                    if (playerID == player1)
                    {
                        player1MoveCount++;
                        playerMoveCount = player1MoveCount;
                    }

                    if (playerID == player2)
                    {
                        player2MoveCount++;
                        playerMoveCount = player2MoveCount;
                    }

                    // Check if there is a winner

                    if (playerMoveCount >= 3)
                    {
                        if (playerID == player1)
                        {
                            player1Wins = CheckIfPlayerWon(nextBoardState, playerID);
                        }

                        if (playerID == player2)
                        {
                            player2Wins = CheckIfPlayerWon(nextBoardState, playerID);
                        }
                    }

                    if (player1Wins == true | player2Wins == true)
                    {
                        currentBoardState = CopyArray(nextBoardState);
                        gameFinished = true;
                        break;
                    }

                    // Check if board is full

                    boardIsFull = CheckIfBoardFull(nextBoardState);

                    if (boardIsFull == true)
                    {
                        currentBoardState = CopyArray(nextBoardState);
                        gameFinished = true;
                        drawsCount += 1;
                        break;
                    }

                    // Determine next player and setup for next move

                    int nextPlayer = GetNextPlayer(playerID);

                    playerID = nextPlayer;

                    currentBoardState = CopyArray(nextBoardState);
                }
            }

            Console.WriteLine("Tic Tac Toe - Game" + Environment.NewLine);
            PrintBoard(currentBoardState);
            Console.WriteLine(Environment.NewLine + "Game Over!");

            if (player1Wins == true)
            {
                player1Score++;
                Console.WriteLine("Player-1 won");
                Console.WriteLine("Player-1 score: " + player1Score);
                Console.WriteLine("Player-2 score: " + player2Score);
                Console.WriteLine("Draws: " + drawsCount);
            }

            if (player2Wins == true)
            {
                player2Score++;
                Console.WriteLine("Player-2 won");
                Console.WriteLine("Player-1 score: " + player1Score);
                Console.WriteLine("Player-2 score: " + player2Score);
                Console.WriteLine("Draws: " + drawsCount);
            }

            if (boardIsFull == true)
            {
                Console.WriteLine("Draw");
                Console.WriteLine("Player-1 score: " + player1Score);
                Console.WriteLine("Player-2 score: " + player2Score);
                Console.WriteLine("Draws: " + drawsCount);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();

            // Ask if user wants to play again

            bool playAgain = ChoosePlayAgain();

            if (playAgain == true)
            {
                goto Beginning;
            }

            if (playAgain == false)
            {
                Environment.Exit(0);
            }

        }
    }
}
