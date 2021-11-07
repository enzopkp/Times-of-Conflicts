using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    public sealed class GameSingleton 
    {
        public List<Soldier> FriendlySoldiers = new List<Soldier> { };
        public List<Soldier> EnemySoldiers = new List<Soldier> { };

        public static CastleBuilder _castlebuiler = new CastleBuilder();
        public Castle castle = _castlebuiler.CreateFriendlyCastle();
        public Castle enemyCastle = _castlebuiler.CreateEnemyCastle();

        public List<GUIOption> guiOptions = new List<GUIOption> { };

        public Player player = new Player();
        public Enemy enemy = new Enemy();

        private GameSingleton()
        {
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