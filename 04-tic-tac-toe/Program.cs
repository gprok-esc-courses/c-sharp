using System;

namespace TicTacToe
{
    internal class Program
    {

        static bool PlayAgain(Game game)
        {
            string Ans;
            game.DisplayScore();
            Console.Write("Play again? ");
            Ans = Console.ReadLine();
            if (Ans != "y")
            {
                return false;
            }
            game.Reset();
            return true;
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            while (true)
            {
                game.Display();
                game.Play();
                Player w = game.Winner();
                if(w != null)
                {
                    Console.WriteLine(w.Symbol + " wins!");
                    if(!PlayAgain(game))
                    {
                        break;
                    }
                }
                else if(game.IsTie())
                {
                    Console.WriteLine("It's a Tie");
                    if (!PlayAgain(game))
                    {
                        break;
                    }
                }
            }
        }
    }
}
