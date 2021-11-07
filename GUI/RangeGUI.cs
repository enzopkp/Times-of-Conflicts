using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class RangeGUI : GUIOption, IAction
    {
        public RangeGUI() : base(new Point2D() { X = 845, Y = 245 }, 65, 91)
        {
            _optionBitmap = SplashKit.LoadBitmap("range", "range.png");
            _value = 150;
        }
        public override void Action()
        {
            if (_gameInstance.player.Money >= _value)
            {
                _gameInstance.player.Money -= _value;
                _gameInstance.FriendlySoldiers.Add(new Range());
            }
        }
    }
}