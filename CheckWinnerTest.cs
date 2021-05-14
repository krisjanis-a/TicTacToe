using static TicTacToe.Engine_Game;
using NUnit.Framework;

namespace TicTacToe
{
    public class CheckWinnerTest
    {
        int playerID = 1;

        int[,] firstLine =  { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }; // firstLine
        int[,] secondLine = { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }; // secondLine;
        int[,] thirdLine =  { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }; // thirdLine;

        int[,] firstColumn =  { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }; // firstColumn;
        int[,] secondColumn = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }; // secondColumn;
        int[,] thirdColumn = { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }; // thirdColumn;

        int[,] upDiagonal = { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } }; // upDiagonal;
        int[,] downDiagonal = { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }; // downDiagonal;


        [Test]

        public void CheckIfPlayerWon_firstLineWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(firstLine, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_secondLineWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(secondLine, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_thirdLineWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(thirdLine, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_firstColumnWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(firstColumn, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_secondColumnWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(secondColumn, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_thirdColumnWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(thirdColumn, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_upDiagonalWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(upDiagonal, playerID);

            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void CheckIfPlayerWon_downDiagonalWin()
        {
            bool expected = true;

            bool actual = CheckIfPlayerWon(downDiagonal, playerID);

            Assert.AreEqual(expected, actual);
        }



        // Test empty board - no winning positions

        int[,] emptyBoard = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        [Test]

        public void CheckIfPlayerWon_PlayerDidNotWin()
        {
            bool expected = false;

            bool actual = CheckIfPlayerWon(emptyBoard, playerID);

            Assert.AreEqual(expected, actual);
        }
    }
}


// DOES NOT WORK AS EXPECTED

//static IEnumerable<int[,]> TestMatrices()
//{
//    yield return new int[3, 3] { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 0, 0 } }; // firstLine
//    yield return new int[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } }; // secondLine;
//    yield return new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 1, 1, 1 } }; // thirdLine;
//    yield return new int[3, 3] { { 1, 0, 0 }, { 1, 0, 0 }, { 1, 0, 0 } }; // firstColumn;
//    yield return new int[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }; // secondColumn;
//    yield return new int[3, 3] { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 0, 1 } }; // thirdColumn;
//    yield return new int[3, 3] { { 0, 0, 1 }, { 0, 1, 0 }, { 1, 0, 0 } }; // upDiagonal;
//    yield return new int[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } }; // downDiagonal;
//}

//[TestCaseSource(nameof(TestMatrices))]

//public void CheckIfPlayerWon_PlayerDidWin(int[,]boardArray)
//{
//    bool expected = true;

//    bool actual = MainClass.CheckIfPlayerWon(boardArray, 1);

//    Assert.AreEqual(expected, actual);
//}
