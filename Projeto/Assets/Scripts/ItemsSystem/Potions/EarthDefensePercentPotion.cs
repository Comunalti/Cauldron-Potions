using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class EarthDefensePercentPotion : Potion
    {
        public float defensePercentValue = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
        
            creature.AddDefense(creature.defense * defensePercentValue);
            yield break;
        }
    }
}