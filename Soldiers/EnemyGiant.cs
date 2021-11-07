using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class EnemyGiant : EnemySoldier, IAttack
    {
        public EnemyGiant() : base(150, -2, 50, new Point2D() { X = 1695, Y = 665 }, 45, 230, 300)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_enemyGiant", "_enemyGiant.png");
        }
    }
}
