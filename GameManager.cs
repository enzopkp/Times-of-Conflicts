using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using System.Diagnostics;
using System.Windows;

namespace Age_Of_War
{
    public class GameManager
    {
        static private GameSingleton _gameInstance = GameSingleton.Instance;
        private GameRender gameRender;
        private GameManager2 gameManager;
        private GUIManager guiManager;

        public event Action LoseEventHandler;
        public event Action PauseEventHandler;
        public bool pause = false;

        public void Start()
        {
            SetupStart();
            new Window("Times Of Conflicts", 1920, 800);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (pause) continue;

                TickEntities();
                gameRender.DrawGame();
                gameManager.UpdateSoldiers();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    guiManager.CheckClick(new Point2D() { X = SplashKit.MousePosition().X, Y = SplashKit.MousePosition().Y });
                }
                
                if (SplashKit.KeyTyped(KeyCode.PKey))
                {
                    PauseEventHandler?.Invoke();
                    pause = true;
                }
                if (_gameInstance.castle.Health<=0)
                {
                    LoseEventHandler.Invoke();
                    pause = true;
                }

                SplashKit.RefreshScreen(60);
            } while (!SplashKit.WindowCloseRequested("Times Of Conflicts"));
            
        }

        private void TickEntities()
        {
            _gameInstance.enemyCastle.TickCastleCooldown();
            _gameInstance.castle.TickCastleCooldown();
            _gameInstance.enemy.Tick();
            TickSoldierList(_gameInstance.FriendlySoldiers);
            TickSoldierList(_gameInstance.EnemySoldiers);
        }

        private void TickSoldierList(List<Soldier> soldierList)
        {
            foreach (Soldier soldier in soldierList.ToList())
            {
                soldier.TickSoldierCooldown();
            }
        }

        private void SetupStart()
        {
            gameRender = new GameRender();
            gameManager = new GameManager2();
            guiManager = new GUIManager();
            _gameInstance.guiOptions.Add(new MeleeGUI());
            _gameInstance.guiOptions.Add(new RangeGUI());
            _gameInstance.guiOptions.Add(new GiantGUI());
            _gameInstance.guiOptions.Add(new UpgradeGUI());
        }
    }
}





