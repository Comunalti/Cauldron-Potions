using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class SlownessPotion: Potion
    {
        public float stunChance;
        public float speedReduction;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddStunChance(stunChance);
            creature.RemoveSpeed(speedReduction);
            
            yield break;

        }
    }
}