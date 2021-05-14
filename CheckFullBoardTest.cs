using static TicTacToe.Engine_Game;
using NUnit.Framework;

namespace TicTacToe
{
    public class CheckFullBoardTest
    {
        int[,] fullBoard = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int[,] halfEmptyBoard = { { 1, 1, 1 }, { 0, 0, 0 }, { 1, 1, 1 } };
        int[,] emptyBoard = { { 0, 0, 0}, { 0, 0, 0}, { 0, 0, 0} };

        int[,] randomBoard = GenerateRandomBoard.CreateRandomBoard();

        [Test]
        public void CheckIfBoardFull_BoardIsFull()
        {
            bool expected = true;

            bool actual = CheckIfBoardFull(fullBoard);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfBoardFull_BoardIsHalfEmpty()
        {
            bool expected = false;

            bool actual = CheckIfBoardFull(halfEmptyBoard);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfBoardFull_BoardIsEmpty()
        {
            bool expected = false;

            bool actual = CheckIfBoardFull(emptyBoard);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckIfBoardFull_BoardIsRandom()
        {
            bool expected = false;

            bool actual = CheckIfBoardFull(randomBoard);

            Assert.AreEqual(expected, actual);
        }
    }
}
