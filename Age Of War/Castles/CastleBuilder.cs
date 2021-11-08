using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public class CastleBuilder
    {
        /// <summary>
        /// Castle building class using factory design pattern
        /// </summary>
        private int[] _archerXPositions;
        private int[] _archerYPositions;
        public Castle CreateFriendlyCastle()
        {
            _archerXPositions = new int[] { 110, 15, 75 };
            _archerYPositions = new int[] { 630, 605, 565 };
            return new Castle(SplashKit.LoadBitmap("castle1", "castle1.png"), 
                SplashKit.LoadBitmap("castle1dmg", "castle1dmg.png"), 
                SplashKit.LoadBitmap("castle1broken", "castle1broken.png"),
                SplashKit.LoadBitmap("castleDefender", "castleDefender.png"),
                -150, 
                400, 
                _archerXPositions, 
                _archerYPositions);
        }

        public Castle CreateEnemyCastle()
        {
            _archerXPositions = new int[] { 1670, 1740, 1840 };
            _archerYPositions = new int[] { 490, 570, 535 };
            return new Castle(SplashKit.LoadBitmap("castle2", "castle2.png"), 
                SplashKit.LoadBitmap("castle2dmg", "castle2dmg.png"), 
                SplashKit.LoadBitmap("castle2broken", "castle2broken.png"),
                SplashKit.LoadBitmap("enemyCastleDefender", "enemyCastleDefender.png"),
                1650, 
                400, 
                _archerXPositions, 
                _archerYPositions);
        }
    }
}
