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
        /// <summary>
        /// Logic for the GUI
        /// </summary>
        private GameSingleton _gameInstance = GameSingleton.Instance;
        public bool IsIn(Point2D click, Point2D point1, Point2D point2)//Verify if click is within a square made up of 2 points
        {
            if (point1.X >= click.X && point2.X <= click.X && point1.Y >= click.Y && point2.Y <= click.Y)
                return true;
            return false;
        }

        public void CheckClick(Point2D click)//Verify if the user clicked on any of the GUI options
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