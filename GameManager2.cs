using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    class GameManager2
    {
        private GameSingleton _gameInstance = GameSingleton.Instance;
        private GameRender _gameRender = new GameRender();
        //damages, collision with enemies

        public void UpdateSoldiers()
        {
            if (_gameInstance.EnemySoldiers.Any() && _gameInstance.FriendlySoldiers.Any())
            {
                CalculateDamageFor(_gameInstance.FriendlySoldiers[0], _gameInstance.EnemySoldiers[0]);
            }

            UpdateSoldier(_gameInstance.FriendlySoldiers, _gameInstance.enemyCastle);
            UpdateSoldier(_gameInstance.EnemySoldiers, _gameInstance.castle);
        }

        private void UpdateSoldier(List<Soldier> list, Castle castleToInteract)
        {
            foreach (Soldier soldier in list.ToList())
            {
                if (soldier.Health <= 0)
                {
                    list.Remove(soldier);
                    _gameInstance.player.Money += soldier.Value;
                    return;
                } 
                else if (soldier.ObjectiveReached())
                {
                    SoldierDamageCastle(soldier, castleToInteract);
                    CastleDamageSoldier(castleToInteract, soldier);
                }
                else if (!IsInQueue(soldier, list) && !soldier.Fighting)
                {
                    soldier.MoveSoldier();

                }
                _gameRender.DrawSoldier(soldier);
                soldier.Fighting = false;
            }
        }

        private void CastleDamageSoldier(Castle castle, Soldier soldier)
        {
            if (castle.CooldownElapsed())
                soldier.Damage(castle.Attack);
        }

        public void SoldierDamageCastle(Soldier soldier, Castle castle )
        {
            if (soldier.CooldownElapsed())
            {
                castle.Damage(soldier.Attack);
            }
        }

        public void CalculateDamageFor(Soldier friendlySoldier, Soldier enemySoldier)
        {
            if (friendlySoldier.SoldierBitmap.BitmapCollision(friendlySoldier.Position, enemySoldier.SoldierBitmap, enemySoldier.Position))
            {
                friendlySoldier.Fighting = true;
                enemySoldier.Fighting = true;
                if (friendlySoldier.CooldownElapsed())
                {
                    enemySoldier.Damage(friendlySoldier.Attack);
                }
                if (enemySoldier.CooldownElapsed())
                {
                    friendlySoldier.Damage(enemySoldier.Attack);
                }
            }
        }

        public bool IsInQueue(Soldier soldier, List<Soldier> soldierList)
        {
            int index = soldierList.FindIndex(a => a==soldier);
            if (index <= 0)
            {
                return false;
            }
            if(Math.Abs(soldierList[index-1].Position.X - soldier.Position.X) <= 50){
                return true;
            }
            return false;
        }

    }
}
