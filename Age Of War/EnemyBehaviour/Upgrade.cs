using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    class Upgrade : Strategy, IStrategy
    {
        public void Do()
        {
            _gameInstance.enemyCastle.UpgradeCastle();
        }
    }
}
