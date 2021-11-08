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
        /// <summary>
        /// Main class running the game
        /// </summary>
        static private GameSingleton _gameInstance = GameSingleton.Instance;
        private GameRender gameRender;
        private InteractionController gameManager;
        private GUIManager guiManager;

        public event Action LoseEvent;
        public event Action PauseEvent;
        public event Action WinEvent;
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
                
                if (SplashKit.KeyTyped(KeyCode.PKey))//If P key is pressed, game pauses
                {
                    PauseEvent.Invoke();
                    pause = true;
                }
                if (_gameInstance.castle.Health<=0)//If ally castle is destroyed, lose the game
                {
                    LoseEvent.Invoke();
                    pause = true;
                }
                if (_gameInstance.enemyCastle.Health <= 0)//If Enemy castle is destroyed, lose the game
                {
                    WinEvent.Invoke();
                    pause = true;
                }

                SplashKit.RefreshScreen(60);
            } while (!SplashKit.WindowCloseRequested("Times Of Conflicts"));
            
        }

        private void TickEntities()//Ticks all the entities in the game
        {
            _gameInstance.enemyCastle.TickCastleCooldown();
            _gameInstance.castle.TickCastleCooldown();
            _gameInstance.enemy.Tick();
            TickSoldierList(_gameInstance.FriendlySoldiers);
            TickSoldierList(_gameInstance.EnemySoldiers);
        }

        private void TickSoldierList(List<Soldier> soldierList)//Loops through a given soldier list and ticks them
        {
            foreach (Soldier soldier in soldierList.ToList())
            {
                soldier.TickSoldierCooldown();
            }
        }

        private void SetupStart()
        {
            gameRender = new GameRender();//Rendering controller
            gameManager = new InteractionController();//Interaction controller
            guiManager = new GUIManager();//GUI controller
        }
    }
}





