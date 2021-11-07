using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class EnemyMelee : Soldier, IAttack
    {
        public EnemyMelee() : base(100, -5, 15, new Point2D() { X = 1695, Y = 665 }, 20, 230, 200)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_enemyMelee", "_enemyMelee.png");
        }
    }
}
