using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class EarthDefensePotion : Potion
    {
        public float defenseValue;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddDefense(defenseValue);
            yield break;
        }
    }
}