using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class HealingFlatPotion : Potion
    {
        public float healingFlat = 25;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.Heal(healingFlat);
            yield break;
        }
    }
}