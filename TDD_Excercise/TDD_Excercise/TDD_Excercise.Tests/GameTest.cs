using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_Excercise.Tests
{
    [TestClass]
    public class GameTest
    {
        private Game game;

        public GameTest()
        {
            this.game = new Game();
        }

        [TestMethod]
        public void CreatingGameObjectAndCallingMethods()
        {
            this.RollMany(20, 0);
            Assert.IsTrue(game.Score() == 0);
        }

        [TestMethod]
        public void RollAllOnes_GameObjectCreated_ResultIs20()
        {
            this.RollMany(20, 1);
            Assert.IsTrue(game.Score() == 20);
        }

        [TestMethod]
        public void RollOneSpare_GameObjectCreated_ResultIs16()
        {
            this.RollSpare();
            this.game.Roll(3);
            this.RollMany(17, 0);

            Assert.IsTrue(this.game.Score() == 16);
        }

        [TestMethod]
        public void RollOneStrik_GameObjectCreated_ResultIs24()
        {
            this.RollStrike();
            this.game.Roll(3);
            this.game.Roll(4);
            this.RollMany(16, 0);

            Assert.IsTrue(this.game.Score() == 24);
        }

        [TestMethod]
        public void RollPerfectGame_GameObjectCreated_ResultIs300()
        {
            this.RollMany(12, 10);

            Assert.IsTrue(this.game.Score() == 300);
        }

        private void RollMany(int numberOfRolls, int pins)
        {
            for (int i = 0; i < numberOfRolls; i++)
            {
                this.game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            this.game.Roll(5);
            this.game.Roll(5);
        }

        private void RollStrike()
        {
            this.game.Roll(10);
        }
    }
}
