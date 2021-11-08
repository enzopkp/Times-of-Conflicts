using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public class GameRender
    {
        /// <summary>
        /// Class responsible for the rendering of the game and its elements
        /// </summary>
        private GameSingleton _gameInstance = GameSingleton.Instance;
        private Bitmap _background= SplashKit.LoadBitmap("background", "background.png");
        private Bitmap _banner = SplashKit.LoadBitmap("banner", "banner.png");
        public void DrawGame()
        {
            DrawMap();
            DrawCastles();
            DrawGUI();
            DrawStats();
            DrawArcher();
        }

        private void DrawCastles()//Render castles
        {
            DrawCastle(_gameInstance.castle);
            DrawCastle(_gameInstance.enemyCastle);
        }

        private void DrawMap()//Render the game elements
        {
            SplashKit.DrawBitmap(_background, 0, 0);
            SplashKit.DrawBitmap(_banner, 0, 0);
        }

        private void DrawGUI()//Render GUI
        {
            foreach(GUIOption option in _gameInstance.guiOptions.ToList())
            {
                SplashKit.DrawBitmap(option.OptionBitmap, option.Position.X, option.Position.Y);
            }
        }

        private void DrawStats()//Render the player and enemy stats
        {
            SplashKit.DrawTextOnWindow(SplashKit.WindowNamed("Times Of Conflicts"), Math.Floor(_gameInstance.castle.Health).ToString(), SplashKit.ColorBlack(), 280, 85);
            SplashKit.DrawTextOnWindow(SplashKit.WindowNamed("Times Of Conflicts"), _gameInstance.player.Money.ToString(), SplashKit.ColorBlack(), 260, 135);
            SplashKit.DrawTextOnWindow(SplashKit.WindowNamed("Times Of Conflicts"), Math.Floor(_gameInstance.enemyCastle.Health).ToString(), SplashKit.ColorBlack(), 1605, 90);
            SplashKit.DrawTextOnWindow(SplashKit.WindowNamed("Times Of Conflicts"), _gameInstance.enemyCastle.Towers.Count.ToString(), SplashKit.ColorBlack(), 1570, 145);
        }

        internal void DrawSoldier(Soldier soldier)//Render a soldier
        {
            SplashKit.DrawBitmap(soldier.SoldierBitmap, soldier.Position.X, soldier.Position.Y);
            SplashKit.DrawTextOnWindow(SplashKit.WindowNamed("Times Of Conflicts"), soldier.Health.ToString(), SplashKit.ColorBlack(), soldier.Position.X + 10, soldier.Position.Y + 20);
        }

        public void DrawArcher()//Render castle archers
        {
            foreach(CastleDefender castleDefender in _gameInstance.castle.Towers)
            {
                SplashKit.DrawBitmap(castleDefender.ArcherBitmap, castleDefender.X, castleDefender.Y);
            }
            foreach (CastleDefender castleDefender in _gameInstance.enemyCastle.Towers)
            {
                SplashKit.DrawBitmap(castleDefender.ArcherBitmap, castleDefender.X, castleDefender.Y);
            }

        }

        public void DrawCastle(Castle castle)//Render castles according to their health
        {
            if (castle.Health > 700)
            {
                SplashKit.DrawBitmap(castle.CastleBitmap, castle.X, castle.Y);
            }
            else if (castle.Health <= 700 && castle.Health > 400)
            {
                SplashKit.DrawBitmap(castle.CastleDmgBitmap, castle.X, castle.Y);
            }
            else if (castle.Health <= 400)
            {
                SplashKit.DrawBitmap(castle.CastleBrokenBitmap, castle.X, castle.Y);
            }
        }

    }
}
