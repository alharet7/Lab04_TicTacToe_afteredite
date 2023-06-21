using Xunit;
using Lab04_TicTacToe.Classes;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("XO3,4X6,789", false)]
        [InlineData("XO3,4O6,7O9", true)]
        [InlineData("XO3,456,789", false)]
        public void TestForWinners(string input, bool expected)
        {
            string[] inputSplit = input.Split(',');
            string[,] gameBoard = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = inputSplit[i][j].ToString();
                }
            }

            // Arrange
            Player p1 = new Player();
            p1.Name = "p1";
            p1.Marker = "X";
            p1.IsTurn = true;
            Player p2 = new Player();
            p2.Name = "p2";
            p2.Marker = "O";
            p2.IsTurn = false;
            Game newGame = new Game(p1, p2);
            newGame.Board.GameBoard = gameBoard;

            // Act
            bool result = newGame.CheckForWinner(newGame.Board);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSwitchPlayer()
        {
            // Arrange
            Player p1 = new Player();
            p1.Name = "p1";
            p1.Marker = "X";
            p1.IsTurn = true;
            Player p2 = new Player();
            p2.Name = "p2";
            p2.Marker = "O";
            p2.IsTurn = false;
            Game newGame = new Game(p1, p2);

            // Act
            newGame.SwitchPlayer();

            // Assert
            Assert.False(p1.IsTurn);
            Assert.True(p2.IsTurn);
        }

        [Theory]
        [InlineData("8", 2, 1)]
        [InlineData("2", 0, 1)]
        [InlineData("3", 0, 2)]
        public void TestTakeTurn(string input, int expectedRow, int expectedColumn)
        {
            // Arrange
            Console.SetIn(new StringReader(input));
            Player p1 = new Player();
            p1.Name = "p1";
            p1.Marker = "X";
            p1.IsTurn = true;
            Player p2 = new Player();
            p2.Name = "p2";
            p2.Marker = "O";
            p2.IsTurn = false;
            Game newGame = new Game(p1, p2);

            // Act
            p1.TakeTurn(newGame.Board);

            // Assert
            Assert.Equal("X", newGame.Board.GameBoard[expectedRow, expectedColumn]);
        }
    }
}