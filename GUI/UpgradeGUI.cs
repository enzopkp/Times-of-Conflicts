using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class UpgradeGUI : GUIOption, IAction
    {
        public UpgradeGUI() : base(new Point2D() { X = 1050, Y = 245 }, 64, 91)
        {
            _optionBitmap = SplashKit.LoadBitmap("upgrade", "upgrade.png");
            _value = 400;
        }
        public override void Action()
        {
            
            if (_gameInstance.player.Money >= _value)
            {
                _gameInstance.player.Money -= _value;
                _gameInstance.castle.UpgradeCastle();
            }
        }
    }
}