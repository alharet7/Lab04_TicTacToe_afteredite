using System;
using Lab04_TicTacToe.Classes;

namespace Lab04_TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StartGame();
                Console.WriteLine("\nDo you want to play again ?? (y/n)");
                string loop = Console.ReadLine();
                if (loop == "n")
                    Environment.Exit(0);
            }
        }

        static void StartGame()
        {
            // TODO: Setup your game. Create a new method that creates your players and instantiates the game class. Call that method in your Main method.
            // You are requesting a Winner to be returned, Determine who the winner is output the celebratory message to the correct player. If it's a draw, tell them that there is no winner. 
            Player player1 = new Player();
            Player player2 = new Player();
            player1.Name = "A";
            player2.Name = "B";
            player1.Marker = "X";
            player2.Marker = "O";
            player1.IsTurn = true;
            player2.IsTurn = false;
            Game game1 = new Game(player1, player2);
            game1.Play();
        }


    }
}
