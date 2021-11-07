using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    interface IAttack
    {
        public void Damage(int amount);
        public bool ObjectiveReached();
    }
}
