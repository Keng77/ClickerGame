using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Player
    {
        public string name { get; private set; }
        int score;

        public Player(string name)
        {
            this.name = name;
            score = 0;
        }

        public void AddScore(int score)
        {
            this.score += score;
        }

        public override string ToString()
        {
            return name + ": " + score;
        }
    }
}
