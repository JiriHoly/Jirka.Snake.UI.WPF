using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jirka.Snake.Logic
{
    internal class Player
    {
        public string Name { get; private set; }
        public int BestScore { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.BestScore = 0;
        }

        public void AddScore()
        {
            this.BestScore++;
        }
    }
}
