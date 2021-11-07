using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class Melee : Soldier, IAttack
    {
        public Melee() : base(100, 5, 16, new Point2D() { X=225, Y=665}, 20, 1650, 0)
        {
            _soldierBitmap = SplashKit.LoadBitmap("_melee", "_melee.png"); 
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
