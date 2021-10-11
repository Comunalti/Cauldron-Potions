using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class SlownessPotion: Potion
    {
        public float stunChance = 0.50f;
        public float speedReduction = 3;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.AddStunChance(stunChance);
            creature.RemoveSpeed(speedReduction);
            
            yield break;

        }
    }
}