using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        private string[,] Board;
        private Player P1, P2, Current;
        int LastRow, LastCol;

        public Game()
        {
            Board = new string[3, 3];
            P1 = new Player("X");
            P2 = new Player("O");
            Reset();
        }

        public void Reset()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Board[i, j] = "-";
                }
            }
            Current = P1;
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Play()
        {
            int row = 0, col = 0;
            bool ok = false;

            do
            {
                try
                {
                    Console.Write(Current.Symbol + " row: ");
                    row = Int32.Parse(Console.ReadLine());
                    Console.Write(Current.Symbol + " col: ");
                    col = Int32.Parse(Console.ReadLine());

                    if (Board[row, col] == "-")
                    {
                        ok = true;
                        Board[row, col] = Current.Symbol;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move, play again");
                    }
                }
                catch (IndexOutOfRangeException ie)
                {
                    Console.WriteLine("Please give only 0,1,2 values");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Numbers only please");
                }
            } while (!ok);
            LastCol = col;
            LastRow = row;
            Current = Current == P1 ? P2 : P1; 
        }

        public Player Winner()
        {
            // Check last row
            if(Board[LastRow, 0] == Board[LastRow, 1] && Board[LastRow, 0] == Board[LastRow, 2])
            {
                return GetWinner(Board[LastRow, 0]);
            }
            // Check last col
            if (Board[0, LastCol] == Board[1, LastCol] && Board[0, LastCol] == Board[2, LastCol])
            {
                return GetWinner(Board[0, LastCol]);
            }
            // Check the 2 diagonals
            if (Board[0, 0] != "-" && Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
            {
                return GetWinner(Board[0, 0]);
            }
            if (Board[0, 2] != "-" && Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0])
            {
                return GetWinner(Board[0, 2]);
            }
            return null;
        }

        public Player GetWinner(string Cell)
        {
            Player winner = Cell == "X" ? P1 : P2;
            winner.Score++;
            return winner;
        }

        public void DisplayScore()
        {
            Console.WriteLine("Score X - O: " + P1.Score + "-" + P2.Score);
        }

        public bool IsTie()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(Board[i, j] == "-")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
