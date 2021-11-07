using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public class CastleDefender
    {
        protected Bitmap _archerBitmap;
        protected int _damage;
        protected int _x;
        protected int _y;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Bitmap ArcherBitmap => _archerBitmap;

        public CastleDefender(int x, int y, Bitmap archerBitmap)
        {
            _archerBitmap = archerBitmap;
            _damage = 10;
            _x = x;
            _y = y; 
        }
    }
}
