using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    class GUIManager
    {
        private GameSingleton _gameInstance = GameSingleton.Instance;
        public bool IsIn(Point2D click, Point2D point1, Point2D point2)
        {
            if (point1.X >= click.X && point2.X <= click.X && point1.Y >= click.Y && point2.Y <= click.Y)
                return true;
            return false;
        }

        public void CheckClick(Point2D click)
        {
            foreach (GUIOption option in _gameInstance.guiOptions.ToList())
            {
                if(click.X >= option.Position.X && click.X <= option.Position.X + option.Width && click.Y >= option.Position.Y && click.Y <= option.Position.Y + option.Height)
                {
                    option.Action();
                    return;
                }
            }
        }
    }
}