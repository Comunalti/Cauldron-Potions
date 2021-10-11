using System.Collections;
using CombatSystem;
using UnityEngine;

namespace ItemsSystem.Potions
{
    public class ExplosionPotion : Potion
    {
        public float dmg = 30;
        protected override IEnumerator MainEffect(Creature creature)
        {
            yield return new WaitForSeconds(1);

            creature.Damage(dmg);
            
            yield break;
        }
    }
}