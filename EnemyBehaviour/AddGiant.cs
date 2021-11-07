using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    class AddGiant : Strategy, IStrategy
    {
        public void Do()
        {
            _gameInstance.EnemySoldiers.Add(new EnemyGiant());
        }
    }
}
