using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public class Castle
    {
        protected double _health;
        protected int _upgrade;
        protected int _turretSlots;
        protected int _x;
        protected int _y;
        
        protected int _attackRate;

        protected Bitmap _castle;
        protected Bitmap _castledmg;
        protected Bitmap _castlebroken;
        private Bitmap _castleDefenderBitmap;

        private int[] _castleDefenderXPositions = new int[3];
        private int[] _castleDefenderYPositions = new int[3];
        private List<CastleDefender> _defenders = new List<CastleDefender> { };

        public List<CastleDefender> Towers=>_defenders;
        public int X => _x;
        public int Y => _y;
        public double Health => _health;
        public Bitmap CastleBitmap => _castle;
        public Bitmap CastleDmgBitmap => _castledmg;
        public Bitmap CastleBrokenBitmap => _castlebroken;
        public int Cooldown { get; set; }
        public int Attack { get; set; }

        public Castle(Bitmap castle, Bitmap castledmg, Bitmap castlebroken, Bitmap castleDefender, int x, int y, int[] archerX, int[] archerY)
        {
            _castle = castle;
            _castledmg = castledmg;
            _castlebroken = castlebroken;
            _castleDefenderBitmap = castleDefender;
            _x = x;
            _y = y;
            _castleDefenderXPositions = archerX;
            _castleDefenderYPositions = archerY;
            _upgrade = 0;
            _turretSlots = 0;
            _health = 1000;
            Attack = 0;
            _attackRate = 10;
        }

        public void UpgradeCastle()
        {
            if (_turretSlots < 3)
            {
                _upgrade++;
                _health = _health * 1.15;
                _defenders.Add(new CastleDefender(_castleDefenderXPositions[_turretSlots], _castleDefenderYPositions[_turretSlots], _castleDefenderBitmap));
                _turretSlots++;
                Attack += 10;
            }
        }

        public void Damage(int damage)
        {
            _health-=damage;
        }

        public void TickCastleCooldown()
        {
            Cooldown++;
        }
        public bool CooldownElapsed()
        {
            if (Cooldown > _attackRate)
            {
                Cooldown = 0;
                return true;
            }
            return false;
        }
    }
}
