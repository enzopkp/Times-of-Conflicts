using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class Range : Soldier, IAttack
    {
        public Range() : base(80, 8, 12, new Point2D() { X=225, Y=665}, 10, 1650, 0)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_range", "_range.png"); 
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
