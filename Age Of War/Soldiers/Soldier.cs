using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Age_Of_War
{
    public abstract class Soldier
    {
        protected int _health;
        protected double _speed;
        protected int _damage;
        protected Point2D _position;
        protected Bitmap _soldierBitmap;
        protected int _attackRate;
        protected int _objectiveCoordinates;
        protected int _value;

        public int Cooldown { get; set; }
        public bool Fighting { get; set; }
        public Point2D Position { get => _position; set => _position = value; }
        public Bitmap SoldierBitmap { get => _soldierBitmap; set => _soldierBitmap = value; }
        public int Health { get => _health; set => _health = value; }
        public int Attack { get => _damage; set => _damage = value; }
        public int Value { get => _value; set => _value = value; }


        public Soldier(int health, double speed, int damage, Point2D position, int attackRate, int objectiveCoordinates, int value)
        {
            _health = health;
            _speed = speed;
            _damage = damage;
            _position = position;
            Fighting = false;
            _attackRate = attackRate;
            _objectiveCoordinates = objectiveCoordinates;
            Cooldown = 0;
            _value = value;
        }

        public void MoveSoldier()//Change the location of the soldier
        {
            _position.X += _speed;
        }
        public void TickSoldierCooldown()//Increase the cooldown of the soldier
        {
            Cooldown++;
        }
        public bool CooldownElapsed()
        {
            if (Cooldown > _attackRate)//If the cooldown is greater than the attack rate, the soldier can attack
            {
                Cooldown = 0;
                return true;
            }
            return false;
        }

        public void Damage(int amount)//Receive damage
        {
            this.Health -= amount;
        }

        public abstract bool ObjectiveReached();
        
    }
}
