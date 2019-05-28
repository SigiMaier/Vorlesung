using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Excercise
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            this.rolls[this.currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (this.IsStrike(frameIndex))
                {
                    score += 10 + this.StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (this.IsSpare(frameIndex))
                {
                    score += 10 + this.SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += this.SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return this.rolls[frameIndex] == 10;
        }

        private int StrikeBonus(int frameIndex)
        {
            return this.rolls[frameIndex + 1] + this.rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return this.rolls[frameIndex] + this.rolls[frameIndex + 1] == 10;
        }

        private int SpareBonus(int frameIndex)
        {
            return this.rolls[frameIndex + 2];
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return this.rolls[frameIndex] + this.rolls[frameIndex + 1];
        }
    }
}
