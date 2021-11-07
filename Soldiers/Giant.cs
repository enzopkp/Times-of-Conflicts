using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class Giant : Soldier, IAttack
    {
        public Giant() : base(150, 2, 60, new Point2D() { X=225, Y=665}, 45, 1650, 0)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_giant", "_giant.png"); 
        }
        public override void Damage(int amount)
        {
            this.Health -= amount;
        }
        
        public override bool ObjectiveReached()
        {
            if (this.Position.X > _objectiveCoordinates)
            {
                return true;
            }
            return false;
        }

    }
}
