using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe - Game");

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

            // Get user input

            int[,] gameBoard = emptyBoard;

            int boardHeight = gameBoard.GetLength(0);
            int boardWidth = gameBoard.GetLength(1);

            int[] nextMoveCoordinates = GetCoordinates();

            Console.WriteLine("Row number: " + nextMoveCoordinates[0]);
            Console.WriteLine("Column number: " + nextMoveCoordinates[1]);

            //bool player1Turn = true;
            //bool player2Turn = false;
            //bool gameFinished = false;

            //while (gameFinished == false)
            //{
            //    if (player1Turn == true)
            //    {
            //        player1Turn = false;
            //        player2Turn = true;
            //    }

            //    if (player2Turn == true)
            //    {
            //        player1Turn = true;
            //        player2Turn = false;
            //    }

            //    bool emptyFieldExists = false;

            //    for (int i = 0; i < boardHeight;)
            //    {
            //        for (int j = 0; j < boardWidth;)
            //        {
            //            if(gameBoard[i,j]==0)
            //            {
            //                emptyFieldExists = true;
            //            }

            //            j++;
            //        }

            //        i++;
            //    }

            //    if(emptyFieldExists == false)
            //    {
            //        Console.WriteLine("The game is finished. It's a draw.");
            //        gameFinished = true;
            //    }
            //}
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

                    if ((0 < i & i < modifiedBoardHeight - 1)&(0 < j & j < modifiedBoardWidth - 1))
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

                        if (0 < j & j < modifiedBoardWidth-1)
                        {
                            Console.Write(" – ");
                        }
                    }

                    if (i == modifiedBoardHeight-1)
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

                    if (0 < i & i < modifiedBoardHeight-1)
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

        public static int[] GetCoordinates()
        {
            EntryPoint:

            string[] moveCoordinatesString = { "", "" };
            int[] moveCoordinates = { 0, 0 };

            Console.WriteLine("Input row number (0,1,2):");
            moveCoordinatesString[0] = Console.ReadLine();
            Console.WriteLine("Input column number (0,1,2):");
            moveCoordinatesString[1] = Console.ReadLine();

            if (moveCoordinatesString[0] != "0" | moveCoordinatesString[0] != "1" | moveCoordinatesString[0] != "2" | moveCoordinatesString[1] != "0" | moveCoordinatesString[1] != "1" | moveCoordinatesString[1] != "2")
            // if (moveCoordinates[0] != (0 | 1 | 2) & moveCoordinates[1] != (0 | 1 | 2) )
            {
                Console.WriteLine("Coordinates are not valid.");
                Console.ReadKey();
                Console.Clear();
                goto EntryPoint;
            }

            moveCoordinates[0] = int.Parse(moveCoordinatesString[0]);
            moveCoordinates[1] = int.Parse(moveCoordinatesString[1]);

            return moveCoordinates;
        }
    }
}
