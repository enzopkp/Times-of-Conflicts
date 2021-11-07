using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class MeleeGUI : GUIOption, IAction
    {
        public MeleeGUI() : base(new Point2D() { X = 680, Y = 245 }, 125, 91)
        {
            _optionBitmap = SplashKit.LoadBitmap("melee", "melee.png");
            _value = 100;
        }
        public override void Action()
        {
            if (_gameInstance.player.Money >= _value)
            {
                _gameInstance.player.Money -= _value;
                _gameInstance.FriendlySoldiers.Add(new Melee());
            }  
        }
    }
}