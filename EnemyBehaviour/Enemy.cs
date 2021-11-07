using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    public class Enemy
    {
        private Random _random = new Random();
        private int _cooldown;
        private IStrategy _strategy;

        public Enemy()
        {
            _cooldown = _random.Next(150, 300);
        }

        //public Enemy(IStrategy strategy)
        //{
        //    this._strategy = strategy;
        //}
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void Tick()
        {
            _cooldown -= 1;
            if (_cooldown == 0)
            {
                DoSomething();
                _cooldown = _random.Next(150, 500);
            }
        }
        public void DoSomething()
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
            _strategy.Do();
        }
    }
}
