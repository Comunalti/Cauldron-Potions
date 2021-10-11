using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class HealingPercentPotion : Potion
    {
        public float healingPercent = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);
            creature.Heal(creature.creatureMaxHealth*healingPercent);
            yield break;
        }
    }
}