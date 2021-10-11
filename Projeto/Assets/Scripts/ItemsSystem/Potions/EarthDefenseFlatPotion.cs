using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class EarthDefenseFlatPotion : Potion
    {
        public float defenseValue = 5;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
                        
            creature.AddDefense(defenseValue);
            yield break;
        }
    }
}