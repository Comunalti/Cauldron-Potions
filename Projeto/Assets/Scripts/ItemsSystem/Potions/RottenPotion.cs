using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class RottenPotion : Potion
    {
        public float dmg;
        public float speedReduction;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.Damage(dmg);
            creature.RemoveSpeed(speedReduction);
            
            yield break;
        }
    }
}