using System.Collections.Generic;

namespace CombatSystem
{
    public class BattleManager : MonoBehaviourSingleton<BattleManager>
    {
        public List<Creature> inGame = new List<Creature>();

        public void CreatureDied(Creature creature)
        {
            if (creature is Player)
            {
                //endGame();
            }
            else
            {
                
            }
        }

    }
}