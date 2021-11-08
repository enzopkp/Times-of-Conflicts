using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class GiantGUI : GUIOption, IAction
    {
        public GiantGUI() : base(new Point2D() { X = 940, Y = 245 }, 44, 91)
        {
            _optionBitmap = SplashKit.LoadBitmap("giant", "giant.png");
            _value = 250;
        }
        public override void Action()
        {
            if (_gameInstance.player.Money >= _value)
            {
                _gameInstance.player.Money -= _value;
                _gameInstance.FriendlySoldiers.Add(new Giant());
            }
        }
    }
}