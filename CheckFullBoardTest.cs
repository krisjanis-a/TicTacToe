using System;
using TicTacToe;
using Xunit;

namespace TicTacToe
{
    public class CheckFullBoardTest
    {
        int[,] fullBoard = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        int[,] halfEmptyBoard = { { 1, 1, 1 }, { 0, 0, 0 }, { 1, 1, 1 } };
        int[,] emptyBoard = { { 0, 0, 0}, { 0, 0, 0}, { 0, 0, 0} };

        [Fact]
        public void CheckIfBoardFull_BoardIsFull()
        {
            bool expected = true;

            bool actual = MainClass.CheckIfBoardFull(fullBoard);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckIfBoardFull_BoardIsHalfEmpty()
        {
            bool expected = true;

            bool actual = MainClass.CheckIfBoardFull(halfEmptyBoard);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckIfBoardFull_BoardIsEmpty()
        {
            bool expected = true;

            bool actual = MainClass.CheckIfBoardFull(emptyBoard);

            Assert.Equal(expected, actual);
        }
    }
}
