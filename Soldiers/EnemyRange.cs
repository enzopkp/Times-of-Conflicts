using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class EnemyRange : Soldier, IAttack
    {
        public EnemyRange() : base(80, -8, 10, new Point2D() { X = 1695, Y = 665 }, 10, 230, 200)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_enemyRange", "_enemyRange.png");
        }
    }
}
