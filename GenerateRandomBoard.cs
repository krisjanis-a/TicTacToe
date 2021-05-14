using System;
namespace TicTacToe
{
    public class GenerateRandomBoard
    {
        public static int[,] CreateRandomBoard()
        {
            int[,] randomBoard = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            Random random = new Random();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    double randomNumber = random.Next(0, 100);

                    if (50 < randomNumber & i != 2 & j != 2)
                    {
                        randomBoard[i, j] = 1;
                    }
                }
            }

            return randomBoard;
        }
    }
}
