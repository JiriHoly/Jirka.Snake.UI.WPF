using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jirka.Snake.Logic
{
    [Serializable()]
    public class Player
    {
        public string Name { get; private set; }
        public int BestScore { get; private set; }
        public int Score { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.BestScore = 0;
        }

        public Player(string name, int bestScore)
        {
            this.Name = name;
            this.BestScore = bestScore;
        }

        public void AddScore(int score)
        {
            this.Score += score;
            if (this.Score > this.BestScore) this.BestScore = this.Score;
        }


    }
}
