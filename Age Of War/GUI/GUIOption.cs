using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public abstract class GUIOption : IAction
    {
        protected GameSingleton _gameInstance = GameSingleton.Instance;
        protected Point2D _position;
        protected Bitmap _optionBitmap;
        protected int _width;
        protected int _height;
        protected int _value;

        public Point2D Position { get => _position; set => _position = value; }
        public Bitmap OptionBitmap { get => _optionBitmap; set => _optionBitmap = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }


        public GUIOption(Point2D position, int width, int height)
        {
            _position = position;
            _width = width;
            _height = height;
        }
        public abstract void Action();
    }
}
