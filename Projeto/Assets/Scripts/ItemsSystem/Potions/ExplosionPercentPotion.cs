using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class ExplosionPercentPotion : Potion
    {
        public float dmgPercent = 0.1f;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.Damage(creature.creatureMaxHealth * dmgPercent);
            
            yield break;
        }
    }
}