using static TicTacToe.Engine_AI;
using NUnit.Framework;

namespace TicTacToe
{
    public class AIMakeMoveTest
    {
        int player1 = 1;
        int player2 = 2;
        int[,] random_final_Move_Board_1 = { { 1, 0, 2 }, { 2, 1, 2 }, { 1, 0, 0 } };
        int[,] random_block_opponent_Move_Board_1 = { { 1, 2, 1 }, { 1, 0, 0 }, { 2, 0, 2 } };
        int[,] random_block_opponent_Move_Board_2 = { { 0, 1, 0 }, { 0, 0, 1 }, { 2, 2, 1 } };

        [Test]
        public void AIMakeMove_PossibleFinish_Move_1()
        {
            int[] expected = { 2, 2 };

            int[] actual = AIMakeMove(random_final_Move_Board_1, player1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AIMakeMove_Block_opponent_Move_1()
        {
            int[] expected = { 2, 1 };

            int[] actual = AIMakeMove(random_block_opponent_Move_Board_1, player1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AIMakeMove_Block_opponent_Move_2()
        {
            int[] expected = { 0, 2 };

            int[] actual = AIMakeMove(random_block_opponent_Move_Board_2, player2);

            Assert.AreNotEqual(expected, actual);
        }
    }
}
