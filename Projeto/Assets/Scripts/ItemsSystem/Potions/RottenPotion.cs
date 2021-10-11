using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class RottenPotion : Potion
    {
        public float dmg = 10; 
        public float speedReduction = 2;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.Damage(dmg);
            creature.RemoveSpeed(speedReduction);
            
            yield break;
        }
    }
}