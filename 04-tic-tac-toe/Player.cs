using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        public string Symbol { get; set; }
        public int Score { get; set; }  

        public Player(string Symbol)
        {
            this.Symbol = Symbol;
            this.Score = 0;
        }
    }
}
