using System;

namespace XO
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            Console.WriteLine("Welcome to XOGame!\nInput a number of position that you want to join.\nAs always, Xs first, then - Os\n");
            game.StartGame();
        }
    }
}
