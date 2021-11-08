using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    public class Enemy
    {
        /// <summary>
        /// Enemy logic using Strategy design pattern
        /// </summary>
        private Random _random = new Random();//Random number generator
        private int _cooldown;
        private IStrategy _strategy;

        public Enemy()
        {
            _cooldown = _random.Next(150, 300);//Set a random cooldown between 150 and 300 ticks
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;//Set strategy
        }
        public void Tick()
        {
            _cooldown -= 1;
            if (_cooldown == 0)
            {
                DoSomething();//If cooldown reaches 0, execute the strategy
                _cooldown = _random.Next(150, 500);//Resets a new cooldown 
            }
        }
        public void DoSomething()//Based on a random number, the Enemy will execute any of the following 4 actions: summon melee, range, giant or upgrade castle
        {
            int num = _random.Next(1000);
            if (0 <= num && num <= 350)
            {
                this.SetStrategy(new AddMelee());
            }
            else if (351 <= num && num <= 700)
            {
                this.SetStrategy(new AddRange());
            }
            else if (701 <= num && num <= 900)
            {
                this.SetStrategy(new AddGiant());
            }
            else if (901 <= num && num <= 1000)
            {
                this.SetStrategy(new Upgrade());
            }
            _strategy.Do();//Execute strategy
        }
    }
}
