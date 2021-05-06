using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {


            // GAME ENGINE BEGINNING

            int player1Score = 0;
            int player2Score = 0;

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

            // Get user input for coordinates

            int[,] currentBoardState = emptyBoard;

            int boardHeight = currentBoardState.GetLength(0);
            int boardWidth = currentBoardState.GetLength(1);

            int player1 = 1;
            int player2 = 2;

            int player1MoveCount = 0;
            int player2MoveCount = 0;

            int playerID = 1;

            bool gameFinished = false;
            bool boardIsFull = false;
            bool player1Wins = false;
            bool player2Wins = false;

            while (gameFinished == false)
            {

            CoordinateInput:

                // Ask user to input coordinates

                int[] nextMoveCoordinates = GetCoordinates(currentBoardState, playerID);

                // Ask if user wants to change the coordinates

                bool changeCoordinates = ChangeCoordinateChoice (currentBoardState,nextMoveCoordinates, playerID);

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

                // Check if board is full

                boardIsFull = CheckIfBoardFull(nextBoardState);

                if (boardIsFull == true)
                {
                    currentBoardState = nextBoardState;
                    gameFinished = true;
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
                }

                // Determine next player and setup for next move

                int nextPlayer = GetNextPlayer(playerID);

                playerID = nextPlayer;

                currentBoardState = nextBoardState;
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
            }

            if (player2Wins == true)
            {
                player2Score++;
                Console.WriteLine("Player-2 won");
                Console.WriteLine("Player-1 score: " + player1Score);
                Console.WriteLine("Player-2 score: " + player2Score);
            }

            if (boardIsFull == true)
            {
                Console.WriteLine("Draw");
                Console.WriteLine("Player-1 score: " + player1Score);
                Console.WriteLine("Player-2 score: " + player2Score);
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

        public static void PrintBoard(int[,] boardToPrint)
        {

            int boardHeight = boardToPrint.GetLength(0);
            int boardWidth = boardToPrint.GetLength(1);

            int modifiedBoardHeight = boardHeight + 2;
            int modifiedBoardWidth = boardWidth + 2;


            int[,] modifiedBoard = new int[modifiedBoardHeight, modifiedBoardWidth];

            for (int i = 1; i < boardHeight + 1;)
            {
                for (int j = 1; j < boardWidth + 1;)
                {
                    modifiedBoard[i, j] = boardToPrint[i - 1, j - 1];
                    j++;
                }

                i++;
            }

            for (int i = 0; i < modifiedBoardHeight;)
            {
                for (int j = 0; j < modifiedBoardWidth;)
                {

                    // Print game zone

                    if ((0 < i & i < modifiedBoardHeight - 1) & (0 < j & j < modifiedBoardWidth - 1))
                    {
                        if (modifiedBoard[i, j] == 0)
                        {
                            Console.Write(" • ");
                        }

                        if (modifiedBoard[i, j] == 1)
                        {
                            Console.Write(" X ");
                        }

                        if (modifiedBoard[i, j] == 2)
                        {
                            Console.Write(" O ");
                        }
                    }

                    // Print edges of game board

                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            Console.Write("  /");
                        }

                        if (j == modifiedBoardWidth - 1)
                        {
                            Console.Write("\\  ");
                        }

                        if (0 < j & j < modifiedBoardWidth - 1)
                        {
                            Console.Write(" – ");
                        }
                    }

                    if (i == modifiedBoardHeight - 1)
                    {
                        if (j == 0)
                        {
                            Console.Write("  \\");
                        }

                        if (j == modifiedBoardWidth - 1)
                        {
                            Console.Write("/  ");
                        }

                        if (0 < j & j < modifiedBoardWidth - 1)
                        {
                            Console.Write(" – ");
                        }
                    }

                    if (0 < i & i < modifiedBoardHeight - 1)
                    {
                        if (j == 0 | j == modifiedBoardWidth - 1)
                        {
                            Console.Write(" | ");
                        }
                    }

                    j++;
                }

                Console.WriteLine();
                i++;

            }
        }

        public static int[] GetCoordinates(int[,] gameBoard, int playerID)
        {
        EntryPoint:

            Console.WriteLine("Tic Tac Toe - Game" + Environment.NewLine);
            PrintBoard(gameBoard);
            Console.WriteLine("Player-" + playerID + " move");

            string[] moveCoordinatesString = { "", "" };
            int[] moveCoordinates = { 0, 0 };

            Console.WriteLine("Input row number (0,1,2):");
            moveCoordinatesString[0] = Console.ReadLine();
            Console.WriteLine("Input column number (0,1,2):");
            moveCoordinatesString[1] = Console.ReadLine();

            if (!((moveCoordinatesString[0] == "0" | moveCoordinatesString[0] == "1" | moveCoordinatesString[0] == "2") & (moveCoordinatesString[1] == "0" | moveCoordinatesString[1] == "1" | moveCoordinatesString[1] == "2")))
            //if (!((moveCoordinates[0] == (0 | 1 | 2)) & (moveCoordinates[1] == (0 | 1 | 2))))
            {
                Console.WriteLine("Coordinates are not valid.");
                Console.ReadKey();
                Console.Clear();
                goto EntryPoint;
            }

            moveCoordinates[0] = int.Parse(moveCoordinatesString[0]);
            moveCoordinates[1] = int.Parse(moveCoordinatesString[1]);

            Console.Clear();
            return moveCoordinates;
        }

        public static bool CheckMoveValid(int[,] gameBoard, int[] moveCoordinates)
        {
            bool moveValid = false;

            int rowNumber = moveCoordinates[0];
            int columnNumber = moveCoordinates[1];

            if (gameBoard[rowNumber, columnNumber] == 0)
            {
                moveValid = true;
            }

            return moveValid;
        }
       
        public static int[,] AddMoveToBoard(int[,] gameBoard, int[] moveCoordinates, int playerID)
        {
            int rowNumber = moveCoordinates[0];
            int columnNumber = moveCoordinates[1];

            int[,] nextBoardState = gameBoard;

            nextBoardState[rowNumber, columnNumber] = playerID;

            return nextBoardState;
        }

        public static bool CheckIfBoardFull(int[,] gameBoard)
        {
            bool boardIsFull = true;

            int boardHeight = gameBoard.GetLength(0);
            int boardWidth = gameBoard.GetLength(1);

            for (int i = 0; i < boardHeight;)
            {
                for (int j = 0; j < boardWidth;)
                {
                    if(gameBoard[i,j]==0)
                    {
                        boardIsFull = false;
                    }

                    j++;
                }

                i++;
            }

            return boardIsFull;
        }

        public static bool CheckIfPlayerWon(int[,] gameBoard, int playerID)
        {
            bool playerWon = false;

            // Check all winning board formations

            // Full first row

            if(gameBoard[0,0] == playerID & gameBoard[0,1] == playerID & gameBoard[0,2] == playerID)
            {
                playerWon = true;
            }

            // Full second row

            if (gameBoard[1, 0] == playerID & gameBoard[1, 1] == playerID & gameBoard[1, 2] == playerID)
            {
                playerWon = true;
            }

            // Full third row

            if (gameBoard[2, 0] == playerID & gameBoard[2, 1] == playerID & gameBoard[2, 2] == playerID)
            {
                playerWon = true;
            }

            // Full first column

            if (gameBoard[0, 0] == playerID & gameBoard[1, 0] == playerID & gameBoard[2, 0] == playerID)
            {
                playerWon = true;
            }

            // Full second column


            if (gameBoard[0, 1] == playerID & gameBoard[1, 1] == playerID & gameBoard[2, 1] == playerID)
            {
                playerWon = true;
            }

            // Full third column

            if (gameBoard[0, 2] == playerID & gameBoard[1, 2] == playerID & gameBoard[2, 2] == playerID)
            {
                playerWon = true;
            }

            // Full downward diagonal

            if (gameBoard[0, 0] == playerID & gameBoard[1, 1] == playerID & gameBoard[2, 2] == playerID)
            {
                playerWon = true;
            }

            // Full upward diagonal

            if (gameBoard[2, 0] == playerID & gameBoard[1, 1] == playerID & gameBoard[0, 2] == playerID)
            {
                playerWon = true;
            }

            return playerWon;
        }

        public static int GetNextPlayer(int playerID)
        {
            int currentPlayerID = playerID;

            int nextPlayerID = 0;

            if (currentPlayerID == 1)
            {
                nextPlayerID = 2;
                goto End;
            }

            if (currentPlayerID == 2)
            {
                nextPlayerID = 1;
                goto End;

            }

            Console.WriteLine("Invalid player ID");

            End:

            return nextPlayerID;
        }

        public static bool ChangeCoordinateChoice (int[,]currentBoardState,int[] nextMoveCoordinates, int playerID)
        {
            bool changeCoordinates = false;

            while (true)
            {
            EntryPoint:

                Console.WriteLine("Tic Tac Toe - Game" + Environment.NewLine);
                PrintBoard(currentBoardState);
                Console.WriteLine("Player-" + playerID + " move");

                Console.WriteLine("Row number: " + nextMoveCoordinates[0]);
                Console.WriteLine("Column number: " + nextMoveCoordinates[1]);

                Console.WriteLine("Would you like to change the move coordinates? [Y - yes, N - no]");

                ConsoleKeyInfo result = Console.ReadKey(false);
                Console.Clear();

                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    changeCoordinates = true;
                    break;
                }

                if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    changeCoordinates = false;
                    break;
                }

                else
                {
                    goto EntryPoint;
                }
            }

            Console.Clear();
            return changeCoordinates;
        }

        public static bool ChoosePlayAgain()
        {
            bool playAgain = false;

            while (true)
            {
            EntryPoint:

                Console.WriteLine("Would you like to play again? [Y - yes, N - no]");

                ConsoleKeyInfo result = Console.ReadKey(false);
                Console.Clear();

                if ((result.KeyChar == 'Y') || (result.KeyChar == 'y'))
                {
                    playAgain = true;
                    break;
                }

                if ((result.KeyChar == 'N') || (result.KeyChar == 'n'))
                {
                    playAgain = false;
                    break;
                }

                else
                {
                    goto EntryPoint;
                }
            }

            Console.Clear();
            return playAgain;
        }
    }
}
