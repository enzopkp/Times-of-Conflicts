using SplashKitSDK;

namespace Age_Of_War
{
    class EnemySoldier : Soldier
    {
        public EnemySoldier(int health, double speed, int damage, Point2D position, int attackRate, int objectiveCoordinates, int value) : base(health, speed, damage, position, attackRate, objectiveCoordinates, value)
        {

        }
        public override bool ObjectiveReached()
        {
            if (this.Position.X < _objectiveCoordinates)
            {
                return true;
            }
            return false;
        }
    }
    
}
