using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    public sealed class GameSingleton 
    {
        /// <summary>
        /// Game instance using singleton design pattern
        /// </summary>
        public List<Soldier> FriendlySoldiers = new List<Soldier> { };//Soldiers lists
        public List<Soldier> EnemySoldiers = new List<Soldier> { };

        public static CastleBuilder _castlebuiler = new CastleBuilder();//Creating both castles
        public Castle castle = _castlebuiler.CreateFriendlyCastle();//Player castle
        public Castle enemyCastle = _castlebuiler.CreateEnemyCastle();//Enemy castle

        public List<GUIOption> guiOptions = new List<GUIOption> { };

        public Player player = new Player();
        public Enemy enemy = new Enemy();

        private GameSingleton()
        {
            guiOptions.Add(new MeleeGUI());//Melee soldier GUI button
            guiOptions.Add(new RangeGUI());//Range soldier GUI button
            guiOptions.Add(new GiantGUI());//Giant soldier GUI button
            guiOptions.Add(new UpgradeGUI());//Upgrade castle GUI button
        }
        public static GameSingleton Instance { get { return Nested.instance; } }
        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly GameSingleton instance = new GameSingleton();
        }
    }
}