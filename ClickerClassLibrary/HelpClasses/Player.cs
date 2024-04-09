using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score;

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void AddScore(int score)
        {
            this.Score += score;
        }

        public override string ToString()
        {
            return Name + ": " + Score;
        }
    }
}
