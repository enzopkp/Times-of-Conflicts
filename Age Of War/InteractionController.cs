using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_Of_War
{
    class InteractionController
    {
        /// <summary>
        /// Damage and collision logic for both castles and all soldiers
        /// </summary>
        private GameSingleton _gameInstance = GameSingleton.Instance;
        private GameRender _gameRender = new GameRender();

        public void UpdateSoldiers()
        {
            if (_gameInstance.EnemySoldiers.Any() && _gameInstance.FriendlySoldiers.Any())//If there is at least one soldier in each list
            {
                CalculateDamageFor(_gameInstance.FriendlySoldiers[0], _gameInstance.EnemySoldiers[0]);//We determine whether they are attacking
            }

            UpdateSoldier(_gameInstance.FriendlySoldiers, _gameInstance.enemyCastle);
            UpdateSoldier(_gameInstance.EnemySoldiers, _gameInstance.castle);
        }

        private void UpdateSoldier(List<Soldier> list, Castle castleToInteract)//Takes a list of soldiers and their target castle
        {
            foreach (Soldier soldier in list.ToList())//Loops through each soldier in the list
            {
                if (soldier.Health <= 0)//Verifies if the soldier is dead
                {
                    list.Remove(soldier);//Remove soldier
                    _gameInstance.player.Money += soldier.Value;//Pay the payer the amount of the soldier's value
                    return;
                } 
                else if (soldier.ObjectiveReached())
                {
                    SoldierDamageCastle(soldier, castleToInteract);//Soldier damages the castle once it reaches it
                    CastleDamageSoldier(castleToInteract, soldier);//In return, the castle damages the soldier too
                }
                else if (!IsInQueue(soldier, list) && !soldier.Fighting)//Verifies whether soldier is not waiting in queue and isn't in fighting mode
                {
                    soldier.MoveSoldier();

                }
                _gameRender.DrawSoldier(soldier);//Render soldiers
                soldier.Fighting = false;
            }
        }

        private void CastleDamageSoldier(Castle castle, Soldier soldier)
        {
            if (castle.CooldownElapsed())
                soldier.Damage(castle.Attack);//Damage castle only if the cooldown is over
        }

        public void SoldierDamageCastle(Soldier soldier, Castle castle )
        {
            if (soldier.CooldownElapsed())
                castle.Damage(soldier.Attack);//Damage the soldier only if the cooldown is over
        }

        public void CalculateDamageFor(Soldier friendlySoldier, Soldier enemySoldier)
        {
            if (friendlySoldier.SoldierBitmap.BitmapCollision(friendlySoldier.Position, enemySoldier.SoldierBitmap, enemySoldier.Position))//Detects the collision of soldiers
            {
                friendlySoldier.Fighting = true;
                enemySoldier.Fighting = true;
                if (friendlySoldier.CooldownElapsed())//If cooldown is elapsed, soldiers will attack each other
                {
                    enemySoldier.Damage(friendlySoldier.Attack);
                }
                if (enemySoldier.CooldownElapsed())
                {
                    friendlySoldier.Damage(enemySoldier.Attack);
                }
            }
        }

        public bool IsInQueue(Soldier soldier, List<Soldier> soldierList)//Takes a soldier and the list it is in
        {
            int index = soldierList.FindIndex(a => a==soldier);
            if (index <= 0)//if the soldier is first, it is not in the queue
            {
                return false;
            }
            if(Math.Abs(soldierList[index-1].Position.X - soldier.Position.X) <= 50){//if soldier is within 50 px from the soldier in front, it's waiting in queue
                return true;
            }
            return false;//By default, not in queue
        }

    }
}
